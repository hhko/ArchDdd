namespace Microsoft.Extensions.DependencyInjection;

public static class AdaptersPresentationLayerRegistration
{
    public static IServiceCollection RegisterAdaptersPresentationLayer(
        this IServiceCollection services)
    {
        //services
        //    .RegisterDatabaseContext()
        //    .RegisterBackgroundJobs();

        return services;
    }
}
