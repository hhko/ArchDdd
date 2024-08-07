```
Gatsby Tutorial
https://www.youtube.com/watch?v=Qms4k6y7OgI&list=PL4cUxeGkcC9hw1g77I35ZivVLe8k2nvjB

choco install nodejs-lts --version="20.16.0" -y
choco install git
choco install vscode

npm install -g gatsby-cli     # 버전 명시?, # 버전 목록
gatsby --version
gatsby --help

https://www.gatsbyjs.com/starters/
  gatsby new my-hello-world-starter https://github.com/gatsbyjs/gatsby-starter-hello-world
  gatsby new gatsby-gitbook-starter https://github.com/hasura/gatsby-gitbook-starter

  gatsby new docs https://github.com/hasura/gatsby-gitbook-starter



ES7 React/Redux/GraphQL/React-Native snippets

gatsby new docs2 https://github.com/codebushi/gatsby-theme-document-example
gatsby new docs3 https://github.com/jpedroschmitz/gatsby-starter-rocketdocs

https://github.com/jpedroschmitz/rocketdocs




Part 0: Set Up Your Development Environment
https://www.gatsbyjs.com/docs/tutorial/getting-started/part-0/

choco install nodejs-lts --version="20.16.0" -y
choco install git
choco install vscode

npm install -g gatsby-cli     # 버전 명시?, # 버전 목록
gatsby --version
gatsby --help


Part 1: Create and Deploy Your First Gatsby Site
https://www.gatsbyjs.com/docs/tutorial/getting-started/part-1/

gatsby new

npm run develop
gatsby develop
gatsby develop --host=0.0.0.0       # IP, Port?

http://localhost:8000/
http://localhost:8000/___graphql


git remote add origin https:// ... .git
git branch -M main
git push -u origin main

Part 2: Use and Style React Components
https://www.gatsbyjs.com/docs/tutorial/getting-started/part-2/



npm init gatsby my-site-name -- -y -ts
```


- [x] Query vs. Command Repository 분리
- [ ] Dapper

---
- [ ] .NET Core Configure Open telemetry & enhance your automated testing setup
  - https://www.youtube.com/watch?v=abmjFyMaKjs
- [ ] GitHub 컨테이너 배포: https://blog.martincostello.com/look-ma-no-hands-publishing-containers-with-the-dotnet-sdk/
- [ ] Transactional outbox pattern meets distributed tracing and OpenTelemetry
  - https://github.com/joaofbantunes/OutboxPatternMeetsOpenTelemetrySample
  - https://blog.codingmilitia.com/2024/06/17/transactional-outbox-pattern-meets-distributed-tracing-and-opentelemetry/

```
## User
User : Role = 1 : N   // Role 가별 테이블: Entity
User : Role = 1 : N   // Role 불변 테이블: Enumeration

private readonly List<Role> _roles = [];
public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();
  _roles.Add(role);
  _roles.Remove(role);

builder.HasMany(u => u.Roles)
    .WithMany(r => r.Users)
    .UsingEntity<RoleUser>();       <-- NxM 관계 테이블

---
## Role
public ICollection<User> Users { get; init; }
builder.HasMany(r => r.Users)
    .WithMany(u => u.Roles);

---
## RoleUser
builder.HasKey(x => new { x.RoleName, x.UserId });

```
```

1. public async Task<T?> GetPermissionAsync<T>(PermissionName permission, CancellationToken cancellationToken)
    where T : class

T -> Permission으로 변경?

2. Permission으로 구현
```

```
Permission
  CreatePermission
  DeletePermission
ValueObject
EFCore 코드 생성기
----
Role
  User <-> Role <-> Permission
    1xN
    NxM

// User
UserId
private readonly List<Role> _roles = [];
public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

public void AddRole(Role role)
{
    _roles.Add(role);
}

public void RemoveRole(Role role)
{
    _roles.Remove(role);
}

->
public RoleUser(string roleName, UserId userId)
->

// Role
public string Name { get; init; }
public ICollection<User> Users { get; init; }

public ICollection<Permission> Permissions { get; init; }
---------------------------

->
public RolePermission(string roleName, string permissionName)
->


NxM
  Nx1

1 -> N
N <- 1
---------
1 -> N

```
Entity Framework Visual Editor
https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner2022

https://www.thereformedprogrammer.net/creating-domain-driven-design-entity-classes-with-entity-framework-core/
https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-one

https://github.com/k1LoW/tbls
https://github.com/gman-au/siren
https://github.com/JonPSmith/EfCore.TestSupport
https://github.com/JonPSmith/EfCore.SchemaCompare

Creating Domain-Driven Design entity classes with Entity Framework Core
https://www.thereformedprogrammer.net/creating-domain-driven-design-entity-classes-with-entity-framework-core/

http://www.ch-werner.de/sqliteodbc/

Aggregate to Relational Database Steps
1. Table
   - Table Splitting/Table Sharing: ValueObject을 Entity 테이블에 표현하기
1. Foreign Keys
   - 부모 Key: 외래 키
   - 부모 Key, 부모n부모 Key: 외래 키
   - Composite Key
   - Surrogate Key: 데이터베이스가 생성하는 키
1. Types & Other Constraints
   - Owned Entity

값 / EntityId / Id

.ValueGeneratedNever()
.HasConversion(
    id => id.Value,
    value => 값.Create(value)
)

OwnOne()


.ToTable("");
.WithOwner().HasForeignKey("");
.HasKey("")
.Propperty(x => x. ...)
  .HasColumnName("")
  .ValueGeneratedNever()
  .HasConversion(
      id => id.Value,
      value => 값.Create(value)
  )

