---
sidebar_position: 2
---

# 아키텍처 규칙

## 레이어
### 레이어 이름
```
솔루션명
  프로젝트명1
    src                             // 애플리케이션 레이어
      프로젝트명1
      프로젝트명1.Adapters.Infrastructure
      프로젝트명1.Adapters.Persistence
      프로젝트명1.Adapters.Presentation
      프로젝트명1.Application
      프로젝트명1.Domain
    tests                           // 테스트 레이어
      프로젝트명1.Tests.Integration
      프로젝트명1.Tests.Performance
      프로젝트명1.Tests.Unit
  프로젝트명2
  tests
    솔루션명.Tests.E2E
```
- 애플리케이션 레이어
  - 기술 관심사
    - `Host`: 생략
    - `Adapter`: 기능
  - 비즈니스 관심사
    - `Application`: UseCase
    - `Domain`: AggregateRoot
- 테스트 레이어
  - `E2E`
  - `Integration`, `Performance`, ...
  - `Unit`

### 레이어 의존성 관계
```
Host            // 기술 관심사: 프로세스
 ↓
Adapters. ...   // 기술 관심사: Infrastructure, Persistence, Presentation
 ↓
Application     // 비즈니스 관심사: UseCase
 ↓
Domain          // 비즈니스 관심사: AggregateRoot
```

### 프로젝트 어셈블리
- 네임스페이스와 정적 클래스를 이용하여 어셈블리를 식별하기 위해 `AssemblyReference.cs` 파일을 모든 프로젝트에 생성합니다.

```cs
using System.Reflection;

namespace ArchDdd.Application;    // Application 레이어

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
```

```
솔루션명
  프로젝트명1
    src                             // 애플리케이션 레이어
      프로젝트명1
        AssemblyReference.cs        // 어셈블리 참조를 위한 공통 파일
      프로젝트명1.Adapters.Infrastructure
        AssemblyReference.cs
      프로젝트명1.Adapters.Persistence
        AssemblyReference.cs
      프로젝트명1.Adapters.Presentation
        AssemblyReference.cs
      프로젝트명1.Application
        AssemblyReference.cs
      프로젝트명1.Domain
        AssemblyReference.cs
```

### 레이어 의존성 관계 테스트
```
```

## 의존성 등록
```

```

## Host 인터페이스
```cs
// Program 어셈블리
//public sealed partial class Program { }
public interface IAppMaker
{

}

// Integration 테스트
public sealed class WebAppFactoryFixture
    //: WebApplicationFactory<Program>
    : WebApplicationFactory<IAppMarker>
    , IAsyncLifetime
{
  // ...
}
```

## Middleware & Pipeline
```
Middleware                 --> WebApi Controller --> Pipeline            --> Handler
ErrorHandlingMiddleware                             LoggingPipeline
RequestTimeMiddleware                               ValidatorPipeline
```
- Middleware: WebApi
- Pipeline: MediatR

| 순서 | 구분 | 로그 | 기능 |
| --- | --- | --- | --- |
| 1   | ErrorHandlingMiddleware | Error               | 전역 예외 처리 |
| 2   | RequestTimeMiddleware   | Warning             | 4초 이상 |
| 3   | LoggingPipeline         | Information, Error  | 모든 메시지 |
| 4   | ValidatorPipeline       | -                   | 메시지 유효성 검사 |

## 로그
### 구조화 패키지

### 전용 메서드
- 로그 전용 메서드를 이용하여 로그 출력에 의미(예. LogRequestTime)와 형식을 표준화한다.
  - 형식
    - EventId: 로그 식별 값
    - Message: 로그 구조화

```cs

// _log.LogRequestTime
public static partial class LoggerMessageDefinitionsUtilities
{
    [LoggerMessage(
        EventId = 0,
        EventName = $"{nameof(RequestTimeMiddleware)}",
        Level = LogLevel.Warning,
        Message = "Request [{Method}] at {Path} took {Milliseconds} ms",
        SkipEnabledCheck = true)]
    public static partial void LogRequestTime(this ILogger logger,
        string method,
        PathString path,
        double milliseconds);
}
```




## 유스케이스
### 유스케이스
### 유스케이스 단위 구현 방법
- **Entity가 없을(無) 때**
  - `논리 1개 : 인터페이스 메서드 1개 호출(순수 기술)`: 인터페이스 메서드 호출
  - `논리 1개 : 인터페이스 메서드 N개 호출(비즈니스 조합)`: private 메서드에서 N개 인터페이스 메서드 호출
- **Entity가 있을(有) 때**
  - `논리 1개 : Entity 인스턴스 1개`: Entity 메서드 호출
  - `논리 1개 : Entity 인스턴스 N개`: Domain Service 메서드 호출


<br/>
<br/>



```
솔루션명
  프로젝트명1
    src
      프로젝트명1.Adapters.Infrastructure
        Abstractions
          Constants
          Registrations
            {레이어_이름}LayerRegistration.cs     // 외부 호출
            {의존주입_이름}Registration.cs        // 내부 개별
            ...
            ServiceRegistration.cs               // 내부 통합
          Constants
        AssemblyReference.cs
      프로젝트명1.Adapters.Persistence
      프로젝트명1.Adapters.Presentation
      프로젝트명1.Application
        Abstractions
          Constants
          CQRS
          Registrations
        UseCases
          {UseCase_이름}
            Commands
              {}Command.cs
              {}CommandHandler.cs
              {}CommandValidator.cs
              {}Response.cs
            Events
              {}Evnet.cs
              {}EvnetHandler.cs
              ?
            Queries
              {}Query.cs
              {}QueryHandler.cs
              {}QueryValidator.cs
              {}Response.cs
        AssemblyReference.cs
      프로젝트명1.Domain
        Abstractions
          Constants
        AggregateRoots
          {AggregateRoot_이름}
            ValueObjects
            Events
            Errors
            Enumerations
            {Entity}.cs
            {인터페이스}.cs
            {도메인서비스?}.cs
        AssemblyReference.cs
    tests
      프로젝트명1.Tests.Integration
      프로젝트명1.Tests.Unit
  프로젝트명2
    src
      ...
    tests
      ...
  ...
  tests
    솔루션명.Tests.E2E
```


```
Request   {}Command
          {}CommandHandler
          {}CommandValidator
          {}Response            // ? DTO

Response  {}Query
          {}QueryHandler
          {}QueryValidator
          {}Response            // ? DTO
```

## 솔루션 구성
```
솔루션명
  프로젝트명1
    src
      프로젝트명1.Adapters.Infrastructure
      프로젝트명1.Adapters.Persistence
      프로젝트명1.Adapters.Presentation
      프로젝트명1.Application
      프로젝트명1.Domain
      프로젝트명1
    tests
      프로젝트명1.Tests.Integration
      프로젝트명1.Tests.Unit
  프로젝트명2
    src
      ...
    tests
      ...
  ...
  tests
    솔루션명.Tests.E2E
```

- 프로젝트 규칙
  ```
  T1.T2.T3
  ```
  - `T1`: 프로젝트 이름
  - `T2`: 레이어 이름
    - Adapter
    - Application
    - Domain
  - `T3`: 기능 이름
- **테스트** 프로젝트 규칙
  ```
  T1.T2.T3
  ```
  - `T1`: 프로젝트 이름
  - `T2`: 레이어 이름
    - Test
  - `T3`: 기능 이름
    - `E2E`
    - `Integration`
    - `Unit`

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