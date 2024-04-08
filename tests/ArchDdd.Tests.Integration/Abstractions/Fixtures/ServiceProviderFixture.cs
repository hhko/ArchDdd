using static ArchDdd.Tests.Integration.Abstractions.Constants.Constants.CollectionName;
using static ArchDdd.Tests.Integration.Abstractions.Constants.Constants.IntegrationTest;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using NSubstitute;

namespace ArchDdd.Tests.Integration.Abstractions.Fixtures;

[CollectionDefinition(ProductControllerCollection)]
public sealed class ProductControllerTestCollection
    : ICollectionFixture<ServiceProviderFixture>
{
}

public sealed class ServiceProviderFixture
{
    public IServiceProvider ServiceProvider { get; }

    public ServiceProviderFixture()
    {
        ServiceProvider = ServiceProviderFactory.ServiceProvider;
    }

    public T GetRequiredService<T>() where T : notnull
    {
        return ServiceProvider.GetRequiredService<T>();
    }
}

public static class ServiceProviderFactory
{
    public static IServiceProvider ServiceProvider { get; }

    static ServiceProviderFactory()
    {
        ServiceProvider = BuildServiceProvider();
    }

    private static IServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();
        var configurations = GetConfiguration();

        services
            .AddTransient(_ => configurations)
            .AddTransient(_ => Substitute.For<IWebHostEnvironment>())
            .RegisterAdapterInfrastructureLayer()
            .RegisterAdapterPersistenceLayer();

        return services.BuildServiceProvider();
    }

    private static IConfiguration GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .AddEnvironmentVariables();

        var path = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
        builder.AddJsonFile(Path.Combine(path, AppsettingsTestJson));

        return builder.Build();
    }
}