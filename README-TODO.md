1. 아키텍처 개요
1. 솔루션 구성
   - 솔루션 빌드
     - 빌드 버전: global.json
     - 빌드 속성 중앙화: Directory.Build.props
     - 패키지 버전 중앙화: Directory.Packages.props
     - 패키지 소스: nuget.config
     - 코딩 컨벤션: .editor...
   - 폴더 구성
     - Common
     - Service
1. 패턴
   - 주요 패턴
     - CQRS
     - Decorator
     - Strategy
     - Unit of Work
     - Repository: DTO Direct(Query) VS. DTO Indirect(Command)
     - DTO
     - Validator
     - Result/Error
   - 부가 패턴
     - Outbox
     - Saga
1. 테스트
   - 단위 테스트
     - 아키텍처 테스트
     - 유스케이스 테스트
       - Moq
       - Fake 데이터
       - Verify
   - 통합 테스트
     - 컨테이너 기반
     - RabbitMQ
     - FTP
     - PostgreSQL
     - File
1. 컨테이너
   - 이름 규칙
   - system: Dockerfile
   - /tmp
   - watch: https://github.com/julielerman/DockerComposeWatchDemoMinimalAPI
1. 관찰 가능성
   - 로그
     - 운영체제
     - 컨테이너
     - 프로세스
   - 지표
     - 운영체제
     - 컨테이너
     - 프로세스 런타임
     - 프로세스 사용자 정의
   - 추적
1. SSG
   - https://gwon-dev.tistory.com/11
1. 문서
   - SRS
   - ADR 
     