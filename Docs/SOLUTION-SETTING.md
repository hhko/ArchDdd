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

# 테스트 프로젝트 추가
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
dotnet new global.json --sdk-version 8.0.102 --roll-forward latestPatch

# nuget.org
dotnet new nuget.config

# Directory.*.props
"<Project></Project>" > Directory.Build.props
"<Project></Project>" > Directory.Packages.props

# Directory.Packages.props 파일 편집
#   - .csproj 파일에서 패키지 버전을 삭제한다.
#   - Directory.Packages.props 파일에 PackageVersion 패키지 버전을 추가한다.

# -------------------------------------------------
# 솔루션 빌드
# -------------------------------------------------
dotnet build
dotnet test
```
```
dotnet tool install -g dotnet-format
```