using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection;

public static class AdapterPersistenceLayerRegistration
{
    public static IServiceCollection RegisterAdapterPersistenceLayer(this IServiceCollection services,
                                                                     IHostEnvironment environment)
    {
        services.RegisterDatabaseContext(environment.IsDevelopment());

        return services;
    }
}
