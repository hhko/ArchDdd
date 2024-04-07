using ArchDdd.Adapters.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class OptionsRegistration
{
    internal static IServiceCollection RegisterOptions(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();

        services.AddSingleton<IValidateOptions<DatabaseOptions>, DatabaseOptionsValidator>();

        return services;
    }
}