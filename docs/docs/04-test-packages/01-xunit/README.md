---
sidebar_position: 1
---

# xUnit

## 복수 입력 데이터
- [Creating parameterised tests in xUnit with [InlineData], [ClassData], and [MemberData]](https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/)

### 속성 수준 N개 입력 데이터
```cs
// N개 데이터
[Theory]
[InlineData(1, 2, 3)]
[InlineData(-4, -6, -10)]
[InlineData(-2, 2, 0)]
[InlineData(int.MinValue, -1, int.MaxValue)]
public void CanAddTheory(int value1, int value2, int expected)
```

### 메서드 수준 N개 입력 데이터
```cs
[Theory]
[MemberData(nameof(Data))]
public void CanAddTheoryMemberDataProperty(int value1, int value2, int expected)
{
    // ...
}

public static IEnumerable<object[]> Data =>
    new List<object[]>
    {
        new object[] { 1, 2, 3 },
        new object[] { -4, -6, -10 },
        new object[] { -2, 2, 0 },
        new object[] { int.MinValue, -1, int.MaxValue },
    };
```

### 클래스 수준 N개 입력 데이터
```cs
[Theory]
[ClassData(typeof(CalculatorTestData))]
public void CanAddTheoryClassData(int value1, int value2, int expected)
{
    // ...
}

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 1, 2, 3 };
        yield return new object[] { -4, -6, -10 };
        yield return new object[] { -2, 2, 0 };
        yield return new object[] { int.MinValue, -1, int.MaxValue };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
```

## Fixture