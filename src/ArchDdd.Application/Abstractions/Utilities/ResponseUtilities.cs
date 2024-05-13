using ArchDdd.Application.Abstractions.CQRS;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using ArchDdd.Domain.Abstractions.Results;

namespace ArchDdd.Application.Abstractions.Utilities;

public static class ResponseUtilities
{
    public static IResult<TResponse> ToResult<TResponse>(this TResponse response)
        where TResponse : class, IResponse
    {
        return Result.Create(response);
    }

    //public static IResult<TResponse> ToResult<TResponse>(this ValidationResult<TResponse> response)
    //    where TResponse : class, IResponse
    //{
    //    return response;
    //}
}
