using ArchDdd.Application.UseCases.Users.Commands.RegisterUser;
using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArchDdd.Application.Abstractions.Pipelines;

public sealed class LoggingPipeline<TRequest, TResponse>(ILogger<LoggingPipeline<TRequest, TResponse>> logger) 
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IResult
{
    private readonly ILogger<LoggingPipeline<TRequest, TResponse>> _logger = logger;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _logger.LogStartingRequest(typeof(TRequest).Name, DateTime.UtcNow);

        var result = await next();

        if (result.IsSuccess)
        {
            _logger.LogCompletingRequest(typeof(TRequest).Name, DateTime.UtcNow);
            return result;
        }

        if (result is IValidationResult validationResult)
        {
        //
        // fail: ArchDdd.Application.Abstractions.Pipelines.LoggingPipeline[4]
        //       Request failed RegisterUserCommand, Username name must be at most 30 characters., Username contains illegal character., 05/12/2024 08:08:40
            _logger.LogFailedRequestBasedOnValidationErrors(typeof(TRequest).Name, validationResult.ValidationErrors, DateTime.UtcNow);
            return result;
        }

        _logger.LogFailedRequestBasedOnSingleError(typeof(TRequest).Name, result.Error, DateTime.UtcNow);
        return result;
    }
}


// {
//   "Timestamp": "17:14:19 ",
//   "EventId": 1,
//   "LogLevel": "Information",
//   "Category": "ArchDdd.Application.Abstractions.Pipelines.LoggingPipeline",
//   "Message": "Starting request RegisterUserCommand, 05/12/2024 08:14:19",
//   "State": {
//     "Message": "Starting request RegisterUserCommand, 05/12/2024 08:14:19",
//     "RequestName": "RegisterUserCommand",
//     "DateTimeUtc": "05/12/2024 08:14:19",
//     "{OriginalFormat}": "Starting request {RequestName}, {DateTimeUtc}"
//   }
// }
// {
//   "Timestamp": "17:14:19 ",
//   "EventId": 4,
//   "LogLevel": "Error",
//   "Category": "ArchDdd.Application.Abstractions.Pipelines.LoggingPipeline",
//   "Message": "Request failed RegisterUserCommand, Username name must be at most 30 characters., Username contains illegal character., 05/12/2024 08:14:19",
//   "State": {
//     "Message": "Request failed RegisterUserCommand, Username name must be at most 30 characters., Username contains illegal character., 05/12/2024 08:14:19",
//     "RequestName": "RegisterUserCommand",
//     "ValidationErrors": "ArchDdd.Domain.Abstractions.Results.Error[]",
//     "DateTimeUtc": "05/12/2024 08:14:19",
//     "{OriginalFormat}": "Request failed {RequestName}, {ValidationErrors}, {DateTimeUtc}"
//   }
// }

//{
//  "Timestamp": "17:20:37 ",
//  "EventId": 4,
//  "LogLevel": "Error",
//  "Category": "ArchDdd.Application.Abstractions.Pipelines.LoggingPipeline",
//  "Message": "Request failed RegisterUserCommand, Username name must be at most 30 characters., Username contains illegal character., 05/12/2024 08:20:37",
//  "State": {
//    "Message": "Request failed RegisterUserCommand, Username name must be at most 30 characters., Username contains illegal character., 05/12/2024 08:20:37",
//    "RequestName": "RegisterUserCommand",
//    "ValidationErrors": "ArchDdd.Domain.Abstractions.Results.Error[]",
//    "DateTimeUtc": "05/12/2024 08:20:37",
//    "{OriginalFormat}": "Request failed {RequestName}, {ValidationErrors}, {DateTimeUtc}"
//  }
//}

public static partial class LoggerMessageDefinitionsUtilities
{
    [LoggerMessage(
        EventId = 1,
        EventName = $"StartingRequest in {nameof(LoggingPipeline<IRequest<IResult>, IResult>)}",
        Level = LogLevel.Information,
        Message = "Starting request {RequestName}, {DateTimeUtc}",
        SkipEnabledCheck = true)]
    public static partial void LogStartingRequest(this ILogger logger, string requestName, DateTime dateTimeUtc);

    [LoggerMessage(
        EventId = 2,
        EventName = $"CompletingRequest in {nameof(LoggingPipeline<IRequest<IResult>, IResult>)}",
        Level = LogLevel.Information,
        Message = "Request completed {requestName}, {DateTimeUtc}",
        SkipEnabledCheck = true)]
    public static partial void LogCompletingRequest(this ILogger logger, string requestName, DateTime dateTimeUtc);

    [LoggerMessage(
        EventId = 3,
        EventName = $"FailedRequestBasedOnSingleError in {nameof(LoggingPipeline<IRequest<IResult>, IResult>)}",
        Level = LogLevel.Error,
        Message = "Request failed {RequestName}, {Error}, {DateTimeUtc}",
        SkipEnabledCheck = true)]
    public static partial void LogFailedRequestBasedOnSingleError(this ILogger logger, string requestName, Error error, DateTime dateTimeUtc);

    [LoggerMessage(
        EventId = 4,
        EventName = $"FailedRequestBasedOnValidationErrors in {nameof(LoggingPipeline<IRequest<IResult>, IResult>)}",
        Level = LogLevel.Error,
        Message = "Request failed {RequestName}, {ValidationErrors}, {DateTimeUtc}",
        SkipEnabledCheck = true)]
    public static partial void LogFailedRequestBasedOnValidationErrors(this ILogger logger, string requestName, Error[] validationErrors, DateTime dateTimeUtc);
}
