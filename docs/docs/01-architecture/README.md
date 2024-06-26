## 할일

1. **솔루션 구성**
   - [ ] 솔루션 설정
     - [ ] 빌드 버전
     - [ ] 빌드 옵션
     - [ ] 패키지 버전
     - [ ] 코드 스타일
   - [ ] 프로젝트 레이어
     - [ ] 레이어 이름 규칙
     - [ ] 레이어 의존성
     - [ ] 어셈블리
   - [ ] 프로젝트 다이어그램
1. **도메인 레이어**
   - [ ] 기본 타입
     - [ ] Value Object
     - [ ] Entity
     - [ ] Aggregate Root
     - [ ] Domain Event
     - [ ] Enumeration
   - [ ] 출력 타입
     - [ ] Result
     - [ ] ValidationResult
     - [ ] Error
1. **애플리케이션 레이어**
   - [ ] Pipeline
     - [ ] UseCase 성공/실패 로그
     - [ ] Long 처리 UseCase 로그
     - [ ] UseCase 예외 처리
     - [ ] Unit of Work 패턴
   - [ ] 기본 인터페이스
     - [ ] ICommandUseCase
     - [ ] IQueryUseCase
     - ?
   - [ ] Command
     - [ ] 입력 메시지
     - [ ] 입력 메시지 유효성 검사
     - [ ] 입력 유스케이스
     - [ ] 입력 유스케이스 구현 패턴
       - [ ] 유스케이스 유효성 검사
       - [ ] 임시 SQL 결과 타입
       - [ ] 외부 환경 결과 -> Validator 통합
     - [ ] 매핑
     - [ ] 출력 메시지
   - [ ] Query
     - [ ] Dapper(SQL)
     - [ ] 임시 SQL 출력 타입
   - [ ] Repository 패턴
     - [ ] Set vs. DbSet
     - [ ] 
   - [ ] Event
     - ?
   - [ ] Validator
     - ?
1. **어댑터 레이어**
   - [ ] Repository
   - [ ] WebApi
1. **Test Automation**
   - [ ] 코드 커버리지
     - [ ] Console
     - [ ] HTML
     - [ ] GitHub
   - [ ] 단위 테스트
     - [ ] 의존성
     - [ ] 코딩컨벤션
   - [ ] 통합 테스트
     - [ ] Container
     - [ ] WebApi
     - [ ] RabbitMQ
     - [ ] PostgreSQL
     - [ ] Sqlite
     - [ ] FtP
   - [ ] 성능 테스트
   - [ ] E2E 테스트
1. **Container**
   - 솔루션
     - [ ] WebApi
   - 외부 환경
     - [ ] RabbitMQ
     - [ ] PostgreSQL
     - [ ] Sqlite
     - [ ] FtP
1. **Observability**
   - [ ] Logs
     - [ ] Windows Logs
     - [ ] Ubuntu Logs
     - [ ] Container Logs
     - [ ] Json Logs
   - [ ] Metrics
     - [ ] Windows Metrics
     - [ ] Ubuntu Metrics
     - [ ] Container Metrics
   - [ ] Traces
     - [ ] WebApi 서버
     - [ ] Web
   - [ ] Health Check
1. **CI/CD**
   - [ ] Code Metrics
   - [ ] Code Style
   - [ ] Code Diagram