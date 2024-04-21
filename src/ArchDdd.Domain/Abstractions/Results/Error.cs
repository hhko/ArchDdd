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
    public static readonly Error Null = new($"{nameof(Null)}", "The result value is null.");
    public static readonly Error ConditionNotSatisfied = new($"{nameof(ConditionNotSatisfied)}", "The specified condition was not satisfied.");
    public static readonly Error Validation = new($"{nameof(Validation)}", "A validation problem occurred.");

    #endregion

    #region 생성 메서드

    // 기존(기존 Error 데이터로부터 생성) 
    private Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }
    public string Message { get; }

    // 신규
    public static Error New(string code, string message)
    {
        return new Error(code, message);
    }

    // 신규 | 예외
    public static Error FromException<TException>(TException exception)
        where TException : Exception
    {
        // 예외 구분
        //  - 형식 있음
        //      1. InnerException가 없을 예외
        //      2. AggregateException 예외
        //  - 형식 없음
        //      3. InnerException가 있는 예외


        // InnerException가 없는 예외
        // AggregateException 예외
        if (exception.InnerException is null || exception is AggregateException)
        {
            // AggregateException일 때
            //  exception.InnerExceptions
            //      - [0] This was invalid operation
            //      - [1] Invalid argument
            //  exception.Message: One or more errors occurred. ([0] Message 값) ([1] Message 값)
            //      - One or more errors occurred. (This was invalid operation) (Invalid argument)
            //
            // 일반 예외
            //  .Message: 입력 값 
            return New(
                $"{nameof(Exception)}.{exception.GetType().Name}", 
                exception.Message);
        }

        // InnerException가 있는 예외
        //  exception.InnerException.Message
        //      - Invalid argument
        //  exception.Message: 입력 값 (InnerException Message 값)
        //      - This was invalid operation (Invalid argument)
        return New(
            $"{nameof(Exception)}.{exception.GetType().Name}", 
            $"{exception.Message}. ({exception.InnerException.Message})");
    }

    #endregion

    #region 비교 메서드

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

        return Code == other.Code
            && Message == other.Message;
    }

    public override bool Equals(object? obj)
    {
        //return obj is Error error && Equals(error);

        if (obj is null)
            return false;

        //if (obj.GetType() != GetType())
        //    return false;

        if (obj is not Error other)
            return false;

        return Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Code, Message);
    }

    #endregion

    #region string 반환 메서드

    public static implicit operator string(Error error)
    {
        return error.Code;
    }

    public override string ToString()
    {
        return Message;
    }

    #endregion

    #region 기본 메서드

    // 실패 객체 샐성할 때
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

    #endregion
}

//public class Vehicle : IEquatable<Vehicle>
//{

//    private string manufacturer;
//    private string model;
//    private int productionYear;

//    public Vehicle(string manufacturer, string model, int productionYear)
//    {
//        this.manufacturer = manufacturer;
//        this.model = model;
//        this.productionYear = productionYear;
//    }

//    public string GetLabel()
//    {
//        return string.Format("{0} {1}", this.manufacturer, this.model);
//    }

//    public override int GetHashCode()
//    {
//        return this.manufacturer.GetHashCode() ^ this.model.GetHashCode();
//    }

//    public override bool Equals(object? obj)
//    {
//        return this.Equals(obj as Vehicle);
//    }

//    public bool Equals(Vehicle? other)
//    {
//        if (other != null)
//            return this.manufacturer.Equals(other.manufacturer) &&
//                   this.model.Equals(other.model);
//        return false;
//    }

//    public static bool operator ==(Vehicle vehicle, Vehicle other)
//    {
//        bool isVehicleNull = object.ReferenceEquals(vehicle, null);
//        bool isOtherNull = object.ReferenceEquals(other, null);

//        if (isVehicleNull && isOtherNull)
//            return true;
//        else if (isVehicleNull)
//            return false;
//        else
//            return vehicle.Equals(other);

//    }

//    public static bool operator !=(Vehicle vehicle, Vehicle other)
//    {
//        return !(vehicle == other);
//    }

//}