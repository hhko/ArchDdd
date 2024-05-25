---
sidebar_position: 1
---

# MediatR

## 목표
- `IRequest`: 기술 관심사에서 비즈니스 관심사의 유스케이스를 호출합니다.
- `IPipelineBehavior`: 메시지 호출 때 부가 기능(Pipeline)을 구성합니다.
  - 메시지 입/출력 로그
  - 메시지 유효성 검사
- `INotification`: 비즈니스 관심사의 유스케이스에서 이벤트(도메인 이벤트)를 발생시킨다.

## 유스케이스
### 유스케이스 입/출력
```cs
// 입력 메시지 정의
public class 입력_메시지 : IRequest<출력_메시지>
{
    입력_파라미터1;
    입력_파라미터2;
    ...
}

// 출력 메시지
public class 출력_메시지
{
    출력_파라미터1;
    출력_파라미터2;
    ...

}

// 유스케이스 호출
출력_메시지 output = await _sender.Send(new 입력_메시지( ... ));
```

### 유스케이스 핸들러
```cs
public class 입력_메시지Handler : IRequestHandler<입력_메시지, 출력_메시지>
{
    public async Task<출력_메시지> Handle(입력_메시지 request, CancellationToken cancellationToken)
    {
        // ...
    }
}
```

### 유스케이스 등록
```cs
// IServiceCollection services
services.AddMediatR(configuration =>
{
    // 어셈블리 IRequest 구현 클래스 모두를 등록합니다.
    configuration.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly);
});
```

### 예제
```cs
// 입력 메시지: Ping
// 출력 메시지: string
public class Ping : IRequest<string> 
{ 

}

// 유스케이스 핸들러
public class PingHandler : IRequestHandler<Ping, string>
{
    public Task<string> Handle(Ping request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Pong");
    }
}

// 유스케이스 호출
var pong = await _sender.Send(new Ping());
```

## 메시지 구성
### Behavior 구현
```cs
public sealed class LoggingPipeline<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // 유스케이스 호출 전...

        var result = await next();

        // 유스케이스 호출 후...
    }
}
```

### Behavior 등록
```cs
// IServiceCollection services
services.AddMediatR(configuration =>
{
    // 어셈블리 IRequest 구현 클래스 모두를 등록합니다.
    configuration.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly);

    // Behavior 순서는 중요하다.
    configuration.AddOpenBehavior(typeof(LoggingPipeline<,>));
    // ...
});