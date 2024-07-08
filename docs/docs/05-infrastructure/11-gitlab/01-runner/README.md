
# GitLab Runner 설치

## 1. 관리자 권한 PowerShell 실행

## 2. GitLab Runner 다운로드
- [최신버전](https://gitlab.com/gitlab-org/gitlab-runner/-/releases)
- [v15.9.1](https://gitlab.com/gitlab-org/gitlab-runner/-/releases/v15.9.1/downloads/binaries/gitlab-runner-windows-amd64.zip)
- [v17.1.0](https://gitlab.com/gitlab-org/gitlab-runner/-/releases/v17.1.0/downloads/binaries/gitlab-runner-windows-amd64.zip): 2024-07-08(월) 기준 최신 버전

## 3. 폴더 생성 및 파일 복사
```shell
# 소스
C:\Downlaods\gitlab-runner-windows-amd64.exe

# 대상: 복사 장소
C:\Workspace\GitLab-Runner\gitlab-runner-windows-amd64.exe
```

## 4. Runner 버전 확인
```shell
.\gitlab-runner-windows-amd64.exe --version

#	Version:      	15.9.1
#	Git revision: 	d540b510
#	Git branch:   	15-9-stable
#	GO version:   	go1.18.10
#	Built:        		2023-02-20T21:03:12+0000
#	OS/Arch:      	windows/amd64
```

## 5. Runner 서버 등록
```shell
# --url: 저장소 URL
#     --url "https://www.foo.com"
# --registration-token: 저장소 등록 토큰값
#     --registration-token "-111111111111111"
# --description: 담당자 | 담당자 IP
#     --description "이순신 | 111.111.112.113"
# --tag-list: 운영체제, 프로젝트, ...
#     --tag-list "windows, helloworld"
# --shell: 관리자 권한 Shell(공백 제거)

.\gitlab-runner-windows-amd64.exe register `
   --non-interactive `
   --url "https://www.make.co.kr/" `
   --registration-token "-111111111111111" `
   --description "이순신 | 111.111.112.113" `
   --tag-list "windows, helloworld" `
   --executor "shell" `
   --shell "powershell"
```

## 6. Runner 설치
```shell
# whoami
#   desktop-xyz\운영체제_계정_이름

.\gitlab-runner-windows-amd64.exe install `
   --user .\운영체제_계정_이름 `
   --password 운영체제_계정_암호
```

## 7. Runner 시작
```shell
# 서비스 시작
.\gitlab-runner-windows-amd64.exe start

# 서비스 상태 확인
get-service gitlab-runner
   Status   Name               DisplayName
   ------   ----               -----------
   Running  gitlab-runner      gitlab-runner
```