```




- [ ] Permission 클래스
- [ ] Permission 데이터베이스화
- [ ] Permission API 이해
- [ ] NXM 관계 api
---
- [ ] NxM 관계 api 통합 테스트
- [ ] 통합 테스트 데이터베이스 초기화 복원
---
- [ ] 데이터베이스 다이어그램
---
- [ ] HasConversion 소스 생성기

## 2024-06-30(일)
- [x] 할일 문서 정리
- [x] 기존 코드 이해
- [x] ~~Persistence: Migration 개별 -> 통합~~
- [x] NxM 관계 이해 및 EFCore 구현: User NxM Role
- [x] Role 기본 데이터 EFCore 구현
- [x] dotnet ef 명령어 스크립트화


<br/>

- [ ] [How to Use FakeLogger to Test Logging Code in .NET](https://code-maze.com/dotnet-how-to-use-fakelogger/)
  - https://johnnyreilly.com/snapshot-log-tests-dotnet
  - https://blog.elmah.io/testing-logging-code-with-microsoft-extensions-logging-and-fakelogger/
  - https://devblogs.microsoft.com/dotnet/fake-it-til-you-make-it-to-production/


https://www.mytechramblings.com/posts/getting-started-with-opentelemetry-metrics-and-dotnet-part-1/
https://www.mytechramblings.com/posts/getting-started-with-opentelemetry-metrics-and-dotnet-part-2/
https://github.com/karlospn/opentelemetry-metrics-demo

```
Services.AddContext
DbContext
  OnConfiguring
  {
    .Use...
  }

  DbSet

--- vs ---

DbContext
  OnModelCreating
  {
    ApplyConfigurationsFromAssembly
  }
IDesignTimeDbContextFactory
  {
    .Use
  }
IEntityTypeConfiguration


OnConfig
{
  UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}

MigrationsHistoryTable(HistoryResitory
  .DefaultTableName,
  "xxx")
```

- [ ] Persistence: DB -> 코드
- [ ] Persistence: DB 변화 코드 확인(소스 생성기)?
- [ ] Persistence: 코드 기반 DB 시각화?
- [ ] Persistence: EF PowerTools 이해
- [ ] Persistence: Sqlite 기반 CRUD 테스트(데이터 초기화)
- [ ] Persistence: IEntityTypeConfiguration 이해

```
컨테이너 기반 Sqlite
컨테이너 기반 Sqlite 통합 테스트

Specifications 패턴
Outbox 패턴
Cache
```

<br/>

- [x] 설정에 Provider 지정
- [x] 설정 Provider 기준으로 Use...
- [x] 설정 N개 파일로 분리하기
- [x] DTO 동영상 리뷰
- [x] xUnit 테스트 전용 .db 파일 지정
- [ ] Migration 실행

https://blog.jetbrains.com/dotnet/2013/09/03/duplicate-finder-part-of-resharper-command-line-tools/
https://www.jetbrains.com/resharper/features/command-line.html
https://blog.jetbrains.com/ko/2019/01/17/copypaste/

https://github.com/dlidstrom/Duplo

```
EFCore
  배열: https://devblogs.microsoft.com/dotnet/array-mapping-in-ef-core-8/
  트랜잭션: IExecutionStrategy, 예외 발생시?
DTO
  https://www.youtube.com/watch?v=Q3QGC-Llqr8&t=41s
  https://github.com/kgrzybek/modular-monolith-with-ddd
---
컨테이너
배포
통합 테스트
---
OpenTelemetry
OpenSeaarch(Grafana...)
성능 테스트
  https://github.com/RickStrahl/HighPerformanceAspNet
---
UseCase 인터페이스 호출 IValidationResult -> 데코레이터패턴
https://blog.postsharp.net/decorator-pattern
```

- blog 엔진 소스
  - https://github.com/linkdotnet/Blog

https://codewithmukesh.com/blog/global-exception-handling-in-aspnet-core/?utm_source=github&utm_medium=social&utm_campaign=repository

- [CQRS 패턴](https://learn.microsoft.com/ko-kr/azure/architecture/patterns/cqrs)
  - 쿼리는 데이터베이스를 수정하지 않습니다. 쿼리는 도메인 정보를 캡슐화하지 않는 **DTO를 반환합니다.**

```powershell
# 코딩 스타일
- File scope
- internal sealed
- primary constructor
- constructor ?? null 처리

# 할일
- VSCode SQLite 확장 도구
- 사용자 추가
- Seed Data 생성하기
- 사용자 제거
- 통합 테스트
- 통합 테스트 DB 초기화
- Unit of Work
- 도커 컴포즈
- xUnit 정리

## 공부
- CQRS 학습 https://www.kamilgrzybek.com/blog/posts/simple-cqrs-implementation-raw-sql-ddd
- 데코레이터 의존성 주입을 활용한 Validation
- DDD 리팩토링 https://www.jimmybogard.com/domain-driven-refactoring-intro/
- DDD 리팩토링 https://github.com/ardalis/DDD-NoDuplicates
- 코드 스타일
- AutoFixture
- Bogus
- 문서화
  - 버전
  - 한글 검색
  - 이미지 확대
  - 다국어?
```

```powershell
- 솔루션 구성
  - 빌드 버전
  - 빌드 옵션
  - 패키지 버전
  - 코딩 스타일
  - 코드 품질
  - 컨테이너 배포
  - 패키지 배포
- 아키텍처 원칙: 관심사의 분리
- 아키텍처 역사
- 아키텍처 구성

```

## 학습
```
generic in/out

인터페이스 -> 인터페이스<T> 동시 생성?
public interface IUnitOfWork
public interface IUnitOfWork<out TContext> : IUnitOfWork
```


## SQLite
- [ ] not null: CreatedBy
- [ ] 트랜잭션 Pipeline?
- [x] Microsoft.EntityFrameworkCore.Sqlite
- [x] options.UseSqlite("Data Source=TestDatabase.db");
- [x] 의존성 등록
- [x] 테이블 생성
- [ ] SQL 뷰어 VSCode 확장 도구?
- [x] 마이그레이션 폴더 지정
- [ ] 마이그레이션 도구? https://github.com/hhko/SSW.CleanArchitecture/tree/main/tools/Database
- [x] .db 파일 제외
- [ ] IEntityTypeConfiguration 이해
- [ ] IDesignTimeDbContextFactory args 전달하기
- [ ] GenerateEntityIdComparer, GenerateEntityIdConverter 소스 생성기 이해
- [ ] 통합 테스트?
- [ ] Unit of Work
- [ ] Specifications
- [ ] Outbox


```
컨테이너
OpenTelemetry
Source Generator
```

```
username validation 통합 테스트 N개
https://github.com/VerifyTests/Verify/blob/main/docs/parameterised.md
verify 클래스 이름(TypeName) 생략
---
로그
opentelemetry collector
  Json 로그
  Windows 로그
  Linux 로그
  Container 로그
