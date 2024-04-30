# 참고 자료

# 아키텍처
- [ ] [Clean Architecture Template, Ardalis](https://github.com/ardalis/CleanArchitecture)
- [ ] [Clean Architecture Template, Amantinband](https://github.com/amantinband/clean-architecture)
- [ ] [code-maze, Hexagonal Architectural Pattern in C#](https://code-maze.com/csharp-hexagonal-architectural-pattern/)
- [ ] [code-maze, Clean Architecture in .NET](https://code-maze.com/dotnet-clean-architecture/)

## 도메인 주도 설계
- [ ] [Hands-On-Domain-Driven-Design-with-.NET-Core](https://github.com/PacktPublishing/Hands-On-Domain-Driven-Design-with-.NET-Core/tree/master)

## 기본
- [ ] [IComparable vs IComparer vs Comparison Delegate](https://code-maze.com/csharp-icomparable-icomparer-comparison-delegate/)
- [ ] [문자열 이야기 (6) - Equals 와 == 연산자](http://www.simpleisbest.net/archive/2005/08/17/206.aspx)

## Domain
- [x] [ValueObject | C# 9 Records as DDD Value Objects](https://enterprisecraftsmanship.com/posts/csharp-records-value-objects/)
  - 1. **IEquatable&ltT&gt 세부 제어 부족**
    - 대상 선택 불가: 멤버 변수 중에서 선택적으로 지정할 수 없음
      ```cs
      protected override IEnumerable<object> GetEqualityComponents()
      {
          yield return Code;
      }
      ```
    - 세부 제어 불가: 실수 데이터 비교 범위를 지정할 수 없음
      ```cs
      yield return Math.Round(Value, 2);
      ```
    - 배열 대상 제외: 배열 데이터는 참조 비교만 제공
      ```cs
      foreach (string comment in Comments)
      {
          yield return comment;
      }
      ```
  - 2. **IComparable 인터페이스 미구현**
    ```cs
    public record Address(string Street, string ZipCode);

    var address1 = new Address("1234 Main St", "20012");
    var address2 = new Address("1235 Main St", "20012");

    // 런타임 에러
    Address[] addresses = new[] { address1, address2 }.OrderBy(x => x).ToArray();   
    ```
  - 3. **Encapsulation 부족**: Encapsulation stands for protection of application `invariants`.
    ```cs
    CustomerStatus status = new CustomerStatus(false, null);

    // 생성자가 호출되지 않는다(유효성 검사 회피).
    CustomerStatus status2 = status with { IsAdvanced = true };
    ```
  - 4. **명시적 구분**
    ```cs
    public record Address
    {
        public string Street { get; }
        public string ZipCode { get; }
    }
    
    // vs.
    
    public class Address : ValueObject      // ValueObject을 명시적으로 확인할 수 있다.
    {
        public string Street { get; }
        public string ZipCode { get; }
    }
    ```