using ArchDdd.Application.Abstractions.Exceptions;
using ArchDdd.Domain.Abstractions.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static ArchDdd.Adapters.Presentation.Abstractions.Controllers.ProblemDetailsUtilities;
using static ArchDdd.Application.Abstractions.Constants.Constants.ProblemDetails;

namespace ArchDdd.Adapters.Presentation.Abstractions.Middlewares;

public sealed class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    private const string ProblemDetailsContentType = "application/problem+json";
    private readonly ILogger<ErrorHandlingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = exception switch
            {
                NotFoundException => 404,
                BadRequestException => 400,
                ForbidException => 403,
                _ => 500
            };

            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var problemDetails = CreateProblemDetails(
           title: ExceptionOccurred,
           status: context.Response.StatusCode,
           error: Error.FromException(exception),
           context: context);

        _logger.LogUnexpectedException(
            context.Request.Method,
            context.Request.Path,
            exception.GetType().Name,
            exception.Source,
            exception.Message,
            exception.StackTrace);

        // {
        //   "type": "Exception.InvalidOperationException",
        //   "title": "ExceptionOccurred",
        //   "status": 500,
        //   "detail": "The value of a failure result can not be accessed. Type 'ArchDdd.Domain.AggregateRoots.Users.ValueObjects.Email'.",
        //   "instance": "/api/user/register",
        //   "errors": null,
        //   "RequestId": "0HN3NR8MLI1RO:00000001"
        // }
        await context.Response.WriteAsJsonAsync(
            problemDetails,
            typeof(ProblemDetails),
            options: null,
            contentType: ProblemDetailsContentType);
    }
}

public static partial class LoggerMessageDefinitionsUtilities
{
    [LoggerMessage(
        EventId = 10,
        EventName = $"{nameof(ErrorHandlingMiddleware)}",
        Level = LogLevel.Error,
        Message = "Request [{Method}] at {Path} thrown an exception '{Name}' from source '{Source}'. \n Exception message: '{Message}'. \n StackTrace: '{StackTrace}'",
        SkipEnabledCheck = true)]
    public static partial void LogUnexpectedException(this ILogger logger,
        string method,
        PathString path,
        string name,
        string? source,
        string message,
        string? stackTrace);
}

