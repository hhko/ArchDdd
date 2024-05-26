using ArchDdd.Tests.Integration.Abstractions.Constants;
using ArchDdd.Tests.Integration.Abstractions.WebApi;

namespace ArchDdd.Tests.Integration.ControllersUnderTest.UserControllers;

[Collection(CollectionName.WebAppFactoryCollection)]
[Trait(nameof(IntegrationTest), IntegrationTest.WebApi)]
public sealed partial class UserControllerTests : ControllerTestsBase
{
    public UserControllerTests(WebAppFactoryFixture fixture)
        : base(fixture)
    {

    }
}