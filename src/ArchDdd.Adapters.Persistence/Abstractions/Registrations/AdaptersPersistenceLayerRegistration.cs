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
        this IServiceCollection services,
        IHostEnvironment environment)
    {
        services
            .RegisterOptions()
            .RegisterDatabaseContext(environment.IsDevelopment())
            .RegisterDatabaseRepositories()
            .RegisterBackgroundJobs()
            .RegisterMediator();

        return services;
    }
}
