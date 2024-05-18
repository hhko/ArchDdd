using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;

public static class AdaptersPresentationLayerRegistration
{
    public static IServiceCollection RegisterAdaptersPresentationLayer(
        this IServiceCollection services)
    {
        services
            .RegisterControllers()
            .RegisterOpenApi()
            .RegisterMiddlewares();

        return services;
    }

    public static IApplicationBuilder UseAdaptersPresentationLayer(this IApplicationBuilder app)
    {
        app.UseOpenApi()
           .UseMiddlewares();

        return app;
    }
}
