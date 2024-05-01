## 기본 구조
### 기본 형식
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
public class Ping : IRequest<string> { }

public class PingHandler : IRequestHandler<Ping, string>
{
    public Task<string> Handle(Ping request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Pong");
    }
}
```