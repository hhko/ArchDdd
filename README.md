# Architecture with Domain-Driven Design
[![ArchDdd Build](https://github.com/hhko/ArchDdd/actions/workflows/build.yml/badge.svg)](https://github.com/hhko/ArchDdd/actions/workflows/build.yml)
[![codecov](https://codecov.io/gh/hhko/ArchDdd/graph/badge.svg?token=VK8HUZTA7K)](https://codecov.io/gh/hhko/ArchDdd)

> 배움은 **설렘**이다.  
> 배움은 **겸손**이다.  
> 배움은 **이타심**이다.

건축업자가 프로그래머의 프로그램 작성 방식에 따라 건물을 짓는다면 가장 먼저 도착하는 딱따구리가 문명을 파괴할 것입니다.  
If builders built buildings the way programmers wrote programs, then the first woodpecker that came along would destroy civilization. - Gerald Weinberg
- Architecting is a series of **trade-offs**.
- The architecture should scream **the intent of the system**.

## 아키텍처 이해
**Separation of Concerns(SoC)은** 중요한 아키텍처 원칙 중 하나입니다. 이는 **관심사**를 분리함으로써 코드를 더 잘 관리할 수 있다는 개념입니다. 아키텍처 수준의 관심사는 각각의 **레이어**로 나눠져 관리됩니다.
> **아키텍처 패턴의 역사**는 **관심사**를 관리하기 위한 **레이어 배치의 역사**입니다.


- Layered Architecture
- Hexagonal Architecture
- Onion Architecture
- Clean Architecture
- ...

![ArchitecturePatternHistory](./docs/docs/01-architecture/img/ArchitecturePatternHistor.png)

## 목차
### 아키텍처
### 솔루션 구성
- 솔루션 설정
  - [솔루션 구성 Script](./docs/docs/02-solution-organization/01-solution-configuration/01-script/README.md)
  - [.NET SDK 버전 지정하기](./docs/docs/02-solution-organization/01-solution-configuration/02-sdkversion/README.md)
  - [중앙 빌드 관라히기](./docs/docs/02-solution-organization/01-solution-configuration/03-buildprops/README.md)
  - [중앙 패키지 관리하기](./docs/docs/02-solution-organization/01-solution-configuration/04-packagesprops/README.md)
  - [패키지 Bulk 추가/제거하기](./docs/docs/02-solution-organization/01-solution-configuration/05-packagesbulk/README.md)
  - [SDK 템플릿 만들기](./docs/docs/02-solution-organization/01-solution-configuration/06-sdktemplate/README.md)
  - [SDK 템플릿 패키지 만들기](./docs/docs/02-solution-organization/01-solution-configuration/07-sdktemplate-package/README.md)
  - [문서 사이트 구축하기](./docs/docs/02-solution-organization/01-solution-configuration/08-docusaurus/README.md)
- 솔루션 DevOps

## 폴더 구성
### src 폴더 구성
![](./docs/docs/01-architecture/img/2024-03-10-15-06-17.png)

```
T1.T2{.T3}

src
  ├─ ArchDdd.Domain                   : Domain
  ├─ ArchDdd.Application              : Application
  ├─ ArchDdd.Adapters.Infrastructure  : Adapter
  ├─ ArchDdd.Adapters.Persistence     : Adapter
  ├─ ArchDdd.Adapters.Presentation    : Adapter
  └─ ArchDdd.Host                     : Host
```
- `T1`: Solution 이름
- `T2`: Layer 이름
  - `Domain` ⊂ `Application` ⊂ `Adapter` ⊂ `Host`
- `T3`: Feature 이름(생략 가능)
  - Presentation, Infrastructure, Persistence, ...

### tests 폴더 구성
![](./docs/docs/01-architecture/img/2024-03-10-15-25-32.png)

```
T1.T2.T3

tests
  ├─ ArchDdd.Tests.Integration        : Test
  └─ ArchDdd.Tests.Unit               : Test
```
- `T1`: Solution 이름
- `T2`: Layer 이름
  - `Test`
- `T3`: Feature 이름(테스트 피라미드)
  - `Unit` ⊂ `Integration` ⊂ `E2E`

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
  - GitHub Actions
  - Codecov YAML Validator

### dotnet tools
```shell
# dotnet-format
dotnet tool install -g dotnet-format --version 5.1.250801
```
