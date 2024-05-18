using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ArchDdd.Application.Abstractions.Middlewares;

public sealed class RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger) : IMiddleware
{
    private const int RequestDurationLogLevel = 4;
    private readonly ILogger<RequestTimeMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var startTime = Stopwatch.GetTimestamp();
        await next.Invoke(context);
        var requestDuration = Stopwatch.GetElapsedTime(startTime);

        if (requestDuration.Seconds >= RequestDurationLogLevel)
        {
            _logger.LogRequestTime(context.Request.Method, context.Request.Path, requestDuration.TotalMilliseconds);
        }
    }
}

public static partial class LoggerMessageDefinitionsUtilities
{
    [LoggerMessage(
        EventId = 0,
        EventName = $"{nameof(RequestTimeMiddleware)}",
        Level = LogLevel.Warning,
        Message = "Request [{Method}] at {Path} took {Milliseconds} ms",
        SkipEnabledCheck = true)]
    public static partial void LogRequestTime(this ILogger logger, string method, PathString path, double milliseconds);
}

// EventId?
// SkipEnabledCheck?
// service.name: unknown_service:ArchDdd?

// warn: ArchDdd.Application.Abstractions.Middlewares.RequestTimeMiddleware[0]
//       Request [POST] at /api/user/register took 37205.9216 ms
// LogRecord.Timestamp:               2024-05-18T22:42:21.4624039Z
// LogRecord.TraceId:                 f37bdaa73ae16f0c7aa161a69f48bd4a
// LogRecord.SpanId:                  ce657749d526be42
// LogRecord.TraceFlags:              None
// LogRecord.CategoryName:            ArchDdd.Application.Abstractions.Middlewares.RequestTimeMiddleware        <- 로그 출력 클래스
// LogRecord.Severity:                Warn                                                                      <- 로그 수준 약어
// LogRecord.SeverityText:            Warning                                                                   <- 로그 수준
// LogRecord.FormattedMessage:        Request [POST] at /api/user/register took 37205.9216 ms                   <- 로그
// LogRecord.Body:                    Request [{Method}] at {Path} took {Milliseconds} ms                       <- 로그 형식: Meesage
// LogRecord.Attributes (Key:Value):                                                                            <- 로그 키/값
//     Method: POST                                                                                             <- Method
//     Path: /api/user/register                                                                                 <- Path
//     Milliseconds: 37205.9216                                                                                 <- Milliseconds
//     OriginalFormat (a.k.a Body): Request [{Method}] at {Path} took {Milliseconds} ms
// LogRecord.ScopeValues (Key:Value):
// [Scope.0]:SpanId: ce657749d526be42
// [Scope.0]:TraceId: f37bdaa73ae16f0c7aa161a69f48bd4a
// [Scope.0]:ParentId: dc8dec92fdaf6887
// [Scope.1]:ConnectionId: 0HN3NHDA2EHP8
// [Scope.2]:RequestId: 0HN3NHDA2EHP8:00000004
// [Scope.2]:RequestPath: /api/user/register
// 
// Resource associated with LogRecord:
// telemetry.sdk.name: opentelemetry
// telemetry.sdk.language: dotnet
// telemetry.sdk.version: 1.8.1
// service.name: unknown_service:ArchDdd