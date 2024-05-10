using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

internal static class ValidatorRegistration
{
    internal static IServiceCollection RegisterValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(
                assembly: ArchDdd.Application.AssemblyReference.Assembly,
                includeInternalTypes: true);

        return services;
    }
}
