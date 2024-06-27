# 할일

1. **솔루션 구성**
   - 솔루션 설정
     - [ ] 빌드 버전
     - [ ] 빌드 옵션
     - [ ] 패키지 버전
     - [ ] appsettings.json/launchSettings.json
   - 프로젝트 레이어
     - [ ] 레이어 이름 규칙
     - [ ] 레이어 의존성 등록
     - [ ] 어셈블리
   - 코드 매트릭
     - [ ] 코드 정적 분석
     - [ ] 코드 커버리지
   - 코드 스타일
     - [ ] 코드 스타일 규칙
     - [ ] 코드 포맷
   - 코드 다이어그램
     - [ ] 프로젝트 다이어그램
     - [ ] 데이터베이스 스키마 다이어그램
     - [ ] 중요 인터페이스 클래스 다이어그램
1. **도메인 레이어**
   - 소스 생성기
     - [ ] EntityId
     - [ ] EFCore Converter
   - 기본 타입
     - [ ] Value Object
     - [ ] Entity
     - [ ] EntityId
     - [ ] Auditable
     - [ ] Aggregate Root
     - [ ] Domain Event
     - [ ] Enumeration(패키지 도입)
     - [ ] Specification
   - 출력 타입(패키지 도입?)
     - [ ] Result
     - [ ] ValidationResult
     - [ ] Error
1. **애플리케이션 레이어**
   - 패턴
     - [ ] Mediator 패턴
     - [ ] Decorator 패턴
     - [ ] Stragegy 패턴
     - [ ] Unit of Work 패턴(Repository 패턴)
     - [ ] OutBox 패턴
     - [ ] CQRS 패턴
   - Pipeline(Decorator 패턴)
     - [ ] UseCase 성공/실패 로그
     - [ ] Long 처리 UseCase 로그
     - [ ] UseCase 예외 처리
     - [ ] Unit of Work 패턴
   - 기본 인터페이스(Stragegy 패턴)
     - [ ] ICommandUseCase
     - [ ] IQueryUseCase
     - ?
   - Command 유스케이스
     - [ ] 입력 메시지
     - [ ] 입력 메시지 유효성 검사
     - [ ] 입력 유스케이스
     - [ ] 입력 유스케이스 구현 패턴
       - [ ] 유스케이스 유효성 검사
       - [ ] 임시 SQL 결과 타입
       - [ ] 외부 환경 결과 -> Validator 통합
     - [ ] 매핑
     - [ ] 출력 메시지
   - Query 유스케이스
     - [ ] Dapper(SQL)
     - [ ] 임시 SQL 출력 타입
   - Repository 패턴
     - [ ] Set vs. DbSet
     - [ ] 
   - Event
     - [ ] ?
   - Validator
     - [ ] ?
1. **어댑터 레이어**
   - 운영
     - [ ] Container
     - [ ] Background Job
   - Web
     - [ ] WebApi(FastEndpoints?)
     - [ ] Swagger
   - Message
     - [ ] RabbitMQ
   - Database
     - [ ] PostgreSQL
     - [ ] Sqlite
     - [ ] Cache
   - Network
     - [ ] FtP
     - [ ] gRPC
   - Resource
     - [ ] 다국어
1. **Test Automation**
   - 코드 커버리지
     - [ ] Console
     - [ ] HTML
     - [ ] GitHub
   - 단위 테스트
     - [ ] 의존성
     - [ ] 코딩컨벤션
   - 통합 테스트
     - [ ] 옵션
   - 통합 테스트, 운영
     - [ ] Container
     - [ ] Background Job
   - 통합 테스트, Web
     - [ ] WebApi(FastEndpoints?)
     - [ ] Swagger
   - 통합 테스트, Message
     - [ ] RabbitMQ
   - 통합 테스트, Database
     - [ ] PostgreSQL
     - [ ] Sqlite
     - [ ] Cache
   - 통합 테스트, Network
     - [ ] FtP
     - [ ] gRPC
   - 통합 테스트, Resource
     - [ ] 다국어
   - 통합 테스트, 성능 테스트
     - [ ] ?
   - E2E 테스트
     - [ ] ?
1. **Container**
   - 솔루션
     - [ ] WebApi
   - 외부 환경
     - [ ] RabbitMQ
     - [ ] PostgreSQL
     - [ ] Sqlite
     - [ ] FtP
1. **Observability**
   - Logs
     - [ ] Windows Logs
     - [ ] Ubuntu Logs
     - [ ] Container Logs
     - [ ] Json Logs
     - [ ] Exception 로그
   - Metrics
     - [ ] Windows Metrics
     - [ ] Ubuntu Metrics
     - [ ] Container Metrics
   - Traces
     - [ ] WebApi 서버
     - [ ] Web
   - Health Check
     - [ ] Container
       - [Clean Architecture Template, SSW](https://github.com/SSWConsulting/SSW.CleanArchitecture)
     - [ ] WebApi
     - [ ] PostgreSQL
     - [ ] RabbitMQ
     - [ ] FTP
   - System
     - [ ] OpenSearch
     - [ ] Prometheus
     - [ ] Grafana
     - [ ] Trace?
1. **CI/CD**
   - 코드 매트릭
     - [ ] 코드 정적 분석
     - [ ] 코드 커버리지
   - 코드 스타일
     - [ ] 코드 스타일 규칙
     - [ ] 코드 포맷
   - 코드 다이어그램
     - [ ] 프로젝트 다이어그램
     - [ ] 데이터베이스 스키마 다이어그램
     - [ ] 중요 인터페이스 클래스 다이어그램
1. 사례
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

```
사용자_정의_입력(Primitive 매개변수, 사용자 정의 DTO, ...)
  : IRequest<출력_Primitive 매개변수 or 출력_사용자 정의 DTO>

Assembly.GetExecutingAssembly()
```
