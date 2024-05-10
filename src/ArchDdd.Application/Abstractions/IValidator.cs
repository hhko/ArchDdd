using ArchDdd.Application.Abstractions.CQRS;
using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.Abstractions.Results.Contracts;

namespace ArchDdd.Application.Abstractions;

public interface IValidator
{
    bool IsValid { get; }
    bool IsInvalid { get; }

    // If
    IValidator If(bool condition, Error thenError);

    // Validate
    IValidator Validate(IResult result);
    IValidator Validate<TType>(IResult<TType> result);

    //IValidator Validate(IValidationResult validationResult);
    IValidator Validate<TType>(ValidationResult<TType> validationResult);

    // Failure
    ValidationResult<TResponse> Failure<TResponse>()
            where TResponse : IResponse;
    ValidationResult Failure();
}
