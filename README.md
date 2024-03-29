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

### 패키지
- `Microsoft.Extensions.Options`: IValidateOptions

### dotnet tools
```shell
# dotnet-format
dotnet tool install -g dotnet-format --version 5.1.250801
```