----
User 유스케이스 구현

verify 클래스 이름 제외
예외 로그
opensearch
opentelemetry 매트릭
opentelemetry collector
  Windows 자원
  Windows 프로세스 자원
  Linux 자원
  Linux Container 자원
성능 테스트
캐시
코딩 컨벤션?
Constants 이름
유스케이스 IValidator 단순화?
```

```
개선
1. .prop
1. xxxError에 오류 값
1. 데이터 유효성 -> .Fluent, Business Rule 유효성 Handler
1. 예외 로그 구조화

질문
1. enum vs. Enumeration

버그
1. Query in
1. command 파라미터 이름
1. emailResult.Value 유효성 검사 사전 필요?
bool emailIsTaken = await _userRepository
    .IsEmailTakenAsync(emailResult.Value, cancellationToken);
1. nameof opentelemtry
1. service 이름
   options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(
      serviceName: nameof(ArchDdd)))
1. Middleware 위치
   app -> presentation
1. error: Error.Exception(exception.Message), -> error: Error.FromException(exception),
```


- [ ] 로그 예외 구조화 -> Serilog
- [ ] `FormBody`, `FormRute`?
- [ ] `Constants` 폴더, 클래스 이름 구분?
- [ ] NSubstitute 모든 메서드 명시적 정의?
- [x] WebApi 실패 처리
- [x] WebApi 실패 처리 통합 테스트
- [x] WebApi 실패 처리 데이터 랜덤 생성
- [x] WebApi 실패 처리 Verify
- [x] 유효성 검새 클래스
- [x] 유효성 검사 자동 등록
- [x] 유효성 검사 + Mediator 패턴 통합
- [x] 유효성 검사 + Result 통합
- [ ] Application Handler 유효성 검사 제거
- [ ] 로그 SkipEnabledCheck = true?
- [ ] ~~Error[] validationErrors -> "ValidationErrors": "ArchDdd.Domain.Abstractions.Results.Error[]",~~
- [ ] 단위 테스트에서 Option 재정의 불가능?
  ```
  입력 --{유효성 검사}--> 연산 --{유효성 검사 None}--> 출력
  ```



## CQRS
- [x] IRequest
- [x] IRequestHandler -> ICommandHandler
- [ ] IQueryHandler<in? ... >
  ```cs
  // IQueryHandler 인터페이스 정의?
  public interface IQueryHandler<in TQuery, TResponse>  // <-- in? 
  public interface IQueryHandler<TQuery, TResponse> 
      : IRequestHandler<TQuery, IResult<TResponse>>
      where TQuery : IQuery<TResponse>
      where TResponse : IResponse
  {
  }

  public interface IRequestHandler<in TRequest, TResponse>
      where TRequest : IRequest<TResponse>
  ```
- [x] InternalsVisibleTo
- [ ] ICachedQuery
- [ ] IHasCursor
- [ ] Ulid 모든 레이어에서 사용할 수 있는 Primitive 타입화? 의존성 검사 실패됨
- [ ] IValidator 인터페이스 이름이 FluentValidation과 겹침
- [ ] Error.Common?
- [ ] GetAtomicValues object -> T
  ```cs
  public override IEnumerable<object> GetAtomicValues()
    object -> T
  ```
- [ ] ?
  ```cs
  public static TResult CreateValidationResult<TResult>(this ICollection<Error> errors)
      where TResult : class, IResult
  {
      if (typeof(TResult) == typeof(Result))
      {
          return (ValidationResult.WithErrors(errors) as TResult)!;
      }

      object validationResult = typeof(ValidationResult<>)
          .GetGenericTypeDefinition()
          .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
          .GetMethod(nameof(ValidationResult.WithErrors))!
          .Invoke(null, [errors])!;

      return (TResult)validationResult;
  }
  ```
```
info: ArchDdd.Application.Abstractions.Pipelines.LoggingPipeline[1]
      Starting request RegisterUserCommand, 05/12/2024 21:34:36
      LogRecord.Timestamp:               2024-05-12T21:34:36.6452033Z
      LogRecord.TraceId:                 125f9bb574cdac37fa3aa0fdd41e0217
      LogRecord.SpanId:                  e563f4a5dfcf4297
      LogRecord.TraceFlags:              None
      LogRecord.CategoryName:            ArchDdd.Application.Abstractions.Pipelines.LoggingPipeline
      LogRecord.Severity:                Info
      LogRecord.SeverityText:            Information
      LogRecord.FormattedMessage:        Starting request RegisterUserCommand, 05/12/2024 21:34:36
      LogRecord.Body:                    Starting request {RequestName}, {DateTimeUtc}
      LogRecord.Attributes (Key:Value):
          RequestName: RegisterUserCommand
          DateTimeUtc: 2024-05-12 오후 9:34:36
          OriginalFormat (a.k.a Body): Starting request {RequestName}, {DateTimeUtc}
      LogRecord.EventId:                 1
      LogRecord.EventName:               StartingRequest in LoggingPipeline
      LogRecord.ScopeValues (Key:Value):
          [Scope.0]:SpanId: e563f4a5dfcf4297
          [Scope.0]:TraceId: 125f9bb574cdac37fa3aa0fdd41e0217
          [Scope.0]:ParentId: a4115191a2e888bc
          [Scope.1]:ConnectionId: 0HN3IPCJ1VHBE
          [Scope.2]:RequestId: 0HN3IPCJ1VHBE:00000001
          [Scope.2]:RequestPath: /api/user/register
          [Scope.3]:ActionId: abab2683-85e4-4cf0-9d5b-db509f4c76d6
          [Scope.3]:ActionName: ArchDdd.Adapters.Presentation.Controllers.UserController.Register (ArchDdd.Adapters.Presentation)

      Resource associated with LogRecord:
      telemetry.sdk.name: opentelemetry
      telemetry.sdk.language: dotnet
      telemetry.sdk.version: 1.8.1
      service.name: unknown_service:ArchDdd

