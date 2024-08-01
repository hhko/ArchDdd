using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using FluentValidation;
using MediatR;
using PrimitiveUtilities;
//using static ArchDdd.Application.Abstractions.Cache.ApplicationCache;

namespace ArchDdd.Application.Abstractions.Pipelines;

public sealed class ValidatorPipeline<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) 
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : class, IResult
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validators.IsEmpty())
        {
            return await next();
        }

        //
        // 흐름
        // Validate -{1: Select}-> Errors -{N: SelectMany}-> ValidationFailure
        //  
        // 주요 클래스
        // public interface IValidator<in T> : IValidator
        //      ValidationResult Validate(T instance);
        //
        // public class ValidationResult
        //      List<ValidationFailure> Errors
        //
        // public class ValidationFailure
        //      public string PropertyName { get; set; }
        //      public string ErrorMessage { get; set; }
        Error[] errors = _validators
            .Select(validator => validator.Validate(request))               // Validate 메서드
            .SelectMany(validationResult => validationResult.Errors)        // Errors 타입
            .Where(validationFailure => validationFailure is not null)      // ValidationFailure 타입
            .Select(failure =>
                {
                    return Error.New(failure.PropertyName, failure.ErrorMessage);
                })
            .Distinct()
            .ToArray();

        if (errors.Length is not 0)
        {
            return errors.CreateValidationResult<TResponse>();
            //return (TResponse)ValidationResultCache[typeof(TResponse)](errors);
        }

        return await next();
    }
}