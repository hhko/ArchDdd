using ArchDdd.Adapters.Infrastructure.Options;
using ArchDdd.Tests.Integration.Abstractions.Constants;
using ArchDdd.Tests.Integration.Abstractions.Fixtures;
using Microsoft.Extensions.Options;

namespace ArchDdd.Tests.Integration.LayerTests.AdaptersPersistence;

[Collection(CollectionName.ServiceProviderCollection)]
[Trait(nameof(IntegrationTest), IntegrationTest.DatabaseOptions)]
public sealed class DatabaseTests
{
    private readonly ServiceProviderFixture _fixture;

    public DatabaseTests(ServiceProviderFixture serviceProviderFixture)
    {
        _fixture = serviceProviderFixture;
    }

    [Fact]
    public void DatabaseConnection_ShouldSucceed()
    {
        DatabaseOptions databaseOptions = _fixture.GetRequiredService<IOptions<DatabaseOptions>>().Value!;
    }
}