# 할일

## 로드맵
- **1단계**: 템플릿 생성(_현재_)
  - 기능 구현
  - 기능 예제
  - 템플릿
  - 문서
- **2단계**: 템플릿 검증
  - 템플릿 적용
  - 문서
- **3단계**: 템플릿 확대
  - Blazor
  - MAUI

## 솔루션 구성
### 솔루션 설정
- [x] 빌드 버전
- [x] 빌드 옵션
- [x] 패키지 버전
- [ ] appsettings.json/launchSettings.json
### 프로젝트 레이어
- [ ] 레이어 이름 규칙
- [ ] 레이어 의존성 등록
- [x] 어셈블리
### 코드 매트릭
- [ ] 코드 정적 분석
- [ ] 코드 커버리지
### 코드 스타일
- [ ] 코드 스타일 규칙
- [ ] 코드 포맷
### 코드 다이어그램
- [ ] 프로젝트 참조 다이어그램
- [ ] 데이터베이스 스키마 다이어그램
- [ ] 중요 인터페이스 클래스 다이어그램

## 도메인 레이어
### 소스 생성기
- [ ] EntityId
- [ ] EFCore Converter
### 기본 타입
- [ ] Value Object
- [ ] Entity
- [ ] EntityId
- [ ] Auditable
- [ ] Aggregate Root
- [ ] Domain Event
- [ ] Enumeration(패키지 도입)
- [ ] Specification
### 출력 타입(패키지 도입?)
- [ ] Result
- [ ] ValidationResult
- [ ] Error

## 애플리케이션 레이어
### 패턴
- [ ] Mediator 패턴
- [ ] CQRS 패턴
- [ ] Decorator 패턴
- [ ] Strategy 패턴
- [ ] Publish/Subscribe 패턴
- [ ] Repository패턴
- [ ] Unit of Work 패턴(Repository 패턴)
- [ ] OutBox 패턴
- [ ] 재시도
- [ ] DI
### Pipeline(Decorator 패턴)
- [ ] UseCase 성공/실패 로그
- [ ] Long 처리 UseCase 로그
- [ ] UseCase 예외 처리
- [ ] Unit of Work 패턴
### 기본 인터페이스(Strategy 패턴)
- [ ] ICommandUseCase
- [ ] IQueryUseCase
- [ ] ?
### Command 유스케이스
- [ ] 입력 메시지
- [ ] 입력 메시지 유효성 검사
- [ ] 입력 유스케이스
- [ ] 입력 유스케이스 구현 패턴
  - [ ] 유스케이스 유효성 검사
  - [ ] 임시 SQL 결과 타입
  - [ ] 외부 환경 결과 -> Validator 통합
- [ ] 매핑
- [ ] 출력 메시지
### Query 유스케이스
- [ ] Dapper(SQL)
- [ ] 임시 SQL 출력 타입
### Repository 패턴
- [ ] Set vs. DbSet
- [ ] ?
### Event
- [ ] ?
### Validator
- [ ] ?

## 어댑터 레이어
### 운영
- [ ] Container
- [ ] Background Job
### Web
- [ ] WebApi(FastEndpoints?)
- [ ] Swagger
### Message
- [ ] RabbitMQ
### Database
- [ ] PostgreSQL
- [ ] Sqlite
- [ ] Cache
### Network
- [ ] FtP
- [ ] gRPC
### Resource
- [ ] 다국어

## Test Automation
### 코드 커버리지
- [ ] Console
- [ ] HTML
- [ ] GitHub
### 단위 테스트
- [ ] 의존성
- [ ] 코딩컨벤션
- [ ] Fake 데이터 자동 생성기
### 통합 테스트
- [ ] 옵션
### 통합 테스트, 운영
- [ ] Container
- [ ] Background Job
### 통합 테스트, Web
- [ ] WebApi(FastEndpoints?)
- [ ] Swagger
### 통합 테스트, Message
- [ ] RabbitMQ
### 통합 테스트, Database
- [ ] PostgreSQL
- [ ] Sqlite
- [ ] Cache
### 통합 테스트, Network
- [ ] FtP
- [ ] gRPC
### 통합 테스트, Resource
- [ ] 다국어
### 통합 테스트, 성능 테스트
- [ ] ?
### E2E 테스트
- [ ] ?

