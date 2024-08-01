using ArchDdd.Domain.Abstractions.BaseTypes;
using ArchDdd.Domain.Abstractions.Results.Contracts;

namespace ArchDdd.Domain.Abstractions.Results;

public static class ErrorUtilities
{
    public static TResult CreateValidationResult<TResult>(
        this ICollection<Error> errors)
        where TResult : class, IResult
    {
        if (typeof(TResult) == typeof(Result) || typeof(TResult) == typeof(IResult))
        {
            return (ValidationResult.WithErrors(errors) as TResult)!;
        }
        //if (typeof(TResult) == typeof(Result))
        //{
        //    return (ValidationResult.WithErrors(errors) as TResult)!;
        //}

        //var result = typeof(TResult);
        ////var validationMethod = typeof(ValidationResult<>)
        ////    .GetGenericTypeDefinition()
        ////    .MakeGenericType(result)
        ////    .GetMethod(nameof(ValidationResult.WithErrors))!;
        //var x1 = typeof(ValidationResult<>);
        //var x2 = x1.GetGenericTypeDefinition();
        //var x3 = x2.MakeGenericType(result);
        //var x4 = x3.GetMethod(nameof(ValidationResult.WithErrors))!;
        //var validationResult = x4.Invoke(null, [errors])!;

        //var x1 = typeof(ValidationResult<>);
        //var x2 = x1.GetGenericTypeDefinition();
        //var y0 = typeof(TResult);
        //var y1 = typeof(TResult).GenericTypeArguments[0];
        //var x3 = x2.MakeGenericType(y1);
        //var x4 = x3.GetMethod(nameof(ValidationResult.WithErrors));
        //object validationResult = x4.Invoke(null, [errors])!;

        object validationResult = typeof(ValidationResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
            .GetMethod(nameof(ValidationResult.WithErrors))!
            .Invoke(null, [errors])!;

        return (TResult)validationResult;
    }

    public static ValidationResult<TValueObject> CreateValidationResult<TValueObject>(
        this ICollection<Error> errors,
        Func<TValueObject> createValueObject) 
        where TValueObject : ValueObject
    {
        // if (errors is null)
        //     throw new ArgumentNullException($"{nameof(errors)} must not be null");
        ArgumentNullException.ThrowIfNull(errors);

        if (errors.Count is not 0)
            return ValidationResult<TValueObject>.WithErrors(errors.ToArray());

        return ValidationResult<TValueObject>.WithoutErrors(createValueObject.Invoke());
    }

    public static IList<Error> If(
        this IList<Error> errors,
        bool condition,
        Error error)
    {
        if (condition is true)
        {
            errors.Add(error);
        }

        return errors;
    }

    //// Use external validation that usually group multiple validations into logic group
    //public static IList<Error> UseValidation<TValue>(
    //    this IList<Error> errors,
    //    Func<IList<Error>, TValue, IList<Error>> validationSegment,
    //    TValue valueUnderValidation)
    //{
    //    return validationSegment(errors, valueUnderValidation);
    //}

    //// Use external validation that usually group multiple validations into logic group
    //public static IList<Error> UseValidation<TValue>(
    //    this IList<Error> errors,
    //    Func<TValue, IList<Error>> validationSegment,
    //    TValue valueUnderValidation)
    //{
    //    var errorsToAdd = validationSegment(valueUnderValidation);

    //    foreach (var errorToAdd in errorsToAdd)
    //    {
    //        errorsToAdd.Add(errorToAdd);
    //    }

    //    return errors;
    //}
}
