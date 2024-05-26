using ArchDdd.Tests.Integration.Abstractions.WebApi;
using static ArchDdd.Tests.Integration.Abstractions.Constants.Constants;

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