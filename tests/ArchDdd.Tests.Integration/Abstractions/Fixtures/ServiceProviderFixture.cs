using static ArchDdd.Tests.Integration.Abstractions.Constants.Constants.IntegrationTest;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using NSubstitute;
using static ArchDdd.Tests.Integration.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Integration.Abstractions.Fixtures;

// Collection 정의: [CollectionDefinition(ProductControllerCollection)]
// Collection 사용: [Collection(ProductControllerCollection)]
[CollectionDefinition(CollectionName.ServiceProviderFixtureCollection)]
public sealed class ServiceProviderFixtureCollection
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
            .RegisterAdaptersInfrastructureLayer()
            .RegisterAdaptersPersistenceLayer();

        return services.BuildServiceProvider();
    }

    private static IConfiguration GetConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .AddEnvironmentVariables();

        var path = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
        builder.AddJsonFile(Path.Combine(path, AppsettingsIntegrationJson));

        return builder.Build();
    }
}