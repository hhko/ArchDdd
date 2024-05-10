namespace Microsoft.Extensions.DependencyInjection;

internal static class MediatorRegistration
{
    internal static IServiceCollection RegisterMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(ArchDdd.Application.AssemblyReference.Assembly));

        return services;
    }
}