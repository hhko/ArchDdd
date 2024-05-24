---
sidebar_position: 1
---

# MediatR

## 기본 구조
### 입/출력 정의
```cs
public class 입력_타입 : IRequest<출력_타입>
{
    입력_파라미터1;
    입력_파라미터2;
    ...
}

public class 출력_타입
{
    출력_파라미터1;
    출력_파라미터2;
    ...
}
```

### 입력 핸들러
```cs
public class 입력Handler : IRequestHandler<입력_타입, 출력_타입>
{
    public async Task<출력_타입> Handle(입력_타입 request, CancellationToken cancellationToken)
    {
        ...
    }
}
```

### 예제
```cs
// 입력: Ping
// 출력: string
public class Ping : IRequest<string> 
{ 

}

// 입력 핸들러
public class PingHandler : IRequestHandler<Ping, string>
{
    public Task<string> Handle(Ping request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Pong");
    }
}
```