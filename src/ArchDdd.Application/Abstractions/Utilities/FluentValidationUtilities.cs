using ArchDdd.Domain.Abstractions.Results;
using FluentValidation;
using PrimitiveUtilities;

namespace ArchDdd.Application.Abstractions.Utilities;

public static class FluentValidationUtilities
{
    public static IRuleBuilderOptions<TInput, TOutput> MustSatisfyValueObjectValidation<TInput, TOutput>(
        this IRuleBuilder<TInput, TOutput> ruleBuilder,
        Func<TOutput, IList<Error>> validationMethod)
    {
        return (IRuleBuilderOptions<TInput, TOutput>)ruleBuilder.Custom((value, context) =>
        {
            IList<Error> errors = validationMethod(value);

            if (errors.NotNullOrEmpty())
            {
                foreach (var error in errors)
                {
                    context.AddFailure(
                        propertyName: error.Code,
                        errorMessage: error.Message); // (error.Serialize());
                }
            }
        });
    }
}
