```shell
# 솔루션 생성
dotnet new sln -n PackagesProps
dotnet new console -o PackagesProps.Console
dotnet new classlib -o PackagesProps.ClassLibrary
dotnet sln add (ls -r **/*.csproj)

# 패키지 중앙 관리를 위한 파일 생성
#   - nuget.config: 패키지 저장소
#   - Directory.Packages.props: 패키지 버전
dotnet new nuget.config
"<Project></Project>" > Directory.Packages.props

# 패키지 추가
#   - .csproj: 버전 정보가 제외된 PackageReference을 추가합니다.
#   - Directory.Packages.props: 패키지 버전 정보를 PackageVersion에 추가합니다.
dotnet add .\PackagesProps.Console\ package Serilog
```

## 패키지 중앙 관리
| 구분 | 파일 |
| --- | --- |
| `PackageVersion`      | Directory.Packages.props |
| `PackageReference`    | .csproj                   |


### Directory.Packages.props 파일
```xml
<Project>

  <PropertyGroup>
    <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
  </PropertyGroup>

  <ItemGroup>
    <PackageVersion Include="Serilog" Version="3.1.1" />
  </ItemGroup>

</Project>
```

### 프로젝트 csproj 파일
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <ItemGroup>
    <PackageReference Include="Serilog" />
  </ItemGroup>

</Project>
```

---------------------

dotnet

dotnet add .\PackagesProps.Console\ package MediatR
dotnet add .\PackagesProps.ClassLibrary\ package MediatR.Contracts


<Project>
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>

ManagePackageVersionsCentrally

<Project>

  <PropertyGroup>
    <ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>
  </PropertyGroup>

  <ItemGroup>
    <PackageVersion Include="MediatR" Version="12.2.0" />
    <PackageVersion Include="MediatR.Contracts" Version="2.0.1" />
  </ItemGroup>

</Project>

PackageVersion

<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <PackageReference Include="MediatR" />
  </ItemGroup>
</Project>


PackageVersion, PackageReference

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageRestore>
    <add key="enabled" value="True" />
    <add key="automatic" value="True" />
  </packageRestore>

  <packageSources>
    <clear />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>

  <packageSourceMapping>
    <packageSource key="nuget.org">
      <package pattern="*" />
    </packageSource>
  </packageSourceMapping>

  <bindingRedirects>
    <add key="skip" value="False" />
  </bindingRedirects>

  <packageManagement>
    <add key="format" value="0" />
    <add key="disabled" value="False" />
  </packageManagement>
</configuration>


nuget.config
warning NU1507: There are 2 package sources defined in your configuration. When using central package management, please map your package sources with package source mapping (https://aka.ms/nuget-package-source-mapping) or specify a single package source.


Directory.Build.props -> ManagePackageVersionsCentrally
warning NU1701: 프로젝트 대상 프레임워크 'net8.0' 대신 '.NETFramework,Version=v4.6.1, .NETFramework,Version=v4.6.2, .NETFramework,Version