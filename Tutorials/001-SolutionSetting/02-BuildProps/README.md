# 빌드 중앙 관라히기
> `Directory.Build.props` 파일은 프로젝트의 빌드 설정을 중앙에서 관리합니다.

```shell
# 솔루션 생성
dotnet new sln -o BuildProps
cd ./BuildProps

# .NET SDK 버전 지정
dotnet --list-sdks
dotnet new global.json --sdk-version 8.0.102 --roll-forward latestPath

# 프로젝트 생성
dotnet new console -o BuildProps.Console
dotnet new classlib -o BuildProps.ClassLibrary

# 프로젝트 추가
dotnet sln add (ls -r **/*.csproj)

# 빌드 중앙 관리
"" > Directory.Build.props
# - Directory.Build.props 파일 편집
# - 프로젝트 .csproj 파일 편집

# 빌드
dotnet build
```

## Directory.Build.props 파일
```xml
<Project>
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>
```
- `Directory.Build.props`에 모든 프로젝트에 적용할 빌드 옵션을 정의합니다.

### Console .csproj 프로젝트 파일
- 변경 **전**
  ```xml
  <Project Sdk="Microsoft.NET.Sdk">               <!-- 개별 속성: Sdk -->
    <PropertyGroup>
      <OutputType>Exe</OutputType>                <!-- 개별 속성: OutputType -->
      <TargetFramework>net8.0</TargetFramework>
      <ImplicitUsings>enable</ImplicitUsings>
      <Nullable>enable</Nullable>
    </PropertyGroup>
  </Project>
  ```
- 변경 **후**: `Directory.Build.props`에 정의안된 개별 속성만 정의합니다.
  ```xml
  <Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
      <OutputType>Exe</OutputType>
    </PropertyGroup>
  </Project>
  ```

### ClassLibrary .csproj 프로젝트 파일
- 변경 **전**
  ```xml
  <Project Sdk="Microsoft.NET.Sdk">               <!-- Sdk 속성 개별 -->
    <PropertyGroup>
      <TargetFramework>net8.0</TargetFramework>
      <ImplicitUsings>enable</ImplicitUsings>
      <Nullable>enable</Nullable>
    </PropertyGroup>
  </Project>
  ```
- 변경 **후**: `Directory.Build.props`에 정의안된 개별 속성만 정의합니다.
  ```xml
  <Project Sdk="Microsoft.NET.Sdk">
  </Project>
  ```