using ArchDddPrimitivess.Results.Contracts;

namespace ArchDddPrimitivess.Results;

public sealed class ValidationResult : Result, IValidationResult
{
    private static readonly ValidationResult _successValidationResult = new();

    //
    // 생성 메서드
    //  - 성공
    //    - ValidationResult WithoutErrors()
    //  - 실패
    //    - ValidationResult WithErrors(ICollection<Error> validationErrors)
    //

    // 성공
    private ValidationResult()
        : base(Error.None)
    {
        ValidationErrors = [];
    }

    // 실패
    private ValidationResult(Error[] validationErrors)
        : base(Error.ValidationError)
    {
        ValidationErrors = validationErrors;
    }

    public Error[] ValidationErrors { get; }

    // 성공
    public static ValidationResult WithoutErrors()
    {
        return _successValidationResult;
    }

    // 실패
    public static ValidationResult WithErrors(ICollection<Error> validationErrors)
    {
        return new([.. validationErrors]);
    }
}

public sealed class ValidationResult<TValue> : Result<TValue>, IValidationResult
{
    //
    // 생성 메서드
    //  - 성공
    //    - ValidationResult<TValue> WithoutErrors(TValue? value)
    //  - 실패
    //    - ValidationResult<TValue> WithErrors(params Error[] validationErrors)
    //

    // 성공
    // - TValue?일 때 NULL이면
    //   Result<T>에서 Value 값을 참조할 때 InvalidOperationException 예외를 발생 시킨다.
    private ValidationResult(TValue? value)
        : base(value, Error.None)
    {
        ValidationErrors = [];
    }

    // 실패
    private ValidationResult(Error[] validationErrors)
        : base(default, Error.ValidationError)
    {
        ValidationErrors = validationErrors;
    }

    public Error[] ValidationErrors { get; }

    // 성공
    public static ValidationResult<TValue> WithoutErrors(TValue? value)
    {
        return new(value);
    }

    // 실패
    public static ValidationResult<TValue> WithErrors(params Error[] validationErrors)
    {
        return new(validationErrors);
    }
}