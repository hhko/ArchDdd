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
### src
![](./.images/2024-03-05-09-13-52.png)
```
T1_T2{_T3}
```
- `T1`: 솔루션 이름
- `T2`: 레이어 이름
  - `Adaper`
  - `Application`
  - `Domain`
- `T3`: 세부 이름
  - Presentation, Infrastructure, Persistence, ...

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

## 참고 자료
- https://github.com/jasontaylordev/CleanArchitecture/
- https://github.com/ardalis/CleanArchitecture/
- https://github.com/dotnet-architecture/eShopOnWeb
- https://github.com/amantinband/clean-architecture
