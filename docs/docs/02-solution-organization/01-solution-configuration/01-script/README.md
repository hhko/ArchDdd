---
sidebar_position: 1
---

# 솔루션 구성 Script

## .NET 도구 설치
```shell
dotnet tool install --global dotnet-coverage --version 17.9.6
dotnet tool install --global dotnet-reportgenerator-globaltool --version 5.2.0
dotnet tool install --global dotnet-format --version 5.1.250801
```

## 솔루션 생성
```shell
# 솔루션 파일 생성
dotnet new sln -o ArchDdd
cd ./ArchDdd

# 프로젝트 생성
dotnet new classlib -o ./src/ArchDdd.Domain
dotnet new classlib -o ./src/ArchDdd.Application
dotnet new classlib -o ./src/ArchDdd.Adapters.Presentation
dotnet new classlib -o ./src/ArchDdd.Adapters.Persistence
dotnet new classlib -o ./src/ArchDdd.Adapters.Infrastructure

# 테스트 프로젝트 생성
dotnet new xunit -o ./tests/ArchDdd.Tests.Unit
dotnet new xunit -o ./tests/ArchDdd.Test.Integration

# 프로젝트 추가
dotnet sln add (ls -r ./src/**/*.csproj)
dotnet sln add (ls -r ./tests/**/*.csproj)
```

## 솔루션 설정
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

## 문서 사이트 구축
```shell
node -v

npx --yes create-docusaurus@3.1.1 site classic --typescript

cd sidte
npm run build
npm run serve
```