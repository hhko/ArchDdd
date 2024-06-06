using ArchDdd.Application.Abstractions.CQRS;
using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.Abstractions.Results.Contracts;

namespace ArchDdd.Application.Abstractions;

public interface IValidator
{
    bool IsValid { get; }
    bool IsInvalid { get; }

    // 유효성 검사 수행: 실패시 에러 코드 수집
    //  - bool
    //  - IResult
    //  - IResult<TType>
    //  - ValidationResult<TType>
    IValidator If(bool condition, Error thenError);
    IValidator Validate(IResult result);
    IValidator Validate<TType>(IResult<TType> result);
    IValidator Validate<TType>(ValidationResult<TType> validationResult);

    // 유효성 검사 결과: 실패시 ValidationResult 생성
    //  - ValidationResult
    //  - ValidationResult<TResponse>
    ValidationResult<TResponse> Failure<TResponse>() where TResponse : IResponse;
    ValidationResult Failure();
}
