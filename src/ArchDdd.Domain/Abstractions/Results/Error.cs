namespace ArchDdd.Domain.Abstractions.Results;

public sealed partial class Error : IEquatable<Error>
{
    private const string SerializationSeparator = ": ";

    // 성공 Error 타입
    public static readonly Error None = new(string.Empty, string.Empty);

    // 실패 Error 타입
    //  - NULL
    //  - 조건
    //  - 유효성 검사
    public static readonly Error NullError = new($"{nameof(NullError)}", "The result value is null.");
    public static readonly Error ConditionNotSatisfiedError = new($"{nameof(ConditionNotSatisfiedError)}", "The specified condition was not satisfied.");
    public static readonly Error ValidationError = new($"{nameof(ValidationError)}", "A validation problem occurred.");

    //
    // 생성 메서드
    //  - Error New(string code, string message)
    //  - Error FromException<TException>(TException exception)
    //

    private Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }
    public string Message { get; }

    public static Error New(string code, string message)
    {
        return new Error(code, message);
    }

    public static Error FromException<TException>(TException exception)
        where TException : Exception
    {
        // exception.Message 형식 有/無
        // 1. 형식 있음: One or more errors occurred. ([0] Message 값) ([1] Message 값) ...
        //    - InnerException가 없는 예외
        //    - AggregateException 예외
        // 2. 형식 없음
        //    - InnerException가 있는 예외

        // exception.Message 형식 有
        // - 일반 예외(InnerException가 없는 예외)
        // - AggregateException 예외
        if (exception.InnerException is null || exception is AggregateException)
        {
            // 일반 예외(InnerException가 없는 예외)
            //  .Message: 입력 값 
            //
            // AggregateException일 때
            //  exception.InnerExceptions
            //      - [0] This was invalid operation
            //      - [1] Invalid argument
            //  exception.Message: One or more errors occurred. ([0] Message 값) ([1] Message 값)
            //      - One or more errors occurred. (This was invalid operation) (Invalid argument)
            return New(
                $"{nameof(Exception)}.{exception.GetType().Name}",
                exception.Message);
        }

        // exception.Message 형식 無
        // - InnerException이 있는 예외
        //   exception.InnerException.Message
        //      - Invalid argument
        //   exception.Message(사용자 정의 형식): 입력 값 (InnerException Message 값)
        //      - This was invalid operation (Invalid argument)
        return New(
            $"{nameof(Exception)}.{exception.GetType().Name}",
            $"{exception.Message}. ({exception.InnerException.Message})");
    }

    //
    // 비교 메서드 | IEquatable
    //

    public static bool operator ==(Error? error, Error? other)
    {
        if (error is null && other is null)
            return true;

        if (error is null || other is null)
            return false;

        return error.Equals(other);
    }

    public static bool operator !=(Error? error, Error? other)
    {
        return !(error == other);
    }

    public bool Equals(Error? other)
    {
        if (other is null)
            return false;

        return ValuesAreEqual(other);
    }

    public override bool Equals(object? obj)
    {
        //return obj is Error error && Equals(error);

        if (obj is null)
            return false;

        if (obj.GetType() != GetType())
            return false;

        if (obj is not Error other)
            return false;

        return Equals(other);
    }

    private bool ValuesAreEqual(Error other)
    {
        return Code == other.Code
            && Message == other.Message;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Code, Message);
    }

    public string Serialize()
    {
        return $"{Code}{SerializationSeparator}{Message}";
    }

    //public static Error Deserialize(string serializedError)
    //{
    //    var splitted = serializedError.Split(SerializationSeparator);
    //    return New(splitted[0], splitted[1]);
    //}

    //
    // string 반환 메서드
    //

    public static implicit operator string(Error error)
    {
        return error.Code;
    }

    public override string ToString()
    {
        return Message;
    }

    //
    // 기본 메서드
    //

    // 실패 객체 샐성할 때, 에러는 반드시 존재해야 한다.
    public void ThrowIfErrorNone()
    {
        if (this == None)
            throw new InvalidOperationException("Provided error is Error.None");
    }

    //public string? MessageOrNullIfErrorNone()
    //{
    //    if (this == None)
    //        return null;

    //    return Message;
    //}
}