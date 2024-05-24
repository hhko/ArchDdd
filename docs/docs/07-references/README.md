# 링크

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


## EF Core
- [ ] 소스 | [efcore-concurrency-handling](https://github.com/kgrzybek/efcore-concurrency-handling)


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