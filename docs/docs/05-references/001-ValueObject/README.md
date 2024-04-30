# C# 9 Records as DDD Value Objects
- [C# 9 Records as DDD Value Objects](https://enterprisecraftsmanship.com/posts/csharp-records-value-objects/)

## C# 9 Records는 Value Object로 적합하지 않습니다.

### 설계 관점
1. 행위 부족
   - `ValueObject`는 라이프사이클이 없는 비즈니스 단위를 **상태와 행위를 갖는** 객체로 정의하기 위한 설계 기술입니다.
   - `record`는 행위가 없는 상태만을 갖는 타입 구현을 집중하게 됩니다.
1. 구분 힘듬
   - `record`로 정의하면 ValueObject 목적과 그 외 목적(단순 record)으로 정의된 코드를 구분하기가 어렵습니다.
1. 캡슐화 부족
   ```cs
   CustomerStatus status = new CustomerStatus(false, null);

   // 생성자가 호출되지 않는다(유효성 검사 회피).
   CustomerStatus status2 = status with { IsAdvanced = true };
   ```
   - `with` 키워드를 사용하면 생성자(유효성 검사 코드) 호출 없이 새로운 객체를 생성합니다.

### 기능 관점
1. `record`는 `IEquatable` 인터페이스를 섬세한 제어를 제공하지 않습니다.
   - 기본적으로 모든 데이터를 비교 대상입니다.
     ```cs
     yield return Code;
     ```
   - 배열은 값이 아닌 참조 값을 비교합니다.
     ```cs
     foreach (string comment in Comments)
     {
         yield return comment;
     }
     ```
   - 실수 값은 값의 세부 범위 지정을 제공하지 않습니다.
     ```cs
     yield return Math.Round(Value, 2);
     ```
1. `record`는 `IComparable` 인터페이스를 제공하지 않습니다.
   ```cs
   public record Address(string Street, string ZipCode);

   var address1 = new Address("1234 Main St", "20012");
   var address2 = new Address("1235 Main St", "20012");

   // 런타임 에러
   Address[] addresses = new[] { address1, address2 }.OrderBy(x => x).ToArray();
   ```