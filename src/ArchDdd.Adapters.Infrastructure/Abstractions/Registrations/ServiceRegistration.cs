using ArchDdd.Adapters.Infrastructure.Validators;
using ArchDdd.Application.Abstractions;

namespace Microsoft.Extensions.DependencyInjection;

internal static class ServiceRegistration
{
    internal static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        // Validators
        services.AddScoped<IValidator, Validator>();

        return services;
    }
}
