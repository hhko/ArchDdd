#

## 
```shell
dotnet new sln -o BuildPropsSetting
cd ./BuildPropsSetting
dotnet new global.json --sdk-version 8.0.102 --roll-forward latestPath

# 프로젝트 생성
dotnet new console -o BuildProps.Console
dotnet new classlib -o BuildProps.ClassLibrary

# 프로젝트 추가
dotnet sln add (ls -r **/*.csproj)

# props 파일 생성
"" > Directory.Build.props

# Directory.Build.props 파일 편집
# 개별 프로젝트 .csproj 파일 편집

dotnet build
```

## 빌드 옵션 중앙 관라히기
```xml
<Project>
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>
```
- `sln` 파일이 있는 경로에 `Directory.Build.props` 파일로 빌드 옵션을 중앙에서 관리합니다.

### Console 프로젝트
- 변경 **전**
  ```xml
  <Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
      <TargetFramework>net8.0</TargetFramework>
      <ImplicitUsings>enable</ImplicitUsings>
      <Nullable>enable</Nullable>
    </PropertyGroup>
  </Project>
  ```
- 변경 **후**
  ```xml
  <Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
      <OutputType>Exe</OutputType>
    </PropertyGroup>
  </Project>
  ```
  - 중앙에서 관리(`Directory.Build.props`)하고 있는 빌드 옵션을 제외한 것만 추가합니다.
    - `Sdk`
      ```xml
      <Project Sdk="Microsoft.NET.Sdk">
      ```
    - `OutputType`
      ```xml
      <OutputType>Exe</OutputType>
      ```

### ClassLibrary 프로젝트
- 변경 **전**
  ```xml
  <Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
      <TargetFramework>net8.0</TargetFramework>
      <ImplicitUsings>enable</ImplicitUsings>
      <Nullable>enable</Nullable>
    </PropertyGroup>
  </Project>
  ```
- 변경 **후**
  ```xml
  <Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
    </PropertyGroup>
  </Project>
  ```
  - 중앙에서 관리(`Directory.Build.props`)하고 있는 빌드 옵션을 제외한 것만 추가합니다.
    - `Sdk`
      ```xml
      <Project Sdk="Microsoft.NET.Sdk">
      ```
