# Clean Architecture with Domain-Driven Design

> 배움은 **설렘**이다.  
> 배움은 **겸손**이다.  
> 배움은 **이타심**이다.

If builders built buildings the way programmers wrote programs, then the first woodpecker that came along would destroy civilization. - Gerald Weinberg
- Architecting is a series of **trade-offs**.
- The architecture should scream **the intent of the system**.

## 목차
- [튜토리얼](./tutorials/)

## 폴더 구성
### src 폴더 구성
![](./.images/2024-03-10-15-06-17.png)

```
T1.T2{.T3}

 src
  ├─ CleanDdd.Domain                   : Domain
  ├─ CleanDdd.Application              : Application
  ├─ CleanDdd.Adapters.Infrastructure  : Adapter
  ├─ CleanDdd.Adapters.Persistence     : Adapter
  ├─ CleanDdd.Adapters.Presentation    : Adapter
  └─ CleanDdd.Host                     : Host
```
- `T1`: Solution 이름
- `T2`: Layer 이름
  - `Domain` ⊂ `Application` ⊂ `Adapter` ⊂ `Host`
- `T3`: Feature 이름(생략 가능)
  - Presentation, Infrastructure, Persistence, ...

### tests 폴더 구성
![](./.images/2024-03-10-15-07-38.png)

```
T1.T2.T3

 tests
  ├─ CleanDdd.Tests.Integration        : Test
  └─ CleanDdd.Tests.Unit               : Test
```
- `T1`: Solution 이름
- `T2`: Layer 이름
  - `Test`
- `T3`: Feature 이름(테스트 피라미드)
  - `Unit` ⊂ `Integration` ⊂ `E2E`

### site 폴더 구성
```
 site
  ├─ docs                              : .md 파일 문서화
  ├─ api                               : .cs XML 주석 문서화
  └─ _site                             : 빌드 결과
```

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

### dotnet tools
```shell
# docfx
#   - Install Visual Studio 2022 (Community or higher) and make sure you have the latest updates.
#   - Install .NET SDK 6.x, 7.x and 8.x.
#   - Install NodeJS (20.x.x).
dotnet tool install -g docfx --version 2.75.3

# dotnet-format
dotnet tool install -g dotnet-format --version 5.1.250801
```

## 참고 자료
### GitHub
- [jasontaylordev/CleanArchitecture](https://github.com/jasontaylordev/CleanArchitecture/)
- [ardalis/CleanArchitecture](https://github.com/ardalis/CleanArchitecture/)
- [amantinband/CleanArchitecture](https://github.com/amantinband/clean-architecture)
- [eShopOnWeb](https://github.com/dotnet-architecture/eShopOnWeb)

### 문서
- [The Testing Pyramid: How to Structure Your Test Suite](https://semaphoreci.com/blog/testing-pyramid)