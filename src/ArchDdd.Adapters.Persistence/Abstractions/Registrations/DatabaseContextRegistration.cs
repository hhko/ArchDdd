using ArchDdd.Adapters.Infrastructure.Options;
using ArchDdd.Adapters.Infrastructure.Utilities;

namespace Microsoft.Extensions.DependencyInjection;

internal static class DatabaseContextRegistration
{
    internal static IServiceCollection RegisterDatabaseContext(
        this IServiceCollection services)
    //    bool isDevelopment)
    {
        var databaseOptions = services.GetOptions<DatabaseOptions>();
        return services;
    }
}
