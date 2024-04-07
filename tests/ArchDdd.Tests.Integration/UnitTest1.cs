using ArchDdd.Adapters.Infrastructure.Options;
using ArchDdd.Tests.Integration.Abstractions.Fixtures;
using static ArchDdd.Tests.Integration.Abstractions.Constants.Constants.CollectionName;
using Microsoft.Extensions.Options;
using static ArchDdd.Tests.Integration.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Integration;

[Collection(ProductControllerCollection)]
[Trait(nameof(IntegrationTest), IntegrationTest.DatabaseOptions)]
public sealed class UnitTest1
{
    private readonly ServiceProviderFixture _fixture;

    public UnitTest1(ServiceProviderFixture serviceProviderFixture)
    {
        _fixture = serviceProviderFixture;
    }

    [Fact]
    public void Test1()
    {
        DatabaseOptions databaseOptions = _fixture.GetRequiredService<IOptions<DatabaseOptions>>().Value!;
    }
}