## Container
### 솔루션
- [ ] WebApi
### 외부 환경
- [ ] RabbitMQ
- [ ] PostgreSQL
- [ ] Sqlite
- [ ] FTP
- [ ] Cache

## Observability
### Logs
- [ ] Windows Logs
- [ ] Ubuntu Logs
- [ ] Container Logs
- [ ] Json Logs
- [ ] Exception 로그
### Metrics
- [ ] Windows Metrics
- [ ] Ubuntu Metrics
- [ ] Container Metrics
### Traces
- [ ] WebApi 서버
- [ ] Web
### Health Check
- [ ] Container
  - [Clean Architecture Template, SSW](https://github.com/SSWConsulting/SSW.CleanArchitecture)
- [ ] WebApi
- [ ] PostgreSQL
- [ ] RabbitMQ
- [ ] FTP
### System
- [ ] OpenSearch
- [ ] Prometheus
- [ ] Grafana
- [ ] Trace?

## CI/CD
### 코드 매트릭
- [ ] 코드 정적 분석
- [ ] 코드 커버리지
### 코드 스타일
- [ ] 코드 스타일 규칙
- [ ] 코드 포맷
### 코드 다이어그램
- [ ] 프로젝트 다이어그램
- [ ] 데이터베이스 스키마 다이어그램
- [ ] 중요 인터페이스 클래스 다이어그램

```
  - 솔루션 설정
    - [x] 빌드 버전
    - [x] 빌드 옵션
    - [x] 패키지 버전
    - [ ] 옵션, development까지 반영?
    - [ ] 코드 정적 분석
    - [ ] 코딩컨벤션    
    - [ ] 코드 중복도
    - [ ] 도커 컴포즈
  - 솔루션 구성
    - [ ] 레이어
    - [x] 레이어 의존성 시각화 https://github.com/nkolev92/DependencyVisualizer
    - [x] 레이어 의존성 테스트  
  - 솔루션 디자인 패턴
    - [ ] Stragegy 패턴
    - [ ] Docorator 패턴
    - [ ] Mediator 패턴
    - [ ] CQRS 패턴
    - [ ] Repository 패턴
    - [ ] Unit of Work 패턴
    - [ ] OutBox 패턴
    - [ ] Cache Aside 패턴
    - [ ] Saga?
    - [x] 레이어 통합 Mediator 패턴
    - [x] 레이어 통합 CQRS 패턴
    - [x] 유스케이스 파이프라인 입력 유효성 검사
    - [ ] 유스케이스 파이프라인 Command 트랜잭션
    - [x] 유스케이스 파이프라인 성공/실패 로그
    - [x] 유스케이스 파이프라인 예외 처리
    - [x] 유스케이스 파이프라인 긴 작업 로그
    - [x] 유스케이스 Query DTO
  - 솔루션 테스트
    - [x] 애플리케이션 레이어 테스트(단위 테스트: 값, 코딩컨벤션, 의존성)
    - [x] 어답터 레이어 테스트(통합 테스트)
    - [ ] 어답터 레이어 컨테이너 기반 테스트(통합 테스트: Container, WebApi, RabbitMQ, PostgreSQL, ...)
    - [ ] 어답터 레이어 컨테이너 기반 성능 테스트(통합 테스트)
    - [ ] E2E 테스트
  - CI/CD
  - Observability
  - Modular Monoliths
```

## 학습
### 컨테이너
- [ ] [.NET 앱 컨테이너화](https://learn.microsoft.com/ko-kr/dotnet/core/docker/build-container?tabs=windows&pivots=dotnet-8-0)
- [ ] [.NET Core Diagnostics Tools and Containers](https://www.nocture.dk/2020/06/17/dotnetcore-diagnostics-tools-and-containers/)
- [ ] [Dockerfile](https://gist.github.com/sandcastle/faa4e0bf1f8e8d5fc6506d1c5dbb1f45)
- [ ] [Tracing and Profiling a .NET Core Application on Azure Kubernetes Service with a Sidecar Container](https://thecloudblog.net/post/tracing-and-profiling-a-net-core-application-on-azure-kubernetes-service-with-a-sidecar-container/)
- [ ] [.NET 8 - ASP.NET Core Metrics](https://community.abp.io/posts/asp.net-core-metrics-with-.net-8.0-1xnw1apc)
---
- [ ] [2022.05.22 Getting telemetry data from inside or outside a .NET application](https://www.meziantou.net/getting-telemetry-data-from-inside-or-outside-a-dotnet-application.htm)
- [ ] [2021.11.15 Monitoring a .NET application using OpenTelemetry](https://www.meziantou.net/monitoring-a-dotnet-application-using-opentelemetry.htm)


### 아키텍처
- [ ] [Clean Architecture Template, Ardalis](https://github.com/ardalis/CleanArchitecture)
- [ ] [Clean Architecture Template, Amichai Mantinband](https://github.com/amantinband/clean-architecture)
- [ ] [Clean Architecture Template, Jason Taylordev](https://github.com/jasontaylordev/CleanArchitecture)
- [ ] [Clean Architecture Template, SSW](https://github.com/SSWConsulting/SSW.CleanArchitecture)
  ```
  Application
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
      services.AddMediatR(config =>
      {
          config.AddOpenBehavior(typeof(UnhandledExceptionBehaviour<,>));      <- 어셈블리 기준
          config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
          config.AddOpenBehavior(typeof(PerformanceBehaviour<,>));
      });
      return services;
  }
  ```
- [ ] [Clean Architecture Template, Phong Nguyen](https://github.com/phongnguyend/Practical.CleanArchitecture)
- [ ] [Clean Architecture Template, Casey](https://github.com/cbcrouse/CleanArchitecture)
- [ ] [modular-monolith-with-ddd](https://github.com/kgrzybek/modular-monolith-with-ddd)
- [ ] [VerticalSliceArchitecture](https://github.com/nadirbad/VerticalSliceArchitecture/tree/main)
- [ ] [.NET-Domain-Driven-Design-Template](https://github.com/evgenirusev/.NET-Domain-Driven-Design-Template)
- [ ] [modulith](https://github.com/ardalis/modulith)

### DDD
- 도메인 로직(비즈니스 로직)
  - [Business logic](https://en.wikipedia.org/wiki/Business_logic)
  - [비즈니스 로직, 도메인 로직이 도대체 뭐지?](https://velog.io/@eddy_song/domain-logic)
  - [비즈니스 로직(Business Logic)이란?](https://mommoo.tistory.com/67)
  - Vladimir Khorikov
    - [What is domain logic?](https://enterprisecraftsmanship.com/posts/what-is-domain-logic/)
    - [Domain model isolation](https://enterprisecraftsmanship.com/posts/domain-model-isolation/)
    - [How to know if your Domain model is properly isolated?](https://enterprisecraftsmanship.com/posts/how-to-know-if-your-domain-model-is-properly-isolated/)
  - CodeOpinion
    - [Domain Logic: Where does it go?](https://codeopinion.com/domain-logic-where-does-it-go/)
    - [STOP doing dogmatic Domain Driven Design](https://codeopinion.com/stop-doing-dogmatic-domain-driven-design/)
    - [Aggregate Design: Using Invariants as a Guide](https://codeopinion.com/aggregate-design-using-invariants-as-a-guide/)
    - [Aggregate (Root) Design: Behavior & Data](https://codeopinion.com/aggregate-root-design-behavior-data/)
- 유효한(Valid)
  - Vladimir Khorikov
    - [Validation and DDD](https://enterprisecraftsmanship.com/posts/validation-and-ddd/)
    - [Always-Valid Domain Model](https://enterprisecraftsmanship.com/posts/always-valid-domain-model/)
    - [Always valid vs not always valid domain model](https://enterprisecraftsmanship.com/posts/always-valid-vs-not-always-valid-domain-model/)
    - [C# code contracts vs input validation](https://enterprisecraftsmanship.com/posts/code-contracts-vs-input-validation/)
    - [Exceptions for flow control in C#](https://enterprisecraftsmanship.com/posts/exceptions-for-flow-control/)
    - [Advanced error handling techniques](https://enterprisecraftsmanship.com/posts/advanced-error-handling-techniques/)
    - [How to Strengthen Requirements for Pre-existing Data](https://enterprisecraftsmanship.com/posts/strengthening-requirements-pre-existing-data/)
- 객체지향(Object-Oriented): 캡슐화(역할과 책임), 메시지(협력), 다형성(런타임)
  - Vladimir Khorikov
    - [Encapsulation revisited](https://enterprisecraftsmanship.com/posts/encapsulation-revisited/)
    - [Cohesion and Coupling: the difference](https://enterprisecraftsmanship.com/posts/cohesion-coupling-difference/)
    - [Fail Fast principle](https://enterprisecraftsmanship.com/posts/fail-fast-principle)
    - [C# and F# approaches to illegal state](https://enterprisecraftsmanship.com/posts/c-and-f-approaches-to-illegal-state/)
- [tdd-ddd-demo-dotnet](https://github.com/chrissimon-au/tdd-ddd-demo-dotnet), [영상](https://www.youtube.com/watch?v=gXz7gKtRVpM)
- [Stop using Entity Framework as a DTO provider!](https://github.com/ChrisKlug/efcore-dto-demo/tree/main), [영상](https://www.youtube.com/watch?v=N_eLotlcjXo)
- [better-code-with-ddd](https://github.com/asc-lab/better-code-with-ddd/tree/ef_core)
- [DDD, D:](https://www.youtube.com/watch?v=0t6TcRCvtyE&t=326s)

### CQRS
- [CQRS in Practice](https://github.com/vkhorikov/CqrsInPractice)
- [dotnet-cqrs-intro](https://github.com/asc-lab/dotnet-cqrs-intro/tree/master)

### EFCore
- [ ] [SQL Queries](https://learn.microsoft.com/en-us/ef/core/querying/sql-queries#querying-scalar-non-entity-types)
- [ ] [EF8 – Row SQL returning Non-entities](https://www.codeproject.com/Articles/5379996/EF8-Row-SQL-returning-Non-entities)

### DDD
- [x] []DTO와 도메인을 분리해야 하는 이유](https://www.youtube.com/watch?v=OV8e88kIU-U&t)
- [x] [엄예림 - DTO | 백엔드 데브코스 5기](https://www.youtube.com/watch?v=Q3QGC-Llqr8)
- [ ] [Xer Projects](https://github.com/XerProjects)

### Test
- [ ] [Snapshot Testing in .NET with Verify](https://blog.jetbrains.com/dotnet/2024/07/11/snapshot-testing-in-net-with-verify/)
- [ ] [박정국 CTO가 알려주는 ‘서버 성능 측정 방법’ (포브스 선정, 신입 개발자, API, 백엔드)](https://www.youtube.com/watch?v=HSNyJnobBws)
- [ ] [[10분 테코톡] 베베, 허브의 성능 테스트](https://www.youtube.com/watch?v=3cTn53dtzJI)


## 예제
- [ ] [booking-microservices](https://github.com/meysamhadeli/booking-microservices)
  ```
  dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p password
  dotnet dev-certs https --trust
  ```
- [ ] [TodoApi](https://github.com/davidfowl/TodoApi)
- [ ] [IDDD_Samples_NET](https://github.com/VaughnVernon/IDDD_Samples_NET/tree/master)

```
사용자_정의_입력(Primitive 매개변수, 사용자 정의 DTO, ...)
  : IRequest<출력_Primitive 매개변수 or 출력_사용자 정의 DTO>

Assembly.GetExecutingAssembly()
```
```
The Tell Don't Ask Principle
https://giannisakritidis.com/blog/Tell-Dont-Ask/
```