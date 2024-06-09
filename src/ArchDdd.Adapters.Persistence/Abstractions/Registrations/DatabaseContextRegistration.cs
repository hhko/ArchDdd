using ArchDdd.Adapters.Infrastructure.Utilities;
using ArchDdd.Adapters.Persistence.Options.Database;
using ArchDdd.Adapters.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using Quartz.Impl.AdoJobStore.Common;
using static ArchDdd.Adapters.Persistence.Abstractions.Constants.DbConstants;

namespace Microsoft.Extensions.DependencyInjection;

internal static class DatabaseContextRegistration
{
    internal static IServiceCollection RegisterDatabaseContext(
        this IServiceCollection services,
        bool isDevelopment)
    {
        services.AddDbContextPool<ArchDddDbContext>((serviceProvider, optionsBuilder) =>
        {
            var databaseOptions = services.GetOptions<DatabaseOptions>();

            optionsBuilder.UseDatabase(databaseOptions);

            if (isDevelopment)
            {
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
            }
        });

        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        return services;
    }

    private static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder builder, DatabaseOptions databaseOptions)
    {
        return databaseOptions.Provider.ToLowerInvariant() switch
        {
            Provider.PostgreSQL => builder.UseNpgsql(databaseOptions.ConnectionString, options =>
                {

                }),
            Provider.Sqlite => builder.UseSqlite(databaseOptions.ConnectionString, options =>
                {
                    options.CommandTimeout(databaseOptions.CommandTimeout);
                }),
            _ => throw new InvalidOperationException($"DB Provider {databaseOptions.Provider} is not supported."),
        };
    }
}