using ArchDdd.Domain.Abstractions.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ArchDdd.Application.Abstractions.Constants.Constants.ProblemDetails;

namespace ArchDdd.Adapters.Presentation.Abstractions.Controllers;

public static class ProblemDetailsUtilities
{
    public static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        Error error,
        Error[]? errors = null,
        HttpContext? context = null)
    {
        //{
        //  "type": "ValidationError",
        //  "title": "ValidationError",
        //  "status": 400,
        //  "detail": "A validation problem occurred.",
        //  "errors": [
        //    {
        //      "code": "Username.TooLong",
        //      "message": "Username name must be at most 30 characters."
        //    }
        //  ]
        //}
        var problemDetails = new ProblemDetails()
        {
            Type = error.Code,
            Title = title,
            Status = status,
            Detail = error.Message,
            Extensions = { { nameof(errors), errors } }
        };

        if (context is not null)
        {
            problemDetails.Extensions.Add(RequestId, context.TraceIdentifier);
            problemDetails.Instance = context.Request.Path;
        }

        return problemDetails;
    }

    public static ProblemDetails CreateProblemDetails(
        string type,
        string title,
        int status,
        IList<string> errors)
    {
        var problemDetails = new ProblemDetails()
        {
            Type = type,
            Title = title,
            Status = status,
            Extensions = { { nameof(errors), errors } }
        };

        return problemDetails;
    }
}
