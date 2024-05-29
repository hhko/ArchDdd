using ArchDdd.Adapters.Infrastructure.Options;
using ArchDdd.Adapters.Infrastructure.Utilities;
using ArchDdd.Adapters.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Microsoft.Extensions.DependencyInjection;

internal static class DatabaseContextRegistration
{
    internal static IServiceCollection RegisterDatabaseContext(
        this IServiceCollection services)
    //    bool isDevelopment)
    {
        services.AddDbContextPool<ArchDddDbContext>((serviceProvider, optionsBuilder) =>
        {
            var databaseOptions = services.GetOptions<DatabaseOptions>();

            optionsBuilder.UseSqlite("Data Source=ArchDddDb.db", options =>
            {
                options.CommandTimeout(databaseOptions.CommandTimeout);

                // Sqlite NotSupported
                //
                //options.EnableRetryOnFailure(
                //    databaseOptions.MaxRetryCount,
                //    TimeSpan.FromSeconds(databaseOptions.MaxRetryDelay),
                //    []);
            });

            //if (isDevelopment)
            //{
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.ConfigureWarnings(warnings =>
            {
                warnings.Log(new Logging.EventId[]
                {
                    CoreEventId.FirstWithoutOrderByAndFilterWarning,
                    CoreEventId.RowLimitingOperationWithoutOrderByWarning
                });
            });
            //}
        });

        //services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        return services;
    }
}
