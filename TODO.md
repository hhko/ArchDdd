- [x] 로컬 CI
- [x] GitHuab 코드 커버리지
- [ ] 코드 매트릭스 로컬
- [ ] 코드 매트릭스 GitHub
- [ ] 어셈블리
---
- [ ] WebApi 프로젝트
- [ ] 환경 설정 파일 읽기
- [ ] 환경 설정 파일 읽기 테스트 통합
---
- [ ] Background 서비스
---
- 코딩 스타일
- 코드 중복
----
- GitHub 패키지 배포
- GitHub 컨테이너 배포


<br/>

## 코딩 스타일
- [ ] https://hackernoon.com/how-to-use-common-editorconfig-as-a-nuget-package
- [ ] https://devzone.channeladam.com/notebooks/languages/dotnet/editorconfig-distribution/?ref=hackernoon.com
- [ ] https://github.com/thomasgalliker/Superdev.Editorconfig/tree/develop

## dotnet 템플릿
```shell
dotnet new install .\

dotnet new uninstall
```

### 참고 자료
- [ ] https://github.com/dotnet/templating/wiki
- [ ] https://devblogs.microsoft.com/dotnet/how-to-create-your-own-templates-for-dotnet-new/
- [ ] https://learn.microsoft.com/en-us/dotnet/core/tutorials/cli-templates-create-project-template

### 참고 동영상
- [ ] https://www.youtube.com/watch?v=GDNcxU0_OuE
- [ ] https://www.youtube.com/watch?v=3QBL5bWlOPw

### 참고 저장소
- [ ] https://github.com/sayedihashimi/dotnet-new-samples
- [ ] https://github.com/sayedihashimi/template-sample
- [ ] https://github.com/onelioubov/DotnetTemplateDemo
- [ ] https://github.com/ardalis/CleanArchitecture/tree/main
- [ ] https://github.com/sayedihashimi/dotnet-new-samples/tree/master
- [ ] https://devblogs.microsoft.com/dotnet/how-to-create-your-own-templates-for-dotnet-new/
- [ ] https://github.com/onelioubov/DotnetTemplateDemo


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

