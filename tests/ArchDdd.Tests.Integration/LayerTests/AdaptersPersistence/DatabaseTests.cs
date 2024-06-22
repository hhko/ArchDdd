using ArchDdd.Adapters.Persistence.Options.Database;
using ArchDdd.Tests.Integration.Abstractions.Fixtures;
using Microsoft.Extensions.Options;
using static ArchDdd.Tests.Integration.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Integration.LayerTests.AdaptersPersistence;

[Collection(CollectionName.ServiceProviderCollectionDefinition)]
[Trait(nameof(IntegrationTest), IntegrationTest.DatabaseOptions)]
public sealed class DatabaseTests
{
    private readonly ServiceProviderFixture _fixture;

    public DatabaseTests(ServiceProviderFixture serviceProviderFixture)
    {
        _fixture = serviceProviderFixture;
    }

    //[Fact]
    //public void DatabaseConnection_ShouldSucceed()
    //{
    //    DatabaseOptions databaseOptions = _fixture.GetRequiredService<IOptions<DatabaseOptions>>().Value!;
    //}
}