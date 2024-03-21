---
sidebar_position: 1
---

# 솔루션 생성

## 솔루션 프로젝트 생성
```shell
# 솔루션 파일 생성
dotnet new sln -o CleanDdd
cd ./CleanDdd

# 프로젝트 생성
dotnet new classlib -o ./src/CleanDdd.Domain
dotnet new classlib -o ./src/CleanDdd.Application
dotnet new classlib -o ./src/CleanDdd.Adapters.Presentation
dotnet new classlib -o ./src/CleanDdd.Adapters.Persistence
dotnet new classlib -o ./src/CleanDdd.Adapters.Infrastructure

# 테스트 프로젝트 생성
dotnet new xunit -o ./tests/CleanDdd.Tests.Unit
dotnet new xunit -o ./tests/CleanDdd.Test.Integration

# 프로젝트 추가
dotnet sln add (ls -r ./src/**/*.csproj)
dotnet sln add (ls -r ./tests/**/*.csproj)
```

## 솔루션 빌드 설정
```shell
# .gitignore
dotnet new .gitignore

# global.json
dotnet --list-sdks
dotnet new global.json --sdk-version 8.0.x --roll-forward latestFeature

# 빌드 중앙 관리: "" > Directory.Build.props
dotnet new buildprops
#   - Directory.Build.props 파일 편집
#   - 프로젝트 .csproj 파일 편집

# 패키지 중앙 관리
dotnet new nuget.config
"" > Directory.Packages.props
#   - Directory.Packages.props 파일 편집
#   - 프로젝트 .csproj 파일 편집
```
- `.gitignore`
- `global.json`
- `Directory.Build.props`
- `Directory.Packages.props`
- `nuget.config`

## 솔루션 빌드
```shell
dotnet build
dotnet test
```