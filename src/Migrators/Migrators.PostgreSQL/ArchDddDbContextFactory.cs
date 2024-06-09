using ArchDdd.Adapters.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Migrators.PostgreSQL;

public sealed class ArchDddDbContextFactory : IDesignTimeDbContextFactory<ArchDddDbContext>
{
    public ArchDddDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ArchDddDbContext>();

        // "Host=my_host;Database=my_db;Username=my_user;Password=my_pw"
        optionsBuilder.UseNpgsql("", optionBuilder =>
        {
            // Migrators.PostgreSQL.dll
            optionBuilder.MigrationsAssembly($"{nameof(Migrators)}.{nameof(PostgreSQL)}");
        });

        return new ArchDddDbContext(optionsBuilder.Options);
    }
}