fail: ArchDdd.Application.Abstractions.Pipelines.LoggingPipeline[4]
      Request failed RegisterUserCommand, Username name must be at most 30 characters., Username contains illegal character., 05/12/2024 21:34:36
      LogRecord.Timestamp:               2024-05-12T21:34:36.8299984Z
      LogRecord.TraceId:                 125f9bb574cdac37fa3aa0fdd41e0217
      LogRecord.SpanId:                  e563f4a5dfcf4297
      LogRecord.TraceFlags:              None
      LogRecord.CategoryName:            ArchDdd.Application.Abstractions.Pipelines.LoggingPipeline
      LogRecord.Severity:                Error
      LogRecord.SeverityText:            Error
      LogRecord.FormattedMessage:        Request failed RegisterUserCommand, Username name must be at most 30 characters., Username contains illegal character., 05/12/2024 21:34:36
      LogRecord.Body:                    Request failed {RequestName}, {ValidationErrors}, {DateTimeUtc}
      LogRecord.Attributes (Key:Value):
          RequestName: RegisterUserCommand
          ValidationErrors: ["Username name must be at most 30 characters.","Username contains illegal character."]
          DateTimeUtc: 2024-05-12 오후 9:34:36
          OriginalFormat (a.k.a Body): Request failed {RequestName}, {ValidationErrors}, {DateTimeUtc}
      LogRecord.EventId:                 4
      LogRecord.EventName:               FailedRequestBasedOnValidationErrors in LoggingPipeline
      LogRecord.ScopeValues (Key:Value):
          [Scope.0]:SpanId: e563f4a5dfcf4297
          [Scope.0]:TraceId: 125f9bb574cdac37fa3aa0fdd41e0217
          [Scope.0]:ParentId: a4115191a2e888bc
          [Scope.1]:ConnectionId: 0HN3IPCJ1VHBE
          [Scope.2]:RequestId: 0HN3IPCJ1VHBE:00000001
          [Scope.2]:RequestPath: /api/user/register
          [Scope.3]:ActionId: abab2683-85e4-4cf0-9d5b-db509f4c76d6
          [Scope.3]:ActionName: ArchDdd.Adapters.Presentation.Controllers.UserController.Register (ArchDdd.Adapters.Presentation)

      Resource associated with LogRecord:
      telemetry.sdk.name: opentelemetry
      telemetry.sdk.language: dotnet
      telemetry.sdk.version: 1.8.1
      service.name: unknown_service:ArchDdd
```

## none
```
info: ArchDdd.Application.Abstractions.Pipelines.LoggingPipeline[1]
      Starting request RegisterUserCommand, 05/12/2024 21:41:33
      LogRecord.Timestamp:               2024-05-12T21:41:33.4189288Z
      LogRecord.TraceId:                 125f9bb574cdac37fa3aa0fdd41e0217
      LogRecord.SpanId:                  f9000caf19b2796f
      LogRecord.TraceFlags:              None
      LogRecord.CategoryName:            ArchDdd.Application.Abstractions.Pipelines.LoggingPipeline
      LogRecord.Severity:                Info
      LogRecord.SeverityText:            Information
      LogRecord.FormattedMessage:        Starting request RegisterUserCommand, 05/12/2024 21:41:33
      LogRecord.Body:                    Starting request {RequestName}, {DateTimeUtc}
      LogRecord.Attributes (Key:Value):
          RequestName: RegisterUserCommand
          DateTimeUtc: 2024-05-12 오후 9:41:33
          OriginalFormat (a.k.a Body): Starting request {RequestName}, {DateTimeUtc}
      LogRecord.EventId:                 1
      LogRecord.EventName:               StartingRequest in LoggingPipeline
      LogRecord.ScopeValues (Key:Value):
          [Scope.0]:SpanId: f9000caf19b2796f
          [Scope.0]:TraceId: 125f9bb574cdac37fa3aa0fdd41e0217
          [Scope.0]:ParentId: d2edca91fa2be7fa
          [Scope.1]:ConnectionId: 0HN3IPGTDVP61
          [Scope.2]:RequestId: 0HN3IPGTDVP61:00000001
          [Scope.2]:RequestPath: /api/user/register
          [Scope.3]:ActionId: 9250ff53-d40f-41dc-90a2-09a55d18b36a
          [Scope.3]:ActionName: ArchDdd.Adapters.Presentation.Controllers.UserController.Register (ArchDdd.Adapters.Presentation)

      Resource associated with LogRecord:
      telemetry.sdk.name: opentelemetry
      telemetry.sdk.language: dotnet
      telemetry.sdk.version: 1.8.1
      service.name: unknown_service:ArchDdd

fail: ArchDdd.Application.Abstractions.Pipelines.LoggingPipeline[4]
      Request failed RegisterUserCommand, Username name must be at most 30 characters., Username contains illegal character., 05/12/2024 21:41:33
LogRecord.Timestamp:               2024-05-12T21:41:33.4667256Z
LogRecord.TraceId:                 125f9bb574cdac37fa3aa0fdd41e0217
LogRecord.SpanId:                  f9000caf19b2796f
LogRecord.TraceFlags:              None
LogRecord.CategoryName:            ArchDdd.Application.Abstractions.Pipelines.LoggingPipeline
LogRecord.Severity:                Error
LogRecord.SeverityText:            Error
LogRecord.FormattedMessage:        Request failed RegisterUserCommand, Username name must be at most 30 characters., Username contains illegal character., 05/12/2024 21:41:33
LogRecord.Body:                    Request failed {RequestName}, {ValidationErrors}, {DateTimeUtc}
LogRecord.Attributes (Key:Value):
    RequestName: RegisterUserCommand
    ValidationErrors: ["Username name must be at most 30 characters.","Username contains illegal character."]
    DateTimeUtc: 2024-05-12 오후 9:41:33
    OriginalFormat (a.k.a Body): Request failed {RequestName}, {ValidationErrors}, {DateTimeUtc}
