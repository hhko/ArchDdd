namespace ArchDdd.Domain.Abstractions.Results;

public sealed partial class Error : IEquatable<Error>
{
    #region 기본 타입

    // 성공 Error 타입
    public static readonly Error None = new(string.Empty, string.Empty);

    // 실패 Error 타입
    //  - NULL
    //  - 조건
    //  - 유효성 검사
    public static readonly Error NullValue = new($"{nameof(NullValue)}", "The result value is null.");
    public static readonly Error ConditionNotSatisfied = new($"{nameof(ConditionNotSatisfied)}", "The specified condition was not satisfied.");
    public static readonly Error ValidationError = new($"{nameof(ValidationError)}", "A validation problem occurred.");

    public string Code { get; }
    public string Message { get; }

    #endregion

    #region 생성 메서드

    // 기존(기존 Error 데이터로부터 생성) 
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    // 신규
    public static Error New(string code, string message)
    {
        return new Error(code, message);
    }

    // 신규 | 예외
    public static Error FromException<TException>(TException exception)
        where TException : Exception
    {
        if (exception is AggregateException || exception.InnerException is null)
        {
            // AggregateException일 때
            //  [0] This was invalid operation
            //  [1] Invalid argument
            //  One or more errors occurred. (This was invalid operation) (Invalid argument)
            return New(exception.GetType().Name, exception.Message);
        }

        // InnerException일 때
        //  exception.Message                : This was invalid operation
        //  exception.InnerException.Message : Invalid argument
        //  This was invalid operation (Invalid argument)
        return New(exception.GetType().Name, $"{exception.Message}. ({exception.InnerException.Message})");
    }

    #endregion

    #region 비교 메서드

    public static bool operator ==(Error? first, Error? second)
    {
        if (first is null && second is null)
            return true;

        if (first is null || second is null)
            return false;

        return first.Equals(second);
    }

    public static bool operator !=(Error? first, Error? second)
    {
        return !(first == second);
    }

    public bool Equals(Error? other)
    {
        if (other is null)
            return false;

        return Code == other.Code
            && Message == other.Message;
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

    public override int GetHashCode()
    {
        return HashCode.Combine(Code, Message);
    }

    public override string ToString()
    {
        return Message;
    }

    #endregion

    #region 기본 메서드

    public static implicit operator string(Error error)
    {
        return error.Code;
    }

    public void ThrowIfErrorNone()
    {
        if (this == None)
        {
            throw new InvalidOperationException("Provided error is Error.None");
        }
    }

    public string? MessageOrNullIfErrorNone()
    {
        if (this == None)
        {
            return null;
        }

        return Message;
    }

    #endregion
}