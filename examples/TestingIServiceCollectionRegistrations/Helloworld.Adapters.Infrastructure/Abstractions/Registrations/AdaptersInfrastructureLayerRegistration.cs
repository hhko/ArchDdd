using Microsoft.Extensions.DependencyInjection;

namespace Helloworld.Adapters.Infrastructure.Abstractions.Registrations;

public static class AdaptersInfrastructureLayerRegistration
{
    public static IServiceCollection RegisterAdaptersInfrastructureLayer(
        this IServiceCollection services)
    {
        services.RegisterTelemetry();

        return services;
    }
}
