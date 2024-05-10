namespace Microsoft.Extensions.DependencyInjection;

public static class AdaptersInfrastructureLayerRegistration
{
    public static IServiceCollection RegisterAdaptersInfrastructureLayer(
        this IServiceCollection services)
    {
        services
            .RegisterOptions()
            .RegisterServices();

        return services;
    }
}
