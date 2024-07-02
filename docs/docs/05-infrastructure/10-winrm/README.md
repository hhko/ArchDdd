---
sidebar_position: 2
---

# WinRM

## 개요
WinRM은 Windows Remote Management의 약자로 표준 SOAP(Simple Object Access Protocol) 기반 방화벽 친화적 프로토콜인 WS-Management 프로토콜 기반으로 추가적인 Agent 설치 없이 Windows 서버를 원격에서 접근하고 제어할 수 있는 Microsoft 구현체 입니다.

### 스펙
- 운영체제
  - Windows Server 2008 (with SP2) - only supported version 3.0 이상
  - Windows Server 2008 R2 (with SP1) 이상
  - Windows 7 (with SP1) 이상
- PowerShell
  - 5.1 이상
- .NET Framework
  - 4.0 이상
- 네트워크
  - 5985/http
  - 5986/https

## WinRM 구성
### 관리자 서버
```powershell
#
# 1. 사전 확인
#   Powershell 버전 확인 : 3.0+
#
$PSVersionTable

#
# 2. PowerShell 원격 활성화 설정
#   네트워크 카테고리가 Public이면 WinRM Authentication Basic을 사용할 수 없다.
#
Enable-PSRemoting -SkipNetworkProfileCheck -Force
# Authentication Basic일 때
#   Set-NetConnectionProfile -NetworkCategory Private
#   Get-NetConnectionProfile
#
#  - 요청을 수신하도록 WinRM이 업데이트되었습니다.
#  - WinRM 서비스 종류가 변경되었습니다.
#  - WinRM 서비스를 시작했습니다.
#  - 원격 관리를 위한 WinRM이 업데이트되었습니다.
#  - WinRM 방화벽 예외를 사용합니다.
#  - 로컬 사용자에게 원격으로 관리자 권한을 부여하도록 LocalAccountTokenFilterPolicy를 구성했습니다.
#
# Disable-PSRemoting -Force
#
#   winrm get winrm/config/service
#       Get-ChildItem WSMan:\localhost\service
#
#   winrm e winrm/config/listener
#       Get-ChildItem WSMan:\localhost\Listener

#
# 3. 5985/tcp 방화벽 허용
#
New-NetFirewallRule -DisplayName "WinRM-HTTP-In-TCP" -Direction Inbound -Protocol TCP -LocalPort 5985 -Action Allow
#   Set-NetFirewallProfile -Profile Domain, Public, Private -Enabled True
#   Get-NetFirewallRule -Name 'WINRM-HTTP-In-TCP' | Select-Object -Property Name, Direction, Action
#   Get-NetFirewallRule -Name winrm* | Select-Object Name, DisplayName, Profile, Enabled | Format-Table

#
# 4. TrustedHosts 신대 대상 추가
#
Set-Item WSMAN:\localhost\Client\TrustedHosts * -Force | Out-Null
#   Get-Item WSMAN:\localhost\Client\TrustedHosts

#
# 5. (Ansible 접속일 때 필수)RootSDDL에 계정 추가
#  - Add-WinRMDaclRule.ps1: https://gist.github.com/jborean93/6d9aaf868d1d40344188984ebb431b04
#  - AddSecurityPrincipalonDefaultWinRMSDDL.ps1: https://gist.github.com/jfrmilner/84314d79bf2708abff15313ff5f5d1ee
#
winrm configSDDL default

#
# 6. PowerShell 추가
#
Set-PssessionConfiguration microsoft.powershell -showsecuritydescriptor
#   Get-PSSessionConfiguration | Format-Table -Property Name, Permission
#   Name                   Permission
#   ----                   ----------
#   microsoft.powershell   NT AUTHORITY\INTERACTIVE AccessAllowed, 
#                                   BUILTIN\Administrators AccessAllowed, 
#                                   BUILTIN\Remote Management Users AccessAllowed, 
#                                   {Non-Administrator 계정}


#
# 설정 확인
#
Get-Service -Name "WinRM"
Get-LocalGroupMember -Group "Remote Management Users"
    ObjectClass Name                    PrincipalSource
    ----------- ----                    ---------------
    User        {호스트 이름}\{계정 이름} Local                                
```

### 원격 서버
```powershell
$userName = "{계정}"
$password = "{암호}"

# 사용자 생성
New-LocalUser -Name $userName -Password $securePassword -PasswordNeverExpires:$true -UserMayNotChangePassword:$true -ErrorAction Stop

# Administrators 그룹 추가
Add-LocalGroupMember -Group "Administrators" -Member $userName -ErrorAction Stop

# PSRemoting 활성화
Enable-PSRemoting -SkipNetworkProfileCheck -Force

# PSRemoting 5985/http 방화벽 허용
New-NetFirewallRule -DisplayName "WinRM-HTTP-In-TCP" -Direction Inbound -Protocol TCP -LocalPort 5985 -Action Allow | Out-Null

#
# 설정 확인
#
Get-LocalUser -Name $userName
Get-LocalGroupMember -Group "Administrators" -Member $userName
Get-Service -Name "WinRM"
Get-NetFirewallRule -Name 'WINRM-HTTP-In-TCP' | Select-Object -Property Name, Direction, Action
Test-NetConnection -Port 5985 -ComputerName localhost -WarningAction SilentlyContinue
```

## WinRM 접속
### 접속
```powershell
$servers = "{IP}", "{IP}"
$username = "{계정}"                    # whoami
$password = "{암호}"
$securepw = $password | ConvertTo-SecureString -AsPlainText -Force
$creds = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $username, $securepw
$sessions = New-PSSession -ComputerName $servers -Credential $creds -Authentication negotiate -SessionOption (New-PSSessionOption -SkipCACheck -SkipCNCheck)
$sessions
```
- `New-PSSession`: non 대화형(명령형)
- `Enter-PSSession`: 대화형


