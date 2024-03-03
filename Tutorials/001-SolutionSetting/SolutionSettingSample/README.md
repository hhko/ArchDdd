
dotnet new sln -o SolutionSettingSample
cd .\SolutionSettingSample

dotnet new classlib -o ./Src/CleanDdd.Domain
dotnet new classlib -o ./Src/CleanDdd.Application

dotnet new xunit -o ./Tests/CleanDdd.Tests.Unit
dotnet new xunit -o ./Tests/CleanDdd.Test.Integration

dotnet sln add (ls -r ./Src/**/*.csproj)
dotnet sln add (ls -r ./Tests/**/*.csproj)

# -------------------------------------------------
# 솔루션 설정 구성
# -------------------------------------------------

dotnet new .gitignore

dotnet --list-sdks
dotnet new global.json --sdk-version 8.0.x --roll-forward latestFeature

dotnet new nuget.config
"" > Directory.Build.props
"" > Directory.Packages.props

dotnet add .\Src\CleanDdd.Application\ package Serilog

# -------------------------------------------------
# 솔루션 빌드
# -------------------------------------------------
dotnet build
dotnet test