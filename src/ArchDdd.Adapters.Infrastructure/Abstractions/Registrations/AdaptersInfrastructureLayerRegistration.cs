using Microsoft.Extensions.Logging;
using System;

namespace Microsoft.Extensions.DependencyInjection;

public static class AdaptersInfrastructureLayerRegistration
{
    public static IServiceCollection RegisterAdaptersInfrastructureLayer(
        this IServiceCollection services,
        ILoggingBuilder loggingBuilder)
    {
        services
            .RegisterOptions()
            .RegisterServices()
            .RegisterTelemetry(loggingBuilder);

        return services;
    }
}
