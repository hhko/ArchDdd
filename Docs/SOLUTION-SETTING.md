```shell
# -------------------------------------------------
# 솔루션 구성
# -------------------------------------------------

# 솔루션 생성
dotnet new sln -o CleanDdd
cd ./CleanDdd

# 프로젝트 생성
dotnet new classlib -o ./Src/CleanDdd.Domain
dotnet new classlib -o ./Src/CleanDdd.Application

# 테스트 프로젝트 생성
dotnet new xunit -o ./Tests/CleanDdd.Tests.Unit
dotnet new xunit -o ./Tests/CleanDdd.Test.Integration

# 프로젝트 추가
dotnet sln add (ls -r ./Src/**/*.csproj)
dotnet sln add (ls -r ./Tests/**/*.csproj)

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
```
dotnet tool install -g dotnet-format
```