using ArchDdd.Adapters.Infrastructure.Options;
using ArchDdd.Adapters.Infrastructure.Options.OpenTelemetry;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

internal static class OptionsRegistration
{
    internal static IServiceCollection RegisterOptions(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();
        services.ConfigureOptions<OpenTelemetryOptionsSetup>();

        services.AddSingleton<IValidateOptions<DatabaseOptions>, DatabaseOptionsValidator>();
        services.AddSingleton<IValidateOptions<OpenTelemetryOptions>, OpenTelemetryOptionsValidator>();

        return services;
    }
}