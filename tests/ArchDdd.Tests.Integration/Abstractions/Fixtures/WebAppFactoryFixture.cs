using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using static ArchDdd.Tests.Integration.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Integration.Abstractions.Fixtures;

// WebAppFactoryCollectionDefinition    : CollectionDefinition
//                                         ↓
// WebAppFactoryCollectionFixture       : CollectionFixture
//                                         ↓
// WebAppFactoryFixture                 : Fixture

[CollectionDefinition(CollectionName.WebAppFactoryCollectionDefinition)]
public sealed class WebAppFactoryCollectionFixture
    : ICollectionFixture<WebAppFactoryFixture>
{
}

public sealed class WebAppFactoryFixture
    //: WebApplicationFactory<Program>
    : WebApplicationFactory<IAppMarker>
    , IAsyncLifetime
{
    // 컨테이너

    public async Task InitializeAsync()
    {
        await Task.CompletedTask;
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await Task.CompletedTask;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // ConfigureLogging             // 로그
        // ConfigureAppConfiguration    // IConfiguration
        // ConfigureTestServices        // IServiceCollection

        builder.ConfigureAppConfiguration(context =>
        {
            // appsettings.Test.json
            //  - Content
            //  - PreserveNewest
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile(IntegrationTest.AppsettingsIntegrationJson)
                .AddEnvironmentVariables()
                .Build();

            context.AddConfiguration(configuration);
        });

        builder.ConfigureTestServices(services =>
        {
            // 의존성
        });

        // Environment
        //builder.UseEnvironment("Development");
    }
}