### 접속 해지
```powershell
Remove-PSSession $sessions
```

## WinRM 명령 구성
### 입력
```powershell
Invoke-Command -Session $sessions -ScriptBlock {
    param($remote변수1, $remote변수2, $remoteServerIp)

    ...
} -ArgumentList $변수1, $변수2
```

### 출력
```powershell
$result = Invoke-Command -Session $sessions -ScriptBlock {
    return [PSCustomObject]@{
        Timestamp = Get-Date
        HostName = $env:COMPUTERNAME
        필드_이름1 = $변수1
    }
}

$result.Timestamp
$result.HostName
$result.필드_이름1
```

### 함수
```powershell
Invoke-Command -Session $sessions -ScriptBlock {
    # 함수 정의
    function Get-ServiceProcessPID {
        param(
            [string]$serviceName
        )

        # ...

        # 사용자 정의 출력 타입
        return Get-WmiObject -Class Win32_Service |
            Where-Object { $_.Name -eq $serviceName } |
            Select-Object -ExpandProperty ProcessId
    }

    # 함수 호출
    $serviceProcessPID = Get-ServiceProcessPID -serviceName $serviceName
}
```

## WinRM 주요 명령
### 원격 서버 hostname
```powershell
Invoke-Command -Session $sessions -ScriptBlock {
    hostname
}
```

### 원격 서버 정보
```powershell
Invoke-Command -Session $sessions -ScriptBlock {
    return [PSCustomObject]@{
        HostName = hostname
        Now = (Get-Date).ToString("yyyy-MM-dd HH:mm:ss")
        PSVersion = $PSVersionTable.PSVersion
    }
} |
Format-Table -Property @{Expression={$_.HostName}; Label="Host Name"},
    @{Expression={$_.PSComputerName}; Label="Host IP"},
    @{Expression={$_.Now}; Label="Host Now"},
    @{Expression={$_.PSVersion}; Label="PSVersion"}
```

### 원격 서버 윈도우 서비스 중지
```powershell
Invoke-Command -Session $sessions -ScriptBlock {
    $service = Get-Service "서비스_이름" -ErrorAction SilentlyContinue
    if ($service) {
        Stop-Service $serviceName -Force -WarningAction SilentlyContinue -ErrorAction SilentlyContinue
    }
}
```

### 원격 서버 윈도우 서비스 Timeout 중지
```powershell
function Stop-ServiceAndWait {
    param(
        [string]$serviceName,       # 서비스 이름
        [int]$timeoutSeconds        # 시간(초)
    )

    $scriptBlock = { param($serviceName) Stop-Service -Name $serviceName -Force -PassThru -WarningAction SilentlyContinue -ErrorAction SilentlyContinue }
    $stopJob = Start-Job -ScriptBlock $scriptBlock -ArgumentList $serviceName
    $completed = $stopJob |
        Wait-Job -Timeout $timeoutSeconds -WarningAction SilentlyContinue -ErrorAction SilentlyContinue

    if ($completed) {
        $jobResult = Receive-Job -Job $stopJob
        if ($jobResult.Status -eq "Stopped") {
            #Write-Host "서비스가 성공적으로 중지되었습니다."
            return $True
        } else {
            #Write-Host "서비스 중지에 실패했습니다."
            return $False
        }
    }
    else {
        #Write-Host "서비스 중지 작업이 시간 내에 완료되지 않았습니다."
        $stopJob | Remove-Job -Force
        return $False
    }
}
```

### 원격 서버 프로세스 강제 종료
```powershell
Invoke-Command -Session $sessions -ScriptBlock {
    Start-Process -FilePath "taskkill.exe" -ArgumentList "/F /IM 프로세스이름.exe" -NoNewWindow -Wait
}
```

### 원격 서버 프로세스 실행 결과
```powershell
output = Invoke-Command -Session $session -ScriptBlock {
    $hostOutput = @()

    # 파일 경로
    $stdOutPath = ".\stdout.txt"
    $stdErrPath = ".\stderr.txt"

    # 파일 삭제
    if (Test-Path $stdOutPath) { Remove-Item $stdOutPath -Force }
    if (Test-Path $stdErrPath) { Remove-Item $stdErrPath -Force }

    # $powershellFile: ps1 파일 경로
    Start-Process "powershell.exe" `
        -ArgumentList "-ExecutionPolicy ByPass -NoProfile -File `"$powershellFile`" -HostName `"$remoteServerName`" -HostIP `"$remoteServerIp`" " `
        -RedirectStandardOutput $stdOutPath `       # 표준 출력
        -RedirectStandardError $stdErrPath `        # 에러 출력
        -NoNewWindow `
        -Wait

        # 리다이렉트된 출력 읽기
        $stdOut = Get-Content $stdOutPath -Raw
        $stdErr = Get-Content $stdErrPath -Raw

        # 출력을 결과에 추가
        $hostOutput += $stdOut
        $hostOutput += $stdErr
    }

    return $hostOutput
}

Write-Host $output
```

### 파일 복사: 관리자 -ToSession-▶ 원격
```powershell
foreach ($session in $sessions) {
    Copy-Item -Path "Requesting Client 파일" -Destination "Responding Server 경로" -ToSession $session
}
```

### 파일 복사: 관리자 ◀-FromSession- 원격
```powershell
foreach ($session in $sessions) {
    Copy-Item -Path "Responding Server 파일" -Destination "Requesting Client 경로" -FromSession $session
}
```