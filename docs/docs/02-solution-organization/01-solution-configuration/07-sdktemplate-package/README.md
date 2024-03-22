---
sidebar_position: 7
---

# SDK 템플릿 패키지 만들기

## .nuspec 파일
```xml
<?xml version="1.0" encoding="utf-8"?>
<package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
  <metadata>
    <id>CleanDdd.Template</id>
    <title>ASP.NET Clean Architecture with DDD Solution</title>
    <version>1.0.0-alpha.1</version>
    <authors>고형호</authors>
    <description>.NET 8 Clean Architecture with DDD Solution Template</description>
    <language>en-US</language>
    <license type="expression">MIT</license>
    <!--
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    -->
    <projectUrl>https://github.com/hhko/CleanDdd</projectUrl>
    <repository type="git" url="https://github.com/hhko/CleanDdd" branch="main" />
    <!--
    <releaseNotes>
      Minor updates to dependencies. Fixed Releases on GitHub.
    </releaseNotes>
    -->
    <packageTypes>
      <packageType name="Template" />
    </packageTypes>
    <tags>clean-architecture ddd domain-driven-design architecture asp-net-core template</tags>
    <!--
    <icon>./content/icon.png</icon>
    -->
    <readme>README.md</readme>
  </metadata>
  <files>
    <!--
      **\.template.config\**;
      템플릿 정의를 위해서 .template.config 폴더는 반드시 포함시켜야 한다.
    -->
    <file src=".\**" target="content" exclude=".\nuget.exe;**\bin\**;**\obj\**;**\.git\**;**\.github\**;**\*.user;**\.vs\**;**\.vscode\**;**\.gitignore;**\Tutorials\**" />
    <file src="README.md" />
  </files>
</package>
```

## 패키지 명령
```shell
# 패키지 nupkg 파일 생성하기
#   - nuget.exe 최신 버전: https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
#   - -NoDefaultExcludes:
#       .nupkg' 파일이 패키지에 추가되지 않았습니다.
#       '.'으로 시작하거나 '.nupkg'로 끝나는 파일 및 폴더는 기본적으로 제외됩니다.
#       이 파일을 포함하려면 명령줄에서 -NoDefaultExcludes를 사용하세요.
.\nuget.exe pack .\CleanDdd.nuspec -NoDefaultExcludes

# 패키지 설치
dotnet new install .\CleanDdd.Template.1.0.0-alpha.1.nupkg 

# 패키지 제거
dotnet new uninstall CleanDdd.Template

# 패키지 세부 정보
dotnet new details CleanDdd.Template
```

## TODO
### 폴더 유지 못함?

### XML 멀티 라인
```xml
<file src=".\**" target="content" exclude=".\nuget.exe;**\.template.config\**;**\bin\**;**\obj\**;**\.git\**;**\.github\**;**\*.user;**\.vs\**;**\.vscode\**;**\.gitignore;**\Tutorials\**" />
```

### Reset-Templates
- https://github.com/sayedihashimi/template-sample/blob/main/build-nuget.ps1
- 설치한 nupkg 파일 삭제하기

```
오류 :파일 C:\Users\고형호\.templateengine\packages\CleanDdd.Template.1.0.0-alpha.1.nupkg이(가) 이미 있습니다.
```

```powershell
$scriptDir = split-path -parent $MyInvocation.MyCommand.Definition
$srcDir = (Join-Path -path $scriptDir src)
# nuget.exe needs to be on the path or aliased
function Reset-Templates{
    [cmdletbinding()]
    param(
        [string]$templateEngineUserDir = (join-path -Path $env:USERPROFILE -ChildPath .templateengine)
    )
    process{
        'resetting dotnet new templates. folder: "{0}"' -f $templateEngineUserDir | Write-host
        get-childitem -path $templateEngineUserDir -directory | Select-Object -ExpandProperty FullName | remove-item -recurse
        &dotnet new --debug:reinit
    }
}
function Clean(){
    [cmdletbinding()]
    param(
        [string]$rootFolder = $scriptDir
    )
    process{
        'clean started, rootFolder "{0}"' -f $rootFolder | write-host
        # delete folders that should not be included in the nuget package
        Get-ChildItem -path $rootFolder -include bin,obj,nupkg -Recurse -Directory | Select-Object -ExpandProperty FullName | Remove-item -recurse
    }
}

# start script
Clean

# create nuget package
$outputpath = Join-Path $scriptDir nupkg
$pathtonuspec = Join-Path $srcDir SayedHa.Template.NetCoreTool.nuspec
if(Test-Path $pathtonuspec){
    nuget.exe pack $pathtonuspec -OutputDirectory $outputpath
}
else{
    'ERROR: nuspec file not found at {0}' -f $pathtonuspec | Write-Error
    return
}

$pathtonupkg = join-path $scriptDir nupkg/SayedHa.Template.NetCoreTool.nuspec.1.0.1.nupkg
# install nuget package using dotnet new --install
if(test-path $pathtonupkg){   
    Reset-Templates
    'installing template with command "dotnet new --install {0}"' -f $pathtonupkg | write-host
    &dotnet new --install $pathtonupkg
}
else{
    'Not installing template because it was not found at "{0}"' -f $pathtonupkg | Write-Error
}
```

## 참고 자료
- 패키지 버전: https://learn.microsoft.com/en-us/nuget/concepts/package-versioning?tabs=semver20sort
- nuspec: https://learn.microsoft.com/en-us/nuget/reference/nuspec
