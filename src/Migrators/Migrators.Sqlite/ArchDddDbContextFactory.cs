using ArchDdd.Adapters.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace Migrators.Sqlite;

public sealed class ArchDddDbContextFactory : IDesignTimeDbContextFactory<ArchDddDbContext>
{
    public ArchDddDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ArchDddDbContext>();


        // dotnet ef database update -- --environment Production
        // https://medium.com/@caio_vms_78331/applying-database-migrations-with-ef-core-in-ci-cd-pipelines-10468e11dfdd
        // https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?WT.mc_id=DOP-MVP-4039670&tabs=dotnet-core-cli#bundles
        // https://blog.danielpadua.dev/posts/efcore-implementing-a-multi-environment-designtimedbcontextfactory/


        //// ArchDdd\src\Migrators\Migrators.Sqlite
        ////  ->
        //// ArchDdd\src\ArchDdd
        //string hostPath = Path.Combine(Directory.GetCurrentDirectory(),
        //    "..", "..",
        //    nameof(ArchDdd));

        //string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;

        //Console.WriteLine(hostPath);
        //Console.WriteLine(environment);

        //// Build config
        //IConfiguration config = new ConfigurationBuilder()
        //    .SetBasePath(hostPath)
        //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //    .AddJsonFile($"appsettings.{environment}.json", optional: true)
        //    .AddEnvironmentVariables()
        //    .Build();

        // 옵션 
        // ArchDdd.db
        builder.UseSqlite($"Data Source={nameof(ArchDdd)}.db", optionsBuilder =>
        {
            // Migrators.Sqlite.dll
            optionsBuilder.MigrationsAssembly($"{nameof(Migrators)}.{nameof(Sqlite)}");
        });

        return new ArchDddDbContext(builder.Options);
    }
}