LogRecord.EventId:                 4
LogRecord.EventName:               FailedRequestBasedOnValidationErrors in LoggingPipeline
LogRecord.ScopeValues (Key:Value):
[Scope.0]:SpanId: f9000caf19b2796f
[Scope.0]:TraceId: 125f9bb574cdac37fa3aa0fdd41e0217
[Scope.0]:ParentId: d2edca91fa2be7fa
[Scope.1]:ConnectionId: 0HN3IPGTDVP61
[Scope.2]:RequestId: 0HN3IPGTDVP61:00000001
[Scope.2]:RequestPath: /api/user/register
[Scope.3]:ActionId: 9250ff53-d40f-41dc-90a2-09a55d18b36a
[Scope.3]:ActionName: ArchDdd.Adapters.Presentation.Controllers.UserController.Register (ArchDdd.Adapters.Presentation)

Resource associated with LogRecord:
telemetry.sdk.name: opentelemetry
telemetry.sdk.language: dotnet
telemetry.sdk.version: 1.8.1
service.name: unknown_service:ArchDdd
```



```
1. [x] webapi snapshot 테스트
1. [ ] NBomber | webapi 성능 테스트, NBomber
1. [ ] NBomber | 테스트 --filter "UnitTest=Application|UnitTest=Architecture|UnitTest=Domain|UnitTest=Utility"
1. [ ] NBomber | 성능 테스트
   - 프로세스 싷행
   - 테스트 실행
   - 프로젝트 종료?
1. [ ] NBomber | reports 폴더 변경
1. [ ] webapi 성능 테스트, k6
---
1. 유효성 검사
1. dto
---
1. 컨테이너
1. 컨테이너 커스텀: 필수 추가 패키지 설치
1. 로그: docker 로그 통합?, 자체 로그
1. 로그 모니터링
1. 지표 모니터링
1. webapi 성능 테스트 통합
1. background job 성능 테스트?
---
1. QuartzScheduler 통합 테스트 개선
1. operator >, ...
1. Equality 테스트 재사용 코드 구현
1. ValueObject object -> T 비교
1. <Import Project="$([MSBuild]::GetPathOfFileAbove('Directory.Build.props', '$(MSBuildThisFileDirectory)../'))" />
```

- [ ] WebApi 통합 테스트
- [ ] Quartz.SchedulerException : Scheduler with name 'QuartzScheduler' already exists.
- [ ] WebApi 통합 테스트 snapshot 테스트
- [ ] WebApi 성능 테스트

<br/>

- [ ] Error 데이터 타입 선언?
  ```
  public Error[] ValidationErrors { get; }
  public static ValidationResult<TValue> WithErrors(params Error[] validationErrors)
  ```
  ```
  ICollection
  ```
- [ ] ValueObject, operator >, .. 비교 연산자 이해
  ```cs
  public static bool operator >(UserId a, UserId b) => a.CompareTo(b) is 1;
  public static bool operator <(UserId a, UserId b) => a.CompareTo(b) is -1;
  public static bool operator >=(UserId a, UserId b) => a.CompareTo(b) >= 0;
  public static bool operator <=(UserId a, UserId b) => a.CompareTo(b) <= 0;
  ```
- [ ] IValidateOptions 인터페이스 구현 선언형으로 개선


## WebApi
### 테스트
- [x] 통합 테스트 구축
- [ ] 통합 테스트 결과값 Snapshot 테스트
- [ ] 성능 테스트

### 기본 구현
- [ ] 입력 유효성 검사
- [ ] 출력 데이터 변환(DTO)
- [ ] 속성 이해
  ```
  [HttpPost("[action]")]
  [HttpDelete($"{{orderHeaderId}}/{OrderLines}/{{orderLineId}}")]   $ 사용시 {{ 외부 }}, { 내부(변수) }

  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
  ```
- [ ] 타이틀, public class OpenApiOptionsSetup : IConfigureOptions<SwaggerGenOptions>
- [ ] 예제
- [ ] 버전, URL 기반, 기본 버전
  ```
  [Route("api/v{version:apiVersion}/[controller]")]

  [ApiVersion(1.0, Deprecated = true)]
  [ApiVersion(2.0)]
  ```
- [ ] 실패 메시지
- [ ] openapi 초기화 개선?
  ```cs
  .ConfigureApiBehaviorOptions(options =>
      options.InvalidModelStateResponseFactory = ApiBehaviorOptions.InvalidModelStateResponse)
  .AddNewtonsoftJson(options =>
  {
      options.SerializerSettings.ContractResolver = new RequiredPropertiesCamelCaseContractResolver();
      options.SerializerSettings.Formatting = Indented;
      options.SerializerSettings.Converters.Add(new StringEnumConverter());
      options.SerializerSettings.ReferenceLoopHandling = Ignore;
  });
  ```


---
- [ ] Equality 테스트 재사용 코드 구현
- [ ] ValueObject object -> T 비교
- [ ] : ICustomRule 2번 호출됨
---
- [ ] User 등록 API 구현
- [x] `TestResults` VS에서 제외 시키기
- [ ] Enumeration<T> vs. enum 사용처 구분?

- [x] record
  ```
  record class
  record
  ```
- [ ] Type -> IEnumerable<TEnum> -> Dictionary<int, TEnum>
```cs
    private static IEnumerable<TEnum> GetFieldsForType(Type enumType)
    {
        return enumType
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fieldInfo => enumType.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo => (TEnum)fieldInfo.GetValue(default)!);
    }

    private static Dictionary<int, TEnum> CreateEnumerationDictionary(Type enumType)
    {
        return GetFieldsForType(enumType)
            .ToDictionary(t => t.Id);
    }

