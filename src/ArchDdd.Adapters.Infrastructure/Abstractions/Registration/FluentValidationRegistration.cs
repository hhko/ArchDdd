using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

internal static class FluentValidationRegistration
{
    internal static IServiceCollection RegisterFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly
            (
                ArchDdd.Adapters.Infrastructure.AssemblyReference.Assembly,
                includeInternalTypes: true
            );

        return services;
    }
}