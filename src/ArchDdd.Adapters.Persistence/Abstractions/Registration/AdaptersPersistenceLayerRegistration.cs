using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection;

public static class AdaptersPersistenceLayerRegistration
{
    //public static IServiceCollection RegisterAdapterPersistenceLayer(
    //    this IServiceCollection services,
    //    IHostEnvironment environment)
    //{
    //    services.RegisterDatabaseContext(environment.IsDevelopment());

    //    return services;
    //}

    public static IServiceCollection RegisterAdaptersPersistenceLayer(
        this IServiceCollection services)
    {
        services
            .RegisterDatabaseContext()
            .RegisterBackgroundJobs();

        return services;
    }
}