```

## ValueObject
- [x] ~~ValueObject Value 재정의 방법?~~
  - 재정의해야할 메서드가 protected
- [ ] Result 테스트
- [ ] ValidationResult 테스트
- [ ] ValueObject 테스트
- [ ] Username ValueObject 테스트
- [ ] Email ValueObject 테스트

## Enum
- [ ] Enum 구현
- [ ] Enum 적용 클래스
- [ ] Enum 테스트
- [ ] Enum 적용 클래스

## Entity

## UseCase
- [ ] UseCase 클래스
- [ ] Mediator 패턴?

## Logs

<br/>

---
- [ ] xUnit Shared 클래스 이름 변경
- [ ] 단위 테스트 이름 형식 변경
  - T1: Arrange, 주체
  - T2: Act, 시나리오
  - T3: Assert, 결과
- [ ] Result 타입 구현
  - Result
  - ValidationResult
- [ ] BaseType 타입 구현
  - ValueObject
  - Enum..
  - Entity
  - AggregateRoot
  - DomainEvent
  - ...
---
- Outbox BackgroundJob N개?
---
- [x] Background 서비스
- [x] Background 테스트?
---
- [x] appsettings.json 테스트 시나리오 추가
- [x] 의존성 호출 순서?
  ```
  services
    .AddTransient(_ => configuration)
    .RegisterAdapterInfrastructureLayer();
  ```
---
- docusaurus 업데이트
---
- 도커 컴포즈
- appsettings.json 환경변수
- appsettings.json 볼륨 매핑

## DDD
### 레이어
- [x] 테스트 레이어 정의
  ```
	서비스 프로젝트 : Unit = 1 : 1
	서비스 프로젝트 : Integration = 1 : 1
	서비스 : E2E = 1 : 1
	```
  - `Unit`
  - `Integration`
  - `E2E`
- [x] 프로젝트 레이어 정의
  - `Adapter`: Infrastructure, Persistence, Presentation
  - `Application`
	- `Domain`
- [x] 레이어 관계 테스트

### 의존성
- [x] Registration -> Register
  ```cs
  namespace Microsoft.Extensions.DependencyInjection;
  ```
- [X] 의존성 주입 규칙
- [x] 레이어 관계(의존성) 단위 테스트
- [x] 어셈블리 정의
  ```cs
  public static class AssemblyReference
	{
		public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
	}
  ```

### 설정
- [ ] 옵션 값 검증 Fluent화: throw 패키지?
- [ ] 옵션 값 검증 name 이해?
  ```cs
	public ValidateOptionsResult Validate(string? name, DatabaseOptions options)
	```
- [ ] 테스트 프로젝트에서 `IWebHostEnvironment` 의존성 주입 실패
  ```
	internal sealed class DatabaseOptionsSetup(
    IConfiguration configuration,
    IWebHostEnvironment environment)
    : IConfigureOptions<DatabaseOptions>
	```
- [x] `appsettings.json` 메모리 기반 단위 테스트 + 레이어 의존성
- [x] `appsettings.Test.json` 통합 테스트 자동화
  ```
	ICollectionFixture
	-> CollectionDefinition
	-> Collection
	```
- [x] `launchSettings.json` -> `appsettings.json`
  ```
	DOTNET_ENVIRONMENT
	ASPNETCORE_ENVIRONMENT
	```
- [x] 옵션 관심사의 분리
  - 옵션 값: `T`
  - 옵션 값 구성: `IConfigureOptions<T?`
  - 옵션 값 검증: `IValidateOptions<T>`

### 로그
- [ ] two?
- [ ] 예외
- [ ] 기본 정보
- [ ] 자동 생성

### Adapter <-> Application 느슨한 연결(Mediator 패턴)
- [ ] MediatR
  - 메시지
  - 이벤트
- [ ] MediatR Behavior
  - 예외
  - 장시간 연산 로그
  - 유효성 검사
- [ ] DTO

### 기본 타입
- [ ] 결과 타입 | Result
- [ ] 결과 타입 | Error
- [ ] 결과 타입 | ValidationResult
---
- [ ] Domain 타입 | ValueObject
- [ ] Domain 타입 | Enum
---
- [ ] Domain 타입 | Entity
- [ ] Doamin 타입 | (Domain Service)
- [ ] Domain 타입 | AggregateRoot
- [ ] Domain 타입 | Domain Event
---
- [ ] Application service(UseCase)
  - UseCases 폴더
  - UseCase 사례 이미지
  - UseCase Known/Unknown(Side Effect) 출력
    - Known: 리턴 타입
    - Unknown: ?

### Adapters
- [ ] EfCore
- [ ] Specification Pattern?
- [ ] RabbitMQ
- [ ] WebApi
  - 인증
  - 문서화 swagger
  - Pipeline
- [ ] WebApi Background 서비스
- [ ] Blazor



## 빌드
| 구분             | Host CI  | CI     | CI Badge | CI History | CI PR  | CD Release | CD Deployment  |
|-----------------|----------|---------|----------|-----------|---------|------------|----------------|
| **빌드**         | 완료     | 완료    | 완료      | -         |        |   -        |  -             |
| **테스트**       | 완료     | 완료    | -        | -         |         |    -       |  -             |
| **코드 커버리지** | 완료     | 완료    | 완료     | 완료      |         |           |                 |
| **코드 스타일**   |         |        | -         | -         |         |   -       |  -              |
| **코드 매트릭**   | 개선     |        | -         | -         |        |           |  -              |
| **코드 중복**    |          |        | -         | -         |         |           |  -              |
| **코드 문서**    | 완료      | 완료   | -        | -          |         |  -        | 완료(GitHug Page) |
| **패키지**       |          |        |           | -         |         |           |                 |
| **컨테이너**     |          |        |           | -         |         |           |                 |

- [x] GitHub Actions 빌드
- [x] GitHub Actions 코드 커버리지 Summary
- [x] GitHub Actions 코드 커버리지 History(Codecov)
- [x] GitHub Actions 코드 커버리지 Artifact
- [x] GitHub Actions 코드 테스트
- [x] PowerShell 빌드
- [x] PowerShell 코드 커버리지
- [x] 중앙 패키지 관리: `Directory.Packages.props`
- [x] 중앙 빌드 관리: `Directory.Build.props`
- [x] 전역 SDK 설치: `global.json`
- [x] GitHub Page 배포
- [ ] pull-request
- [x] GitHub Packages 읽기
  - https://www.dotnetcurry.com/dotnetcore/custom-dotnet-code-github-actions
- [x] GitHub 키
  ```
  GitHub → User → Settings → Developer settings

  Personal access tokens → Tokens (classic)
    [Generate new token]
      Note: GITHUB_TOKEN
      Expiration: No expiration

      write:packages
      read:packages
  ```
- [ ] GitHub Packages 배포
- [ ] 도커 컨테이너 배포
  - [Publish .NET Docker images using .NET SDK and GitHub Actions](https://laurentkempe.com/2023/10/30/publish-dotnet-docker-images-using-dotnet-sdk-and-github-actions/)
- [ ] 코딩 스타일
  - https://hackernoon.com/how-to-use-common-editorconfig-as-a-nuget-package
  - https://devzone.channeladam.com/notebooks/languages/dotnet/editorconfig-distribution/?ref=hackernoon.com
  - https://github.com/thomasgalliker/Superdev.Editorconfig/tree/develop
  - https://hackernoon.com/how-to-use-common-editorconfig-as-a-nuget-package
- [ ] 코드 중복
- [ ] GitHub 패키지 배포
- [ ] GitHub 컨테이너 배포
- [ ] GitHub Actions 코드 품질
- [ ] Pull Request: https://devs0n.tistory.com/25

## 솔루션 템플릿
```shell
dotnet new install .\
dotnet new uninstall

