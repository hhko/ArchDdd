# CLEAN ARCHITECTURE and DOMAIN-DRIVEN DESIGN

[![ArchDdd Build](https://github.com/hhko/ArchDdd/actions/workflows/build.yml/badge.svg)](https://github.com/hhko/ArchDdd/actions/workflows/build.yml)
[![codecov](https://codecov.io/gh/hhko/ArchDdd/graph/badge.svg?token=VK8HUZTA7K)](https://codecov.io/gh/hhko/ArchDdd)

> 배움은 **설렘**이다.  
> 배움은 **겸손**이다.  
> 배움은 **이타심**이다.

## 개요

지속 가능한 코드

> **회귀 버그(Regression Bug)**
> - 기존에 잘 작동하던 기능이 새로운 코드 변경이나 업데이트로 인해 갑자기 오작동하게 되는 문제를 말합니다.
> - **회귀 버그는 지속 가능한 코드의 길에서 마주치는 가장 큰 골칫거리입니다.**
>   - `개발`
>     - 부수 효과(Side Effect)
>     - 성능
>   - `운영`
>     - 재배포 속도
>     - 장애 사전 예측 속도
>     - 장애 사후 복구 속도
>     - 표준 운영 절차 문서(SOP, Standard operating procedure)

### 배경

- **개발은 글쓰기와 같습니다.**  
  개발자는 프로그래밍 언어로 이야기를 코드로 써 내려갑니다.
- **솔루션 탐색기의 폴더 구성은 책의 목차와 같습니다.**  
  각 폴더(레이어)는 책의 챕터처럼 관련 내용(관심사)을 담고 있습니다.
- **목차를 따라 코드를 읽으면 비즈니스의 흐름을 이해할 수 있습니다.**   
  코드는 비즈니스의 작동 방식을 설명하는 상세한 설명서와 같기 때문입니다.

### 목표
- 지속 가능한 코드: 코드가 문서입니다.
  - **`비즈니스 이해  --{글 쓰기}--> 코드`**: 비즈니스를 이해하면 코드를 배치할 수 있습니다.
  - **`비즈니스 이해 <--{글 읽기}--  코드`**: 코드를 읽으면 비즈니스를 이해할 수 있습니다.

<br/>

## 아키텍처 이해
### 아키텍처 중요성
건축업자가 프로그래머의 프로그램 작성 방식에 따라 건물을 짓는다면 가장 먼저 도착하는 딱따구리가 문명을 파괴할 것입니다.  
If builders built buildings the way programmers wrote programs, then the first woodpecker that came along would destroy civilization. - Gerald Weinberg
- Architecting is a series of **trade-offs**.
- The architecture should scream **the intent of the system**.

### 아키텍처 정의
![](./docs/docs/03-design/01-architecture/01-overview/img/ArchitectureDefinition.png)
※ 출처: [Making Architecture Matter, 소프트웨어 아키텍처의 중요성](https://www.youtube.com/watch?v=4E1BHTvhB7Y)  

- 아키텍처는 제품의 지속 가능한 성장을 주도하는 중요한 모든 것(`The important stuff whatever that is`)입니다.
  - 예. 기능을 추가할 때?
    - 관련 코드의 시작 지점을 찾는 것은 쉽지만, 그 기능이 미치는 영향을 끝까지 파악하는 것은 어렵습니다.
    - **끝 지정(부수 효과, Side Effect)를** 모두 인지하는 것은 쉽지 않습니다.

### 아키텍처 원칙
![](./docs/docs/03-design/01-architecture/01-overview/img/ArchitectureSoC.png)

- 관심사의 분리(SoC, Separation of Concerns)
  - 아키텍처 수준에서는 **비즈니스와 기술적인 관심사**를 명확히 구분합니다.
  - 비즈니스와 관련된 부분은 비즈니스 영역에서, 기술적인 부분은 기술 영역에서 각각 다루어지도록 하는 것입니다.
  - 기술적 구현에 의존하지 않고도 비즈니스만을 집중하여 테스트하고 개선할 수 있습니다.

### 아키텍처 범주
![](./docs/docs/03-design/01-architecture/01-overview/img/ArchitectureCategory.png)
※ 출처: [Making old applications new again](https://sellingsimplifiedinsights.com/asset/app-development/ASSET_co-modernization-whitepaper-inc0460201-122016kata-v1-en_1511772094768.pdf)

```
Application Architecture
  ├─ Backend
  │   ├─ Monolithic Architecture
  │   ├─ Modular Monolithic Architecture
  │   ├─ N-tier Architecture
  │   └─ Microservices Architecture
  │       ├─ Inner Architecture
  │       │    └─ Layered Architecture
  │       │         ├─ Hexagonal Architecture
  │       │         ├─ Onion Architecture
  │       │         ├─ Clean Architecture
  │       │         └─ Vertical Slice Architecture
  │       │
  │       └─ Outer Architecture
  │            └─ 외부 시스템 구성 아키텍처: 예. CNCF Landscape
  │
  └─ Frontend
      └─ Inner Architecture
          └─ Layered Architecture
               ├─ Hexagonal Architecture
               ├─ Onion Architecture
               ├─ Clean Architecture
               ├─ Vertical Slice Architecture
               └─ + UI 특화 Architecture: 예. MVVM, ...
```
- 백엔드와 프론트엔드 대부분 **관심사를 계층(Layer)로 관리하는** 계층형 아키텍처 기반의 진화된 아키텍처를 사용합니다.

### 아키텍처 역사
![](./docs/docs/03-design/01-architecture/01-overview/img/ArchitectureHistory.png)

- 1992년부터 아키텍처 수준에서는 관심사를 계층(Layer)으로 나누고, 객체 수준에서는 관심사를 엔티티(Entity)로 관리하는 방법이 제시되었습니다.
- 즉, 시스템의 큰 구조는 여러 계층으로 나누어 관리하고, 각 계층 내의 세부 사항은 엔티티로 나누어 관리하는 방식입니다.

### 아키텍처 역할
![](./docs/docs/03-design/01-architecture/01-overview/img/ArchitectureDevOps.png)

- 아키텍처는 제품의 **선순환(Good Cycle)** 성장의 시작점입니다.

<br/>

## 아키텍처 구현

### 솔루션 기본 구성
```
{솔루션}
  ├─ README.md
  ├─ {솔루션}.sln
  │
  │  // 형상관리
  ├─ .gitignore                         # Git 형상관리 제외 대상
  ├─ .gitattributes                     # Git 형상관리 파일 처리
  ├─ .dockerignore                      # Dockerfile 빌드 제외 대상
  │
  │  // .NET 설정
  ├─ global.json                        # 빌드 버전
  ├─ nuget.config                       # NuGet 저장소
  ├─ dotnet-tools.json                  # .NET 로컬 도구
  ├─ Directory.Build.props              # 빌드 옵션
  ├─ Directory.Packages.props           # 패키지 버전
  ├─ .editorconfig                      # 코드 컨벤션
  │
  │  // Docker
  ├─ Dockerfile                         # 도커 파일
  ├─ docker-compose.yml                 # 도커 컴포즈
  ├─ docker-compose.override.yml        # 도커 컴포즈
  ├─ launchSettings.json                # 도커 컴포즈 구성
  ├─ docker-compose.dcproj              # 도커 컴포즈 프로젝트
```
#### 형상관리
1. `.gitignore`: Git 형상 관리에서 제외할 파일과 폴더를 지정하는 파일입니다.
   ```shell
   dotnet new gitignore
   ```
   - [Verify Received and Verified files](https://github.com/VerifyTests/Verify?tab=readme-ov-file#includesexcludes)
     ```
     *.received.*
     ```
1. `.gitattributes`: Git 형상 관리에서 파일의 속성과 처리 방식을 지정하는 파일입니다.
   - [Verify Received and Verified files, Text file settings](https://github.com/VerifyTests/Verify?tab=readme-ov-file#text-file-settings)
     ```
     *.verified.txt text eol=lf working-tree-encoding=UTF-8
     *.verified.xml text eol=lf working-tree-encoding=UTF-8
     *.verified.json text eol=lf working-tree-encoding=UTF-8
     ```
     - text: .verified.txt, .verified.xml, .verified.json 확장자를 가진 파일들이 모두 텍스트 파일로 처리되며,
     - eol=lf: 체크아웃 시 개행 문자가 LF(Line Feed)로 설정되고,
     - working-tree-encoding=UTF-8: UTF-8 인코딩이 사용되도록 합니다.
1. `.dockerignore`: Docker가 이미지를 만들 때 제외할 파일과 폴더를 지정하는 파일입니다.

#### .NET 설정
1. `global.json`: .NET SDK 버전을 설정하는 파일입니다.
   - 버전 형식: "[global.json 개요](https://learn.microsoft.com/ko-kr/dotnet/core/tools/global-json)", 지정된 버전에서부터 상위 버전(rollForward)
     ```
     x.y.znn
     ```
     - x: major
     - y: minor
     - z: feature, 0 ~ 9
     - n: patch, 0 ~ 99
   - 예제
     - `latestFeature`: 8.0.302 이상 8.0.xxx 버전(예: 8.0.303 또는 8.0.402)
       ```json
       {
         "sdk": {
           "version": "8.0.302",
           "rollForward": "latestFeature"
         }
       }
       ```
     - `latestPatch`: 8.0.102 이상 8.0.1xx 버전(예: 8.0.103 또는 8.0.199)
       ```json
       {
         "sdk": {
           "version": "8.0.102",
           "rollForward": "latestPatch"
         }
       }
       ```
   - .NET SDK 버전 명령
     - `dotnet --info`: 현재 경로의 .NET SDK 정보를 출력합니다.
       ```shell
       dotnet --info
          .NET SDK:                      # global.json으로 결정된 .NET SDK 버전
            Version:           8.0.100
            Commit:            57efcf1350
            Workload version:  8.0.100-manifests.aea97431

          Host:                          # 호스트에 설치된 .NET Runtime 최진 버전
            Version:      8.0.7
            Architecture: x64
            Commit:       2aade6beb0

          .NET SDKs installed:           # 호스트에 설치된 .NET SDK 버전 목록
            5.0.301 [C:\Program Files\dotnet\sdk]
            6.0.100 [C:\Program Files\dotnet\sdk]
            7.0.100 [C:\Program Files\dotnet\sdk]
            8.0.100 [C:\Program Files\dotnet\sdk]
            8.0.303 [C:\Program Files\dotnet\sdk]

          global.json file:              # 인지된 global.json
            C:\Workspace\Helloworld\global.json
       ```
     - `dotnet --version`: 현재 경로의 global.json으로 결정된 .NET SDK 버전을 출력합니다.
       ```shell
       dotnet --version
          8.0.100                        # global.json으로 결정된 .NET SDK 버전
       ```
1. `nuget.config`: NuGet 패키지 관리에서 패키지 소스, 설정, 자격 증명 등을 구성하는 파일입니다.
   ```
   dotnet new nuget.config
   ```
   ```xml
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
   ```
1. `Directory.Build.props`: 여러 프로젝트에 공통 빌드 속성을 지정하는 파일입니다.
    ```
    {솔루션}
      ├─ {솔루션}.sln
      ├─ Directory.Build.props       (1)
      │
      ├─ Src
      │   ├─ {프로젝트1}
      │   └─ {프로젝트1}
      │
      └─ Tests
          ├─ Directory.Build.props   (2)
          ├─ {프로젝트1}
          └─ {프로젝트1}
    ```
    - (1), Directory.Build.props
      ```
      <Project>

        <PropertyGroup>
          <TargetFramework>net8.0</TargetFramework>
          <ImplicitUsings>enable</ImplicitUsings>
          <Nullable>enable</Nullable>

          <!-- 경고를 Error로 취급합니다 -->
          <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
        </PropertyGroup>

      </Project>
      ```
    - (2), Directory.Build.props
      ```xml
      <Project>

        <!-- 상위 Directory.Build.props 파일 지정-->
        <Import Project="$([MSBuild]::GetPathOfFileAbove('Directory.Build.props', '$(MSBuildThisFileDirectory)../'))" />

        <!-- 테스트 프로젝트 공통 속성 -->
        <PropertyGroup>
          <IsPackable>false</IsPackable>
          <IsTestProject>true</IsTestProject>
        </PropertyGroup>

        <!-- 솔루션 탐색기에서 TestResults 폴더 제외 -->
        <ItemGroup>
          <None Remove="TestResults\**" />
        </ItemGroup>

        <!-- xunit.runner.json 설정 -->
        <ItemGroup>
          <Content Include="xunit.runner.json" CopyToOutputDirectory="PreserveNewest" />
        </ItemGroup>

      </Project>
      ```

1. `Directory.Packages.props`: 여러 프로젝트에 공통 패키지 버전을 지정하는 파일입니다.
1.`.editorconfig`
1. `dotnet-tools.json`
   - %USERPROFILE%\.dotnet\tools




Error	CS7022
  The entry point of the program is global code; ignoring 'AutoGeneratedProgram.Main(string[])' entry point.


<br/>

## 개발 환경
- .NET 8.x
- Visual Studio Code
  - C#
  - ~~C# Dev Kit~~
  - Code Spell Checker
  - Git Graph
  - Paste Image
  - Trailing Spaces
  - Markdown Preview Enhanced
  - VSCode Progressive Increment
  - ~~GitHub Actions~~
  - ~~Codecov YAML Validator~~
  - REST Client

### 패키지
- `Ulid`: GUID
- `Quartz`: 백그라운드 작업
- `MediatR`: Mediator 패턴
- `EF Core`: ORM
- `OpenTelemetry`: Telemetry
- `FluentValidation`: 유효성 검사 선언형

### 테스트
- `xunit`: 단위 테스트
- `Verify.Xunit`: Snapshot 테스트
- `FluentAssertions`: Assert 선언형
- `NetArchTest.Rules`: 아키텍처 테스트
- `coverlet.collector`: 코드 커버리지
- `Xunit.DependencyInjection`: xUnit 의존성
- `Microsoft.AspNetCore.Mvc.Testing`: 통합 테스트

### 문서
- `docusaurus`

### 도구
- `verify.tool`
