using ArchDdd.Adapters.Infrastructure.Options;
using ArchDdd.Adapters.Infrastructure.Utilities;
using ArchDdd.Adapters.Persistence;
using ArchDdd.Adapters.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

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

            var assemblyLocation = Path.GetDirectoryName(ArchDdd.Adapters.Persistence.AssemblyReference.Assembly.Location)!;

            // 임시
            var absolutePath = Path.Combine(
                "C:\\Workspace\\Github\\ArchDdd\\src\\ArchDdd.Adapters.Persistence",
                "ArchDddDb.db");

            //optionsBuilder.UseSqlite($"Data Source={absolutePath}");

            optionsBuilder.UseSqlite($"Data Source={absolutePath}", options =>
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

        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        return services;
    }
}