// fail: ArchDdd.Adapters.Presentation.Abstractions.Middlewares.ErrorHandlingMiddleware[10]
//       Request [POST] at /api/user/register thrown an exception 'InvalidOperationException' from source 'ArchDdd.Domain'.
//  Exception message: 'The value of a failure result can not be accessed. Type 'ArchDdd.Domain.AggregateRoots.Users.ValueObjects.Email'.'.
//  StackTrace: '   at ArchDdd.Domain.Abstractions.Results.Result`1.get_Value() in C:\Workspace\Github\archddd\src\ArchDdd.Domain\Abstractions\Results\Result.cs:line 105
//          at ArchDdd.Application.UseCases.Users.Commands.RegisterUser.RegisterUserCommandHandler.Handle(RegisterUserCommand command, CancellationToken cancellationToken) in C:\Workspace\Github\archddd\src\ArchDdd.Application\UseCases\Users\Commands\RegisterUser\RegisterUserCommandHandler.cs:line 34
//          at ArchDdd.Application.Abstractions.Pipelines.ValidatorPipeline`2.Handle(TRequest request, RequestHandlerDelegate`1 next, CancellationToken cancellationToken) in C:\Workspace\Github\archddd\src\ArchDdd.Application\Abstractions\Pipelines\ValidatorPipeline.cs:line 55
//          at ArchDdd.Application.Abstractions.Pipelines.LoggingPipeline`2.Handle(TRequest request, RequestHandlerDelegate`1 next, CancellationToken cancellationToken) in C:\Workspace\Github\archddd\src\ArchDdd.Application\Abstractions\Pipelines\LoggingPipeline.cs:line 24
//          at ArchDdd.Adapters.Presentation.Controllers.UserController.Register(RegisterUserCommand command, CancellationToken cancellationToken) in C:\Workspace\Github\archddd\src\ArchDdd.Adapters.Presentation\Controllers\UserController.cs:line 23
//          at lambda_method6(Closure, Object)
//          at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.AwaitableObjectResultExecutor.Execute(ActionContext actionContext, IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
//          at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask`1 actionResultValueTask)
//          at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
//          at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)
//          at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
//          at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
//       --- End of stack trace from previous location ---
//          at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
//          at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
//          at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
//          at ArchDdd.Application.Abstractions.Middlewares.RequestTimeMiddleware.InvokeAsync(HttpContext context, RequestDelegate next) in C:\Workspace\Github\archddd\src\ArchDdd.Adapters.Presentation\Abstractions\Middlewares\RequestTimeMiddleware.cs:line 15
//          at Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.InterfaceMiddlewareBinder.<>c__DisplayClass2_0.<<CreateMiddleware>b__0>d.MoveNext()
//       --- End of stack trace from previous location ---
//          at ArchDdd.Adapters.Presentation.Abstractions.Middlewares.ErrorHandlingMiddleware.InvokeAsync(HttpContext context, RequestDelegate next) in C:\Workspace\Github\archddd\src\ArchDdd.Adapters.Presentation\Abstractions\Middlewares\ErrorHandlingMiddleware.cs:line 20'
// LogRecord.Timestamp:               2024-05-19T07:57:12.9162948Z
// LogRecord.TraceId:                 a13740dd6d4341143567a1d0fa095383
// LogRecord.SpanId:                  e5cda15125915a67
// LogRecord.TraceFlags:              None
// LogRecord.CategoryName:            ArchDdd.Adapters.Presentation.Abstractions.Middlewares.ErrorHandlingMiddleware
// LogRecord.Severity:                Error
// LogRecord.SeverityText:            Error
// LogRecord.FormattedMessage:        Request [POST] at /api/user/register thrown an exception 'InvalidOperationException' from source 'ArchDdd.Domain'.
//  Exception message: 'The value of a failure result can not be accessed. Type 'ArchDdd.Domain.AggregateRoots.Users.ValueObjects.Email'.'.
//  StackTrace: '   at ArchDdd.Domain.Abstractions.Results.Result`1.get_Value() in C:\Workspace\Github\archddd\src\ArchDdd.Domain\Abstractions\Results\Result.cs:line 105
//    at ArchDdd.Application.UseCases.Users.Commands.RegisterUser.RegisterUserCommandHandler.Handle(RegisterUserCommand command, CancellationToken cancellationToken) in C:\Workspace\Github\archddd\src\ArchDdd.Application\UseCases\Users\Commands\RegisterUser\RegisterUserCommandHandler.cs:line 34
//    at ArchDdd.Application.Abstractions.Pipelines.ValidatorPipeline`2.Handle(TRequest request, RequestHandlerDelegate`1 next, CancellationToken cancellationToken) in C:\Workspace\Github\archddd\src\ArchDdd.Application\Abstractions\Pipelines\ValidatorPipeline.cs:line 55
//    at ArchDdd.Application.Abstractions.Pipelines.LoggingPipeline`2.Handle(TRequest request, RequestHandlerDelegate`1 next, CancellationToken cancellationToken) in C:\Workspace\Github\archddd\src\ArchDdd.Application\Abstractions\Pipelines\LoggingPipeline.cs:line 24
//    at ArchDdd.Adapters.Presentation.Controllers.UserController.Register(RegisterUserCommand command, CancellationToken cancellationToken) in C:\Workspace\Github\archddd\src\ArchDdd.Adapters.Presentation\Controllers\UserController.cs:line 23
//    at lambda_method6(Closure, Object)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.AwaitableObjectResultExecutor.Execute(ActionContext actionContext, IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask`1 actionResultValueTask)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
// --- End of stack trace from previous location ---
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
//    at ArchDdd.Application.Abstractions.Middlewares.RequestTimeMiddleware.InvokeAsync(HttpContext context, RequestDelegate next) in C:\Workspace\Github\archddd\src\ArchDdd.Adapters.Presentation\Abstractions\Middlewares\RequestTimeMiddleware.cs:line 15
//    at Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.InterfaceMiddlewareBinder.<>c__DisplayClass2_0.<<CreateMiddleware>b__0>d.MoveNext()
// --- End of stack trace from previous location ---
//    at ArchDdd.Adapters.Presentation.Abstractions.Middlewares.ErrorHandlingMiddleware.InvokeAsync(HttpContext context, RequestDelegate next) in C:\Workspace\Github\archddd\src\ArchDdd.Adapters.Presentation\Abstractions\Middlewares\ErrorHandlingMiddleware.cs:line 20'
// LogRecord.Body:                    Request [{Method}] at {Path} thrown an exception '{Name}' from source '{Source}'.
//  Exception message: '{Message}'.
//  StackTrace: '{StackTrace}'
// LogRecord.Attributes (Key:Value):
//     Method: POST
//     Path: /api/user/register
//     Name: InvalidOperationException
//     Source: ArchDdd.Domain
//     Message: The value of a failure result can not be accessed. Type 'ArchDdd.Domain.AggregateRoots.Users.ValueObjects.Email'.
//     StackTrace:    at ArchDdd.Domain.Abstractions.Results.Result`1.get_Value() in C:\Workspace\Github\archddd\src\ArchDdd.Domain\Abstractions\Results\Result.cs:line 105
//    at ArchDdd.Application.UseCases.Users.Commands.RegisterUser.RegisterUserCommandHandler.Handle(RegisterUserCommand command, CancellationToken cancellationToken) in C:\Workspace\Github\archddd\src\ArchDdd.Application\UseCases\Users\Commands\RegisterUser\RegisterUserCommandHandler.cs:line 34
//    at ArchDdd.Application.Abstractions.Pipelines.ValidatorPipeline`2.Handle(TRequest request, RequestHandlerDelegate`1 next, CancellationToken cancellationToken) in C:\Workspace\Github\archddd\src\ArchDdd.Application\Abstractions\Pipelines\ValidatorPipeline.cs:line 55
//    at ArchDdd.Application.Abstractions.Pipelines.LoggingPipeline`2.Handle(TRequest request, RequestHandlerDelegate`1 next, CancellationToken cancellationToken) in C:\Workspace\Github\archddd\src\ArchDdd.Application\Abstractions\Pipelines\LoggingPipeline.cs:line 24
//    at ArchDdd.Adapters.Presentation.Controllers.UserController.Register(RegisterUserCommand command, CancellationToken cancellationToken) in C:\Workspace\Github\archddd\src\ArchDdd.Adapters.Presentation\Controllers\UserController.cs:line 23
//    at lambda_method6(Closure, Object)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.AwaitableObjectResultExecutor.Execute(ActionContext actionContext, IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask`1 actionResultValueTask)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
// --- End of stack trace from previous location ---
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
//    at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
//    at ArchDdd.Application.Abstractions.Middlewares.RequestTimeMiddleware.InvokeAsync(HttpContext context, RequestDelegate next) in C:\Workspace\Github\archddd\src\ArchDdd.Adapters.Presentation\Abstractions\Middlewares\RequestTimeMiddleware.cs:line 15
//    at Microsoft.AspNetCore.Builder.UseMiddlewareExtensions.InterfaceMiddlewareBinder.<>c__DisplayClass2_0.<<CreateMiddleware>b__0>d.MoveNext()
// --- End of stack trace from previous location ---
//    at ArchDdd.Adapters.Presentation.Abstractions.Middlewares.ErrorHandlingMiddleware.InvokeAsync(HttpContext context, RequestDelegate next) in C:\Workspace\Github\archddd\src\ArchDdd.Adapters.Presentation\Abstractions\Middlewares\ErrorHandlingMiddleware.cs:line 20
//     OriginalFormat (a.k.a Body): Request [{Method}] at {Path} thrown an exception '{Name}' from source '{Source}'.
//  Exception message: '{Message}'.
//  StackTrace: '{StackTrace}'
// LogRecord.EventId:                 10
// LogRecord.EventName:               ErrorHandlingMiddleware
// LogRecord.ScopeValues (Key:Value):
// [Scope.0]:SpanId: e5cda15125915a67
// [Scope.0]:TraceId: a13740dd6d4341143567a1d0fa095383
// [Scope.0]:ParentId: c26294167d21e066
// [Scope.1]:ConnectionId: 0HN3NR4T4JQJB
// [Scope.2]:RequestId: 0HN3NR4T4JQJB:00000001
// [Scope.2]:RequestPath: /api/user/register
// 
// Resource associated with LogRecord:
// service.name: ArchDdd
// service.instance.id: 9d645f00-a130-4efe-8c5d-a3bc45bf8e05
// telemetry.sdk.name: opentelemetry
// telemetry.sdk.language: dotnet
// telemetry.sdk.version: 1.8.1