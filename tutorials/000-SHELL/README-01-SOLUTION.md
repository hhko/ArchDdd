```shell
# docfx
dotnet tool install -g docfx --version 2.75.3

# dotnet-format
dotnet tool install -g dotnet-format --version 5.1.250801
```

```shell
# -------------------------------------------------
# 솔루션 구성
# -------------------------------------------------

# 솔루션 생성
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

# -------------------------------------------------
# 솔루션 설정 구성
# -------------------------------------------------

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

# -------------------------------------------------
# 솔루션 빌드
# -------------------------------------------------
dotnet build
dotnet test
```

```shell
# docfx 도구 설치
dotnet tool install -g docfx --version 2.75.3

# 사이트 생성
docfx init -y -o ./site
cd ./site

# 빌드: http://localhost:8080
docfx docfx.json --serve
docfx docfx.json --serve -p 8080
docfx docfx.json
docfx
```

```
dotnet tool install -g dotnet-format
```