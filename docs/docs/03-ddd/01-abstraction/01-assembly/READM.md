# 어셈블리 식별하기

```cs
using System.Reflection;

// 어셈블리 식별을 위한 네임스페이스
namespace ArchDdd.Domain;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
```
- 단위 테스트에서 어셈블리의 레이어를 식별하기 위해 `AssemblyReference`을 사용한다.
- 모든 어셈블리에 `AssemblyReference`을 구현한다.