dotnet new list
```

## 문서화
- [X] 특정 버전 사이트 생성
- [X] docs 메뉴 생성 `_category_.json`
- [x] docs 페이지 생성 `sidebar_position`
- [x] docs 폴더 페이지이지를 위한 폴더 구성 `숫자-폴더 이름`
- [x] GitHub Actions 연동
- [x] BaseUrl 이해
- [x] blog 문서 순서 이해
- [x] 바닥글
- [x] GitHub 페이지 바로 편집
- [x] docusaurus blog 페이지 제거
- [ ] docusaurus 엔진 업데이트
- [ ] 시작 페이지 타이틀 배경 색상
- [ ] docs 폴더 이름 변경
- [ ] blog 폴더 이름 변경
- [ ] blog 페이지 Count 증가시?
- [ ] 버전
- [ ] 다국어
- [ ] 한국어 검색 Web
- [ ] 한국어 검색 Host
- [ ] 이미지 확대
- [ ] 소스 바로보기?
- [ ] drawio
- [ ] mermaid
- [ ] mermaid(C4 Model)
- [ ] PDF
---
- https://github.com/Bloom-host/BloomDocs
- https://docusaurus.io/ko/docs

## 테스트
- [x] 테스트 범주화: `Trait`
- [x] 코드 커버리지: `Codecov`
- [x] 레이어 관계 테스트: ``
- [ ] 코드 커버리지 Build.ps1 ?% 출력
- [ ] 아키텍처 네이밍 규칙 테스트
- [ ] BDD 시나리오 테스트
- [ ] mutation testing  dotnet-stryker?
- [ ] 단위 테스트
- [ ] 통합 테스트 ASP.NET Core: https://github.com/JasperFx/alba
- [ ] 통합 테스트 API Signature(PublicApiGenerator)
- [ ] E2E 테스트
- [ ] 성능 테스트
- [ ] Arrange
  - [ ] Fake
  - [ ] 생성자?
- [ ] Assert
  - [ ] Snapshot 테스트
- [ ] 컨테이너
- [ ] Trace 테스트
- [ ] 의존성
  - [ ] 네트워크 | WebApi
  - [ ] 네트워크 | gRPC
  - [ ] 네트워크 | FTP
  - [ ] 데이터 저장소 | FileSystem
  - [ ] 데이터 저장소 | PostgreSQL
  - [ ] 이벤트 브로커 | RabbitMQ
  - [ ] 이벤트 브로커 | Kafka

## 시스템
- [ ] 호스트 Metrics
- [ ] 컨테이너 Metrics
- [ ] 호스트 Logs
- [ ] 컨테이너 Logs <-- 서비스
- [ ] 컨테이너 HealthCheck

## 플랫폼
- [ ] Host
- [ ] WSL
- [ ] Docker
- [ ] WSL + Docker


## ?
- IClaimsTransformation

## 목차
- 솔루션 구성
  - 솔루션 설정
    - 문서화: Class Diagram, C4, Context Mapper
  - 솔루션 배포
    - 컨테이너: WSL2, Docker
    - 패키지: NuGet
  - 솔루션 CI/CD
  - 솔루션 시스템
- 도메인 레이어
  - Validation
  - AggregateRoot
  - Domain Event
  - Entity
  - Domain Service
  - ValueObject
  - Enumeration
- 애플리케이션 레이어
  - Application Service(UseCase)
  - Repository
- 어댑터 레이어
  - EFCore
  - HttpClient
- 호스트 레이어
  - 컨테이너
  - Console
  - IHostedService
  - WebApi
  - Web
  - Desktop
- 테스트
  - 코드 커버리지
  - 아키텍처 테스트
  - 단위 테스트
  - 통합 테스트
    - ASP.NET Core: https://github.com/JasperFx/alba
  - E2E 테스트
  - 성능 테스트
  - 시나리오 테스트
  - Arrange
    - Fake
    - 생성자?
  - Assert
    - Snapshot 테스트
  - 컨테이너
  - API
    - API Signature(PublicApiGenerator)
  - Trace 테스트
  - 의존성
    - 네트워크
      - WebApi
      - gRPC
      - FTP
    - 데이터 저장소
      - FileSystem
      - PostgreSQL
    - 이벤트 브로커
      - RabbitMQ
      - Kafka



## 아키텍처
### 템플릿 이해
- [ ] [clean-architecture-demo/repo-and-uow](https://github.com/matthewrenze/clean-architecture-demo)
- [ ] [jasontaylordev/CleanArchitecture](https://github.com/jasontaylordev/CleanArchitecture/)
- [ ] [ardalis/CleanArchitecture](https://github.com/ardalis/CleanArchitecture/)
- [ ] [amantinband/CleanArchitecture](https://github.com/amantinband/clean-architecture)
- [ ] [fullstackhero/dotnet-webapi-starter-kit](https://github.com/fullstackhero/dotnet-webapi-starter-kit)
- [ ] [eShopOnWeb](https://github.com/dotnet-architecture/eShopOnWeb)

### DDD 학습
- [ ] [DDD-NoDuplicates](https://github.com/ardalis/DDD-NoDuplicates/tree/master)
- [ ] [iDDD](https://github.com/VaughnVernon/IDDD_Samples_NET)

### 템플릿 변환
- [ ] [jasontaylordev/CleanArchitecture](https://github.com/jasontaylordev/CleanArchitecture/)
- [ ] [ardalis/CleanArchitecture](https://github.com/ardalis/CleanArchitecture/)
- [ ] [amantinband/CleanArchitecture](https://github.com/amantinband/clean-architecture)
- [ ] [fullstackhero/dotnet-webapi-starter-kit](https://github.com/fullstackhero/dotnet-webapi-starter-kit)
- [ ] [eShopOnWeb](https://github.com/dotnet-architecture/eShopOnWeb)

## 문서
### 테스트
- [x] [The Testing Pyramid: How to Structure Your Test Suite](https://semaphoreci.com/blog/testing-pyramid)

### appsettings 테스트
- [ ] [Mocking your appsettings in unit tests on .NET](https://medium.com/@TheLe0/mocking-your-appsettings-in-unit-tests-on-net-cb057de7db64)
- [ ] [Accessing Configuration in .NET Core Test Projects](https://weblog.west-wind.com/posts/2018/Feb/18/Accessing-Configuration-in-NET-Core-Test-Projects)
- [ ] [](https://gunnarpeipman.com/aspnet-core-integration-tests-appsettings/)
- [ ] [Using custom startup class with ASP.NET Core integration tests](https://gunnarpeipman.com/aspnet-core-integration-test-startup/)
- [ ] [Custom appsettings.json File for ASP.NET Core Integration Tests](https://dzone.com/articles/custom-appsettingsjson-file-for-aspnet-core-integr)

### 설계
- [ ] [designing-with-types](https://fsharpforfunandprofit.com/series/designing-with-types/)
- [ ] [Nesting a Value Object inside an Entity](https://enterprisecraftsmanship.com/posts/nesting-value-object-inside-entity/)
- [ ] [Discriminated Unions in C#](https://ijrussell.github.io/posts/csharp-discriminated-union/)
- [ ] [Functional BDD 1/3](https://medium.com/@bddkickstarter/functional-bdd-5014c880c935)
- [ ] [Functional BDD 2/3](https://medium.com/@bddkickstarter/functional-bdd-part-2-the-gherkin-type-provider-731c7df3653e)
- [ ] [Functional BDD 3/3](https://medium.com/@bddkickstarter/functional-bdd-part-3-scenario-outlines-feature-validation-c73b9972924d)
- [ ] [지속 가능한 소프트웨어 설계 패턴: 포트와 어댑터 아키텍처 적용하기](https://engineering.linecorp.com/ko/blog/port-and-adapter-architecture)
- [ ] [지속 가능한 소프트웨어 설계 패턴: DDD + Hexagonal Architecture](https://velog.io/@roo333/%EC%A7%80%EC%86%8D-%EA%B0%80%EB%8A%A5%ED%95%9C-%EC%86%8C%ED%94%84%ED%8A%B8%EC%9B%A8%EC%96%B4-%EC%84%A4%EA%B3%84-%ED%8C%A8%ED%84%B4-Hexagonal-Architecture)
- [ ] [헥사고날 아키텍처(Hexagonal Architecture) : 유연하고 확장 가능한 소프트웨어 디자인 ](https://tech.osci.kr/hexagonal-architecture/)
- [ ] [헥사고날(Hexagonal) 아키텍처 in 메쉬코리아](https://mesh.dev/20210910-dev-notes-007-hexagonal-architecture/)

### 컨테이너
- [ ] [Use Docker Compose Named Volumes as Non Root within your containers](https://pratikpc.medium.com/use-docker-compose-named-volumes-as-non-root-within-your-containers-1911eb30f731)

### 테스트
- [ ] [Using xUnit to Test your C# Code](https://auth0.com/blog/xunit-to-test-csharp-code/)


## Scott Wlaschin
- [x] [Moving IO to the edges of your app: Functional Core, Imperative Shell - Scott Wlaschin](https://www.youtube.com/watch?v=P1vES9AgfC4&t=3140s)

```
info: Quartz.Core.SchedulerSignalerImpl[0]
      Initialized Scheduler Signaller of type: Quartz.Core.SchedulerSignalerImpl
