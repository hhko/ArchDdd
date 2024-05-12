using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

internal static class ValidationRegistration
{
    internal static IServiceCollection RegisterValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(
                assembly: ArchDdd.Application.AssemblyReference.Assembly,
                includeInternalTypes: true);

        return services;
    }
}
