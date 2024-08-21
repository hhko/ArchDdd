using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld.Adapters.Infrastructure.Abstractions.Registrations;

public static class AdaptersInfrastructureLayerRegistration
{
    public static IServiceCollection RegisterAdaptersInfrastructureLayer(
        this IServiceCollection services,
        ILoggingBuilder loggingBuilder)
    {
        services
            .RegisterOptions()
            .RegisterServices();
        //.RegisterTelemetry(loggingBuilder);

        return services;
    }
}
