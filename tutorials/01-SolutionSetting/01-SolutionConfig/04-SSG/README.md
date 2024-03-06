# Static Site Generator 문서화하기

## 설치 요구사항
- [docfx v2.75.3](https://github.com/dotnet/docfx?tab=readme-ov-file#prerequisites)
  - Install Visual Studio 2022 (Community or higher) and make sure you have the latest updates.
  - Install .NET SDK 6.x, 7.x and 8.x.
  - Install NodeJS (20.x.x).

```shell
dotnet new nuget.config

# docfx 설치하기
#   https://www.nuget.org/packages/docfx
#   dotnet tool install --global docfx --version 2.75.3
dotnet tool install -g docfx
dotnet tool list -g

패키지 ID          버전            명령
----------------------------------------------
docfx              2.75.3        docfx


# 사이트 생성
docfx init -y
#   docs
#   docfx.json
#   index.md
#   toc.yml

# 빌드
docfx docfx.json --serve
docfx docfx.json
```

- 솔루션 통합: C#
- 솔루션 통합: C# REST API
- 한국어 검색: 메뉴
- 한국어 검색: 내용
- 컨테이너 배포
- GitHub Actions 통합

```
Win32Exception: An error occurred trying to start process 'C:\Users\{계정}\.dotnet\tools\.store\docfx\2.75.3\docfx\2.75.3\tools\.playwright\node\win32_x64\playwright.cmd' with working directory
'{docfx.json 파일이 있는 경로}'. 액세스가 거부되었습니다.
```