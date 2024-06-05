using ArchDdd.Domain.Abstractions.Results.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using static ArchDdd.Application.Abstractions.Constants.Constants.ProblemDetails;
using IResult = ArchDdd.Domain.Abstractions.Results.Contracts.IResult;
using static ArchDdd.Adapters.Presentation.Abstractions.Utilities.ProblemDetailsUtilities;

namespace ArchDdd.Adapters.Presentation.Abstractions.Utilities;

public static class ResultUtilities
{
    public static Ok ToOkResult(this IResult result)
    {
        return result switch
        {
            { IsSuccess: true } => TypedResults.Ok(),

            _ => throw new InvalidOperationException("Result was failed")
        };
    }

    public static Ok<TValue> ToOkResult<TValue>(this IResult<TValue> result)
    {
        return result switch
        {
            { IsSuccess: true } => TypedResults.Ok(result.Value),

            _ => throw new InvalidOperationException("Result was failed")
        };
    }

    //public BadRequest<TValue> ToBadRequestResult<TValue>(this IResult<TValue> result)
    //{
    //    return TypedResults.BadRequest(result.Value);
    //}

    //public static ForbidHttpResult ToForbidResult(this AuthorizationResult result)
    //{
    //    return TypedResults.Forbid();
    //}

    public static ProblemHttpResult ToProblemHttpResult(this IResult result)
    {
        return result switch
        {
            // 성공
            { IsSuccess: true } => throw new InvalidOperationException("Result was successful"),

            // 실패 IValidationResult
            IValidationResult validationResult => TypedResults.Problem(
                CreateProblemDetails(
                    ValidationError,
                    StatusCodes.Status400BadRequest,
                    result.Error,
                    validationResult.ValidationErrors)),

            // 실패: IResult
            _ => TypedResults.Problem(
                CreateProblemDetails(
                    InvalidRequest,
                    StatusCodes.Status400BadRequest,
                    result.Error))
        };
    }
}