info: Quartz.Core.QuartzScheduler[0]
      Quartz Scheduler created
info: Quartz.Core.QuartzScheduler[0]
      JobFactory set to: Quartz.Simpl.MicrosoftDependencyInjectionJobFactory
info: Quartz.Simpl.RAMJobStore[0]
      RAMJobStore initialized.
info: Quartz.Impl.StdSchedulerFactory[0]
      Quartz Scheduler 3.9.0.0 - 'QuartzScheduler' with instanceId 'NON_CLUSTERED' initialized
info: Quartz.Impl.StdSchedulerFactory[0]
      Using thread pool 'Quartz.Simpl.DefaultThreadPool', size: 10
info: Quartz.Impl.StdSchedulerFactory[0]
      Using job store 'Quartz.Simpl.RAMJobStore', supports persistence: False, clustered: False
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:54011
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: 고형호
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Workspace\Github\ArchDdd\src\ArchDdd
info: Quartz.Core.QuartzScheduler[0]
      Scheduler QuartzScheduler_$_NON_CLUSTERED started.
```

```
- 대상: 함께 이해하고 있어야 하는 것  
  `Expert developers' shared understanding of the system design`  
  전문 개발자들은 시스템 디자인에 대한 지식을 공유한다.
- 조건: 바꾸기 어려운 것  
  - `The set of design decisions that must be made early"  
    아키텍처 디자인은 우선적으로 진행되어야 한다.
  - `The decisions that you wish you could get right early`
    올바른 결정은 더 빨리 내려지는 것을 원한다.
  - `The decisions that are hard to change`
    결정은 변경하기 어렵다.
- 정의  
  `The important stuff whatever that is"  
  뭐든간에 중요한 것을
```