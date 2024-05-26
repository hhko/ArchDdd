using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using IResult = ArchDdd.Domain.Abstractions.Results.Contracts.IResult;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using static ArchDdd.Adapters.Presentation.Abstractions.Controllers.ProblemDetailsUtilities;
using static ArchDdd.Application.Abstractions.Constants.Constants.ProblemDetails;

namespace ArchDdd.Adapters.Presentation.Abstractions.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Produces("application/json")]
public abstract class ApiController(ISender sender) : ControllerBase
{
    protected readonly ISender Sender = sender;

    protected static ProblemHttpResult HandleFailure(IResult result)
    {
        return result switch
        {
            // 성공
            { IsSuccess: true } => throw new InvalidOperationException("Result was successful"),

            // 실패: IValidationResult
            IValidationResult validationResult => TypedResults.Problem(
                CreateProblemDetails(
                    ValidationError,
                    StatusCodes.Status400BadRequest,
                    result.Error,
                    validationResult.ValidationErrors)),

            // 실패: IResult(IValidationResult 외)
            _ => TypedResults.Problem(
                CreateProblemDetails(
                    InvalidRequest,
                    StatusCodes.Status400BadRequest,
                    result.Error))
        };
    }

    //protected static CreatedAtRoute<T> CreatedAtActionResult<T>(IResult<T> result, string? routeName)
    //{
    //    return TypedResults.CreatedAtRoute
    //    (
    //        result.Value,
    //        routeName,
    //        new { id = result.Value }
    //    );
    //}
}