# 패키지 중앙 관리하기
> `Directory.Packages.props` 파일은 프로젝트의 패키지 설정을 중앙에서 관리합니다.

```shell
# 솔루션 생성
dotnet new sln -O PackagesProps
cd ./PackagesProps

# .NET SDK 버전 지정
dotnet --list-sdks
dotnet new global.json --sdk-version 8.0.102 --roll-forward latestPath

# 프로젝트 생성
dotnet new console -o PackagesProps.Console
dotnet new classlib -o PackagesProps.ClassLibrary

# 프로젝트 추가
dotnet sln add (ls -r **/*.csproj)

# 빌드 중앙 관리
"" > Directory.Build.props
# - Directory.Build.props 파일 편집
# - 프로젝트 .csproj 파일 편집

# 패키지 중앙 관리
dotnet new nuget.config
"" > Directory.Packages.props
# - nuget.config 파일 편집
# - Directory.Packages.props 파일 편집

# 패키지 추가
dotnet add .\PackagesProps.Console\ package Serilog

# 빌드
dotnet build
```

## nuget.config 파일
```
warning NU1507:

There are 2 package sources defined in your configuration.
When using central package management,
  please map your package sources with package source mapping
  (https://aka.ms/nuget-package-source-mapping)
  or specify a single package source.
```
- 패키지 소스가 다수일 때 `NU1507` 경고가 발생합니다.
- `nuget.config` 파일을 이용하여 패키지를 명시적으로 지정합니다.

## Directory.Packages.props 파일
| 구분 | 파일 |
| --- | --- |
| `PackageVersion`      | Directory.Packages.props |
| `PackageReference`    | .csproj                   |

- `Directory.Packages.props` 파일에 패키지 중앙 관리 활성화를 정의합니다.

```xml
<Project>

  <PropertyGroup>
    <!-- 패키지 중앙 관리 활성화하기 -->
    <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
  </PropertyGroup>
</Project>
```

## 패키지 중앙 관리 적용하기
```shell
dotnet add .\PackagesProps.Console\ package Serilog
```
- 프로젝트에 `Serilog` 패키지를 추가하면 `Directory.Packages.props` 파일에는 버전이, 프로젝트 파일에는 패키지 정보만 추가됩니다.

### Directory.Packages.props 파일
```xml
<Project>

  <PropertyGroup>
    <!-- 
    패키지 중앙 관리 활성화하기: warning NU1701
    -->
    <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
  </PropertyGroup>

  <!-- 패키지 버전 중앙 관리: PackageVersion -->
  <ItemGroup>
    <PackageVersion Include="Serilog" Version="3.1.1" />
  </ItemGroup>

</Project>
```
```
프로젝트 대상 프레임워크 'net8.0' 대신 '.NETFramework,Version=v4.6.1, .NETFramework,Version=v4.6.2, .NETFramework,Version
```
- `ManagePackageVersionsCentrally`을 지정하지 않으면 관련 에러가 발생합니다.

### PackagesProps.Console csproj 프로젝트 파일
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <!-- 패키지 버전 제외 -->
  <ItemGroup>
    <PackageReference Include="Serilog" />
  </ItemGroup>

</Project>
```

## TODO
- TODO 옵션: `#if (!UseApiOnly)`
- TODO 소스: https://github.com/jasontaylordev/CleanArchitecture/blob/main/Directory.Packages.props

## 참고 자료
- [Introducing Central Package Management](https://devblogs.microsoft.com/nuget/introducing-central-package-management/)