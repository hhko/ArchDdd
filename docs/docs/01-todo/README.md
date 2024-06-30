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
  - [ ] 프로젝트 다이어그램
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
- [ ] Repository패턴
- [ ] Unit of Work 패턴(Repository 패턴)
- [ ] OutBox 패턴
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

## 사례
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
### DDD
- [tdd-ddd-demo-dotnet](https://github.com/chrissimon-au/tdd-ddd-demo-dotnet), [영상](https://www.youtube.com/watch?v=gXz7gKtRVpM)
- [Stop using Entity Framework as a DTO provider!](https://github.com/ChrisKlug/efcore-dto-demo/tree/main), [영상](https://www.youtube.com/watch?v=N_eLotlcjXo)
- [better-code-with-ddd](https://github.com/asc-lab/better-code-with-ddd/tree/ef_core)
### CQRS
- [CQRS in Practice](https://github.com/vkhorikov/CqrsInPractice)
- [dotnet-cqrs-intro](https://github.com/asc-lab/dotnet-cqrs-intro/tree/master)

## 학습
### DDD
- [x] []DTO와 도메인을 분리해야 하는 이유](https://www.youtube.com/watch?v=OV8e88kIU-U&t)
- [x] [엄예림 - DTO | 백엔드 데브코스 5기](https://www.youtube.com/watch?v=Q3QGC-Llqr8)

```
사용자_정의_입력(Primitive 매개변수, 사용자 정의 DTO, ...)
  : IRequest<출력_Primitive 매개변수 or 출력_사용자 정의 DTO>

Assembly.GetExecutingAssembly()
```
