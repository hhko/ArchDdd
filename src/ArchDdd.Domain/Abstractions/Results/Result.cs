using ArchDdd.Domain.Abstractions.Results.Contracts;

namespace ArchDdd.Domain.Abstractions.Results;

public class Result : IResult
{
    // 재사용
    private static readonly Result _success = new(Error.None);

    //
    // 생성 메서드
    //  - 동적 성공/실패
    //    - Result Create(bool condition)                       // 동적 성공
    //  - 성공, 값 有
    //    - implicit operator Result<TValue>(TValue? value)     // 암시적 성공(NULL 허용): NULL은 실패로 처히아 행성한다. 암시적 Result<T> 생성
    //          ↓
    //    - Result<TValue> Create<TValue>(TValue? value)        // 동적 성공(NULL 허용): NULL은 실패로 처히아 행성한다. 명시적 Result<T> 생성
    //          ↓
    //    - Result<TValue> Success<TValue>(TValue value)        // 명시적 성공(NULL 제외 생성)
    //  - 성공, 값 無
    //    - Result Success()                                    // 명시적 성공
    //  - 실패, 값 有
    //    - Result<TValue> Failure<TValue>(Error error)         // 명시적 실패
    //    - Result<TValue> Failure<TValue>()                    // 명시적 실패: 기존 실패 Result --전환--> 새 실패 Result<T>
    //  - 실패, 값 無
    //    - Result Failure(Error error)                         // 명시적 실패
    //

    private protected Result(Error error)
    {
        Error = error;
    }

    public bool IsSuccess => Error == Error.None;

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public static Result Create(bool condition)
    {
        return condition
            ? Success()
            : Failure(Error.ConditionNotSatisfiedError);
    }

    public static Result<TValue> Create<TValue>(TValue? value)
    {
        if (value is null)
            return Failure<TValue>(Error.NullError);

        if (value is Error)
            throw new InvalidOperationException("Provided value is an Error");

        return Success(value);
    }

    public static Result Success()
    {
        return _success;
    }

    public static Result<TValue> Success<TValue>(TValue value)
    {
        return new(value, Error.None);
    }

    public static Result Failure(Error error)
    {
        error.ThrowIfErrorNone();
        return new(error);
    }

    public static Result<TValue> Failure<TValue>(Error error)
    {
        error.ThrowIfErrorNone();
        return new(default, error);
    }

    // 기존 실패 Result --전환--> 새 실패 Result<T>
    // 예.
    //      public IResult<ChangeOrderHeaderStatusResponse>
    //      {
    //          Result statusChangeResult = ...;
    //          if (statusChangeResult.IsFailure)
    //          {
    //              return statusChangeResult.Failure<ChangeOrderHeaderStatusResponse>();
    //          }
    //      }
    public Result<TValue> Failure<TValue>()
    {
        return Failure<TValue>(Error);
    }
}

public class Result<TValue> : Result, IResult<TValue>
{
    private readonly TValue? _value;

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException($"The value of a failure result can not be accessed. Type '{typeof(TValue).FullName}'.");

    protected internal Result(TValue? value, Error error)
        : base(error)
    {
        _value = value;
    }

    public static implicit operator Result<TValue>(TValue? value)
    {
        return Create(value);
    }
}