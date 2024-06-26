# 링크

## 용어
- `Value Object` : 비즈니스 용어를 나타내는 불변 객체
- `Entity` : 속성이 아닌 식별성을 기준으로 정의되는 도메인 객체, 여러 Value Object로 구성(예: DB의 한 개 row)
- `Service` : 도메인 객체에 포함할 수 없는 오퍼레이션 연산을 갖는 객체
- `Aggregate` : 연관된 Value Object와 Entity의 묶음
- `Factory` : 복잡한 Entity, Aggregate를 캡슐화하여 여러 객체를 동시에 생성
- `Repository` : Aggregate의 영속성 및 등록·수정·삭제·조회 시 일관성 관리

## 한국어
- 영상 | [아키텍처 정의와 중요성](https://www.youtube.com/watch?v=4E1BHTvhB7Y)
- 영상 | [DTO와 도메인을 분리해야 하는 이유](https://www.youtube.com/watch?v=OV8e88kIU-U)
- 영상 | [DTO는 어디서 사용하지](https://www.youtube.com/watch?v=Q3QGC-Llqr8)
- 영상 | [클린아키텍쳐로 이사가기](https://www.youtube.com/watch?v=G5s1ZQiPBv8)
- 영상 | [지속 성장 가능한 코드를 만들어가는 방법](https://www.youtube.com/watch?v=RVO02Z1dLF8)
- 문서 | [마이크로서비스 내부아키텍처 - 1회 : 데이터 중심 아키텍처의 문제점](https://engineering-skcc.github.io/microservice%20inner%20achitecture/inner-architecture-1/)
- 문서 | [마이크로서비스 내부아키텍처 - 2회 : 클린 아키텍처와 헥사고널 아키텍처](https://engineering-skcc.github.io/microservice%20inner%20achitecture/inner-architecture-2/)
- 문서 | [마이크로서비스 내부아키텍처 - 3회 : 어플리케이션 구성 패턴](https://engineering-skcc.github.io/microservice%20inner%20achitecture/inner-architecture-3/)
- 문서 | [레거시 시스템의 새로운 비즈니스 가치 창출 - IT 현대화(Modernization) 방안과 사례](https://www.samsungsds.com/kr/insights/it_modernization.html?referrer=https://www.google.com/)
- 문서 | [박용우 1회, 제임스 루이스와 마틴 파울러의 MSA](https://www.datanet.co.kr/news/articleView.html?idxno=176304)
- 문서 | [박용우 2회, 처음부터 MSA로 시작하는 것은 위험하다](https://www.datanet.co.kr/news/articleView.html?idxno=177591)
- 문서 | [박용우 3회, 서비스 메시와 아키텍처 결정 포인트](https://www.datanet.co.kr/news/articleView.html?idxno=179757)
- 문서 | [박용우 4회, NCD 기반 애플리케이션 현대화](https://www.datanet.co.kr/news/articleView.html?idxno=181865)

## 아키텍처
### 아키텍처 기초
- [ ] 문서 | [아키텍처 (Architecture)란 무엇인가](https://brunch.co.kr/@taehyo/223)
  ```
  아키텍처는 다양한 영역과 관련된 의사결정의 집약체이며, 이후 이어질 활동에 대한 기준이 된다.
  ```
- [ ] 소스 | [code-maze, Hexagonal Architectural Pattern in C#](https://code-maze.com/csharp-hexagonal-architectural-pattern/)
- [ ] 소스 | [code-maze, Clean Architecture in .NET](https://code-maze.com/dotnet-clean-architecture/)
- [x] 문서 | [Do you keep your domain layer independent of the data access concerns?](https://www.ssw.com.au/rules/keep-your-domain-layer-independent-of-the-data-access-concerns/)
  ```
  개선 전
  - Attribute을 이용한 데이터베이스 제약 조건 정의
    [MaxLength(15)]
    public string City { get; set; }

  개선 후: 데이터베이스 제약 조건 분리
  - IEntityTypeConfiguration<T>
    Config(EntityTypeBuilder<T> builder)
    {
      builder.Property(e => e.City).HasMaxLength(15);
    }
  ```
- [x] 문서 | [Do you know when to use value objects?](https://www.ssw.com.au/rules/when-to-use-value-objects/)
  ```
  개선 전
  - string AcACCount { get; set; }

  개선 후: ValueObject(= logic + validation), ValueObject을 Entity 테이블에 통합
  - IEntityTypeConfiguration<T>
    Config(EntityTypeBuilder<T> builder)
    {
      builder.OwnsOne(e => e.AdAccount);
    }
  ```
- [ ] 문서 | [Do you use Strongly Typed IDs to avoid Primitive Obsession](https://www.ssw.com.au/rules/do-you-use-strongly-typed-ids/)
- [ ] 영상 | [This Is My FAVORITE Error Handling Class](https://www.youtube.com/watch?v=MiLN2vs2Oe0)

### 아키텍처 템플릿
- [ ] 소스 | [Clean Architecture Template, Ardalis](https://github.com/ardalis/CleanArchitecture)
- [ ] 소스 | [Clean Architecture Template, Amichai Mantinband](https://github.com/amantinband/clean-architecture)
- [ ] 소스 | [Clean Architecture Template, Jason Taylordev](https://github.com/jasontaylordev/CleanArchitecture)
- [ ] 소스 | [Clean Architecture Template, SSW](https://github.com/SSWConsulting/SSW.CleanArchitecture)
- [ ] 소스 | [Clean Architecture Template, Phong Nguyen](https://github.com/phongnguyend/Practical.CleanArchitecture)
- [ ] 소스 | [Clean Architecture Template, Casey](https://github.com/cbcrouse/CleanArchitecture)

### 아키텍처 예제
- [ ] 소스 | [sample-dotnet-core-cqrs-api, Kamil Grzybek](https://github.com/kgrzybek/sample-dotnet-core-cqrs-api?tab=readme-ov-file)
- [ ] 소스 | [MauiCleanTodos](https://github.com/matt-goldman/MauiCleanTodos)
- [ ] 소스 | [dotnet-modular-monolith](https://github.com/SSWConsulting/dotnet-modular-monolith)
- [ ] 소스 | [Clean-Architecture-with-.NET, PacktPublishing](https://github.com/PacktPublishing/Clean-Architecture-with-.NET/tree/main)
- [ ] 소스 | [TodoApi](https://github.com/davidfowl/TodoApi)


## 도메인 주도 설계
### 도메인 주도 설계 개념
- [ ] 문서 | Kamil Grzybek | [REST API DATA VALIDATION](https://www.kamilgrzybek.com/blog/posts/rest-api-data-validation)
- [ ] 문서 | Kamil Grzybek | [DOMAIN MODEL VALIDATION](https://www.kamilgrzybek.com/blog/posts/domain-model-validation)
- [ ] 문서 | Kamil Grzybek | [SIMPLE CQRS IMPLEMENTATION WITH RAW SQL AND DDD](https://www.kamilgrzybek.com/blog/posts/simple-cqrs-implementation-raw-sql-ddd)
- [ ] 소스 | [modular-monolith-with-ddd, Kamil Grzybek](https://github.com/kgrzybek/modular-monolith-with-ddd)
- [ ] 문서 | Modular Monolith: A Primer | [한글](https://github.com/ijung/ijung.github.io/blob/main/_posts/development-contents/modular-monolith/2023-05-26-modular-monolith-a-primer.md), [영문](https://www.kamilgrzybek.com/blog/posts/modular-monolith-primer)
- [ ] 문서 | Modular Monolith: Architectural Drivers | [한글](https://github.com/ijung/ijung.github.io/blob/main/_posts/development-contents/modular-monolith/2023-06-03-modular-monolith-architectural-drivers.md), [영문](https://www.kamilgrzybek.com/blog/posts/modular-monolith-architectural-drivers)
- [ ] 문서 | Modular Monolith: Architecture Enforcement | [한글](https://github.com/ijung/ijung.github.io/blob/main/_posts/development-contents/modular-monolith/2023-06-04-modular-monolith-architecture-enforcement.md), [영문](https://www.kamilgrzybek.com/blog/posts/modular-monolith-architecture-enforcement)
- [ ] 문서 | Modular Monolith: Integration Styles | [한글](https://github.com/ijung/ijung.github.io/blob/main/_posts/development-contents/modular-monolith/2023-06-05-modular-monolith-integration-styles.md), [영문](https://www.kamilgrzybek.com/blog/posts/modular-monolith-integration-styles)
- [ ] 문서 | Modular Monolith: Domain-Centric Design | [한글](https://github.com/ijung/ijung.github.io/blob/main/_posts/development-contents/modular-monolith/2023-06-10-modular-monolith-centric-design.md), [영문](https://www.kamilgrzybek.com/blog/posts/modular-monolith-domain-centric-design)
- [ ] 소스 | [Hands-On-Domain-Driven-Design-with-.NET-Core](https://github.com/PacktPublishing/Hands-On-Domain-Driven-Design-with-.NET-Core/tree/master)
- [ ] 소스 | [Stop using Entity Framework as a DTO provider](https://github.com/ChrisKlug/efcore-dto-demo/tree/main)
- [ ] 영상 | [Stop using Entity Framework as a DTO provider](https://www.youtube.com/watch?v=N_eLotlcjXo)
- [ ] 소스 | [refactoring-from-anemic-to-rich-domain-model-example](https://github.com/kgrzybek/refactoring-from-anemic-to-rich-domain-model-example/tree/master)
- [ ] 소스 | [dotnet-domain-driven-design](https://github.com/danielmackay/dotnet-domain-driven-design/tree/main)
- [ ] 소스 | [pluralsight-ddd-fundamentals](https://github.com/ardalis/pluralsight-ddd-fundamentals/tree/main)
- [ ] 문서 | Scaffold Your Clean DDD Web Application | [Part 6: Domain-Driven Design Workflow Patterns](https://blog.jacobsdata.com/2021/04/11/scaffold-your-clean-ddd-web-application-part-6-domain-driven-design-workflow-patterns)

### 도메인 주도 리팩토링
- [ ] 소스 | [DDD-NoDuplicates](https://github.com/ardalis/DDD-NoDuplicates)
- [ ] 소스 | [How To Use Domain-Driven Design In Clean Architecture](https://www.youtube.com/watch?v=1Lcr2c3MVF4)
- [ ] 소스 | [Refactoring From Transaction Script to Domain-Driven Design](https://www.youtube.com/watch?v=KTSpDZNfjhU)
- [ ] 소스 | [Domain-Driven Refactoring - Jimmy Bogard](https://www.youtube.com/watch?v=f64tZ90Dntg)
- [ ] 문서 | [Repeatable execution](https://blog.ploeh.dk/2020/03/23/repeatable-execution/)
- [ ] 문서 | [Repeatable execution in C#](https://blog.ploeh.dk/2020/04/06/repeatable-execution-in-c/)
- [ ] 문서 | [Discerning and maintaining purity](https://blog.ploeh.dk/2020/02/24/discerning-and-maintaining-purity/)

### MediatR
- [ ] 영상 | [MediatR in depth](https://www.youtube.com/watch?v=BcQVuuMQrJs&list=PLtgaC3-iBpdjckV1yLezLNeJwRpOnY5XT)

## EF Core
- [ ] 소스 | [efcore-concurrency-handling](https://github.com/kgrzybek/efcore-concurrency-handling)
- [ ] 영상 | [Mapping Domain-Driven Design Concepts To The Database With EF Core(IEntityTypeConfiguration)](https://www.youtube.com/watch?v=IlXnIe6p_Uk)

## ASP.NET
- [ ] 문서 | [Using the ProblemDetails Class in ASP.NET Core Web API](https://code-maze.com/using-the-problemdetails-class-in-asp-net-core-web-api/)
- [ ] 소스 | [AspNetCoreDiagnosticScenarios](https://github.com/davidfowl/AspNetCoreDiagnosticScenarios)

## Primitives
- [ ] 문서 | [IComparable vs IComparer vs Comparison Delegate](https://code-maze.com/csharp-icomparable-icomparer-comparison-delegate/)
- [ ] 문서 | [문자열 이야기 (6) - Equals 와 == 연산자](http://www.simpleisbest.net/archive/2005/08/17/206.aspx)

## 테스트
### 단위 테스트
- [ ] 문서 | [Why I stopped worrying about test setups by using AutoFixture](https://timdeschryver.dev/blog/why-i-stopped-worrying-about-test-setups-by-using-autofixture#conclusion)

### 아키텍처 테스트
- [ ] 문서 | [Architecture Tests in .NET with NetArchTest.Rules](https://code-maze.com/csharp-architecture-tests-with-netarchtest-rules)
- [ ] 문서 | [Architecture tests in.NET](https://medium.com/@v.cheshmy/architecture-tests-in-net-d95192faf2dd)

### 통합 테스트 | WebApi
- [ ] 문서 | [Integration tests in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-8.0)
- [ ] 문서 | [How to test your C# Web API](https://timdeschryver.dev/blog/how-to-test-your-csharp-web-api)
- [ ] 문서 | [How to test ASP.NET Core Minimal APIs](https://www.twilio.com/blog/test-aspnetcore-minimal-apis)
- [ ] 문서 | [Integration Testing ASP.NET Core APIs incl. auth and database](https://www.fearofoblivion.com/asp-net-core-integration-testing)
- [ ] 소스 | [ASP.NET Core API Integration Testing Demo](https://github.com/ChrisKlug/aspnet-core-integration-testing-101/tree/main)

### 통합 테스트 | Postgres
- [ ] 문서 | [ASP.NET Core Integration Tests with Test Containers & Postgres](https://www.azureblue.io/asp-net-core-integration-tests-with-test-containers-and-postgres/)

### Snapshot 테스트
- [ ] 문서 | [Testing an incremental generator with snapshot testing](https://andrewlock.net/creating-a-source-generator-part-2-testing-an-incremental-generator-with-snapshot-testing/)
- [ ] 문서 | [Snapshot Testing with Verify](https://www.danclarke.com/snapshot-testing-with-verify)
- [ ] 영상 | [OSS Power-Ups: Verify](https://www.youtube.com/watch?v=4ZrNoB_wdYU)

### Fake 데이터
- [ ] 문서 | [Fake data substitution for tests in C# with Bogus](https://prographers.com/blog/fake-data-substitution-for-tests-in-c-with-bogus)
- [ ] 문서 | [Realistic Data Generation in .NET With Bogus](https://code-maze.com/data-generation-bogus-dotnet/)


## 구성
### 빌드 환경
- [ ] 문서 | [Understand Directory.Build.props: Centralizing .NET Project Configurations](https://blog.ndepend.com/directory-build-props/)

