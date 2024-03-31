namespace Microsoft.Extensions.DependencyInjection;

public static class AdapterInfrastructureLayerRegistration
{
    public static IServiceCollection RegisterAdapterInfrastructureLayer(this IServiceCollection services)
    {
        services.RegisterFluentValidation();
        services.RegisterOptions();

        return services;
    }
}
