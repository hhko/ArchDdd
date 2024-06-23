//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using static ArchDdd.Adapters.Persistence.Abstractions.Constants.Constants.Connection;
//using ArchDdd.Adapters.Infrastructure.Options;

//namespace ArchDdd.Adapters.Persistence.Repositories;

////Unable to create a 'DbContext' of type ''. 
////    The exception 'No suitable constructor was found for entity type 'User'. 
////    The following constructors had parameters that could not be bound to properties of the entity type:
////        Cannot bind 'username', 'email' in 'User(UserId id, Username username, Email email)'
////        Note that only mapped properties can be bound to constructor parameters.
////        Navigations to related entities, 
////        including references to owned types, 
////        cannot be bound.' was thrown while attempting to create an instance. 
////For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728

//public sealed class ArchDddDbContextFactory : IDesignTimeDbContextFactory<ArchDddDbContext>
//{
//    public ArchDddDbContext CreateDbContext(string[]? args = null)
//    {
//        var configuration = new ConfigurationBuilder()
//            .AddJsonFile(ConnectionStringJsonFile)
//            .Build();

//        var optionsBuilder = new DbContextOptionsBuilder<ArchDddDbContext>();

//        if (args is not null && args.Contains(TestConnection) is true)
//        {
//            //optionsBuilder.UseSqlServer(configuration.GetConnectionString(TestConnection));
//        }
//        else if (args is not null && args.Length is 1)
//        {
//            //optionsBuilder.UseSqlServer(args.Single());
//        }
//        else
//        {
//            //optionsBuilder.UseSqlServer(configuration.GetConnectionString(DefaultConnection));
//        }

//        Console.WriteLine("....test");

//        if (args is not null)
//        {
//            //Console.WriteLine(args.Single());
//            Console.WriteLine("....args");
//            foreach (var arg in args)
//            {
//                Console.WriteLine("....args2");
//                Console.WriteLine(arg);
//                //Console.WriteLine(args.Single());
//            }
//        }

//        //optionsBuilder.UseSqlite(configuration.GetConnectionString(DefaultConnection));

//        optionsBuilder.UseSqlite(configuration.GetConnectionString(DefaultConnection), o =>
//        {
//            o.MigrationsAssembly("Migrators.SqLite");
//        });

//        return new ArchDddDbContext(optionsBuilder.Options);
//    }
//}

using ArchDdd.Adapters.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class ArchDddDbContextFactory : IDesignTimeDbContextFactory<ArchDddDbContext>
{
    public ArchDddDbContext CreateDbContext(string[] args)
    {
        //var configuration = new ConfigurationBuilder().AddJsonFile(ConnectionStringJsonFile).Build();

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"../../{nameof(ArchDdd)}"))
            .AddJsonFile("appsettings.json")
            .AddCommandLine(args)
            .Build();

        //var optionsBuilder = new DbContextOptionsBuilder<ShopwayDbContext>();
        var optionsBuilder = new DbContextOptionsBuilder<ArchDddDbContext>();

        //if (args is not null && args.Contains(TestConnection) is true)
        //{
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString(TestConnection));
        //}
        //else if (args is not null && args.Length is 1)
        //{
        //    optionsBuilder.UseSqlServer(args.Single());
        //}
        //else
        //{
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString(DefaultConnection));
        //}
        optionsBuilder.UseSqlite("Data Source=Xyz.db");
        //builder.UseSqlite($"Data Source={nameof(ArchDdd)}.db", optionsBuilder =>
        //{
        //    // Migrators.Sqlite.dll
        //    optionsBuilder.MigrationsAssembly($"{nameof(Migrators)}.{nameof(Sqlite)}");
        //});

        return new ArchDddDbContext(optionsBuilder.Options);
    }
}
