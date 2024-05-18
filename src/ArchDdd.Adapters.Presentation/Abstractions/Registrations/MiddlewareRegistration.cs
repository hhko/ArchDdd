using ArchDdd.Application.Abstractions.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;

internal static class MiddlewareRegistration
{
    internal static IServiceCollection RegisterMiddlewares(this IServiceCollection services)
    {
        // 순서에 따라 수행되기 때문에 순서가 중요하다.
        //services.AddScoped<ErrorHandlingMiddleware>();
        services.AddScoped<RequestTimeMiddleware>();

        return services;
    }

    internal static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app)
    {
        // 순서에 따라 수행되기 때문에 순서가 중요하다.
        //app.UseMiddleware<ErrorHandlingMiddleware>();
        app.UseMiddleware<RequestTimeMiddleware>();

        return app;
    }
}