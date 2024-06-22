using ArchDdd.Tests.Integration.Abstractions.Controllers;
using ArchDdd.Tests.Integration.Abstractions.Fixtures;
using static ArchDdd.Tests.Integration.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Integration.ControllerTests.UserControllers;

[Collection(CollectionName.WebAppFactoryCollectionDefinition)]
[Trait(nameof(IntegrationTest), IntegrationTest.WebApi)]
public sealed partial class UserControllerTests : ControllerTestsBase
{
    public UserControllerTests(WebAppFactoryFixture fixture)
        : base(fixture)
    {

    }
}