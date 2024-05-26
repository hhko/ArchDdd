---
sidebar_position: 4
---

# FluentValidation

> 선언적 유효성 검사

## 목표
- `AbstractValidator<T>`: **유스케이스** 입력 메시지(`IRequest`) 유효성을 검사합니다.

## 유효성 검사
### 유스케이스 입력 메시지
```cs
// RegisterUserCommand: 유스케이스 입력 메시지
internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .WithMessage("{PropertyName} failed");

        // ...
    }
}
```

### 유효성 검사 등록
```cs
// IServiceCollection services

// 어셈블리 AbstractValidator 구현 클래스 모두를 등록합니다.
services.AddValidatorsFromAssembly(
    assembly: ArchDdd.Application.AssemblyReference.Assembly,
    includeInternalTypes: true);
```

## 메시지 구성
### 유효성 검사 Behavior 구현
```cs
```

### 유효성 검사 Behavior 등록
```cs
// IServiceCollection services
services.AddMediatR(configuration =>
{
    // 어셈블리 IRequest 구현 클래스 모두를 등록합니다.
    configuration.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly);

    // Behavior 순서는 중요하다.
    //  - 호출 호출 순서: LoggingPipeline -> ValidatorPipeline -> 메시지 핸들러
    //  - 반환 호출 순서: LoggingPipeline <- ValidatorPipeline <- 메시지 핸들러
    configuration.AddOpenBehavior(typeof(LoggingPipeline<,>));
    configuration.AddOpenBehavior(typeof(ValidatorPipeline<,>));
    // ...
});