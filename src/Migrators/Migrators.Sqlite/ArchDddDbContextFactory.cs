using ArchDdd.Adapters.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Migrators.Sqlite;

public sealed class ArchDddDbContextFactory : IDesignTimeDbContextFactory<ArchDddDbContext>
{
    public ArchDddDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ArchDddDbContext>();

        // ArchDdd.db
        optionsBuilder.UseSqlite($"Data Source={nameof(ArchDdd)}.db", optionBuilder =>
        {
            // Migrators.Sqlite.dll
            optionBuilder.MigrationsAssembly($"{nameof(Migrators)}.{nameof(Sqlite)}");
        });

        return new ArchDddDbContext(optionsBuilder.Options);
    }
}
