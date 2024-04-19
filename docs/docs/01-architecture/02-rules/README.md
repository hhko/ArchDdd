---
sidebar_position: 2
---

# 아키텍처 규칙

## 프로젝트 이름
- 목표
  - 프로젝트 단위로 레이어를 구성한다.
- 규칙
  ```
  T1.T2.T3
  ```
  - `T1`: 프로세스 이름
  - `T2`: 레이어 이름
    - Adapter
    - Application
    - Domain
  - `T3`: 레이어 세부 이름
- 적용 예
  ```
  ArchiDdd.Adapters.Infrastructure       // T1.T2.T3
  ArchiDdd.Adapters.Persistence          // T1.T2.T3
  ArchiDdd.Adapters.Presentation         // T1.T2.T3
  ArchiDdd.Application                   // T1.T2
  ArchiDdd.Domain                        // T1.T2
  ArchiDdd                               // T1
  ```

## 어셈블리 식별
- 목표
  - 프로젝트 어셈블리 식별을 위한 기본 클래스를 구현한다.
- 구현
  ```cs
  using System.Reflection;

  namespace ArchDdd.Domain;

  public static class AssemblyReference
  {
      public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
  }
  ```
- 적용 예
  ```
  Adapters.Infrastructure.AssemblyReference.Assembly
  Adapters.Persistence.AssemblyReference.Assembly
  Adapters.Presentation.AssemblyReference.Assembly
  Application.AssemblyReference.Assembly
  Domain.AssemblyReference.Assembly
  Host.AssemblyReference.Assembly
  ```

## 아키텍처 레이어 관계(의존성) 테스트
```
Host
↓
Adapters. ...
↓
Application
↓
Domain
```

## Abstractions 폴더
- 목표
  - 레이어 주요 기능 외 구현을 추상화 시킨다.
- 적용 예
  ```
  // 도메인 레이어
  Abstractions/
    BaseTypes/        <- 비즈니스를 정의하기 위한 타입
      Entity
      ...
    Resultes/         <- 연산 수행 결과를 처리하기 위한 타입
      ...
  AggregateRoots/     <- 도메인 레이어 주요 기능
    ...
  ```

## 의존성 등록
- 목표
  - 레이어 단위로 의존성을 관리한다.
- 폴더 구성
  ```
  Abstractions/
    Registration/
      {레이어 이름}LayerRegistration.cs     // 1개
      {기능}Registration.cs                // N개
      {기능}Registration.cs
      ...Registration.cs
  ```
- 레이어
  | 레이어 | Registration 존재 有/無 |
  | --- | --- |
  | Host        | 無 | `-`                                          |
  | Adapter     | 有 | `AdapterInfrastructureLayerRegistration.cs`  |
  | Application | 有 | `ApplicationLayerRegistration.cs`            |
  | Domain      | 無 | `-`                                          |

## 환경 설정
### 환경 설정 파일
- 목표
  - `appsettings.json` 파일을 실행 환경 단위로 구성한다.
- 실행 구성
  ```json
  {
    "profiles": {
      "ArchDdd.Host": {
        "environmentVariables": {
          "ASPNETCORE_ENVIRONMENT": "Development"
        }
      },
      "고형호 | ArchDdd.Host": {
        "environmentVariables": {
          "ASPNETCORE_ENVIRONMENT": "고형호"
        }
      }
    }
  }
  ```
  - `launchSettings.json` 파일에 정의된 `ASPNETCORE_ENVIRONMENT` 값을 기준으로 `appsettings.{환경변수}.json` 파일을 읽는다.

### 환경 설정 옵션
- 목표
  - 환경 설정 값을 `appsettings.json`으로 읽는다.
- 주요 구성
  | 구분            | 인터페이스 |
  | --- | --- |
  | 옵션 값            | `-`                     |
  | 옵션 값 구성        | `IConfigureOptions<T>`  |
  | 옵션 값 유효성 검사 | `IValidateOptions<T>`   |
- 적용 예
  ```cs
  // 옵션 값
  DatabaseOptions

  // 옵션 값 구성
  DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>

  // 옵션 값 유효성 검사
  DatabaseOptionsValidator : IValidateOptions<DatabaseOptions>
  ```

### 환경 설정 테스트
- 메모리 `appsettings.json` 자료구조 예.
  ```
  {
    "TopLevelKey": "TopLevelValue",
    "SectionName": {
      "SomeKey": "SectionValue"
    }
  }

  var inMemorySettings = new Dictionary<string, string> {
    {"TopLevelKey", "TopLevelValue"},
    {"SectionName:SomeKey", "SectionValue"},
  };
  ```
  ```
  {
    "ArrayKey": [
      1,
      2,
      3
    ]
  }

  var inMemorySettings = new Dictionary<string, string> {
    {"ArrayKey:0", "1"},
    {"ArrayKey:1", "2"},
    {"ArrayKey:2", "3"},
  };
  ```
- 메모리 `appsettings.json` 자료구조 주입
  ```cs
  IConfiguration configuration = new ConfigurationBuilder()
              .AddInMemoryCollection(inMemorySettings!)
              .Build();
  ```