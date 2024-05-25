using ArchDdd.Application.UseCases.Users.Commands.RegisterUser;
using ArchDdd.Tests.Integration.Abstractions.Constants;
using ArchDdd.Tests.Integration.Abstractions.WebApi;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;

namespace ArchDdd.Tests.Integration.ControllersUnderTest.UserControllers;

[Collection(CollectionName.WebAppFactoryCollection)]
[Trait(nameof(IntegrationTest), IntegrationTest.WebApi)]
public sealed class UserControllerTests : ControllerTestsBase
{
    public UserControllerTests(WebAppFactoryFixture fixture)
        : base(fixture)
    {
        
    }

    [Fact]
    public async Task RegisterUserCommand_UsernameIsInvalidate_ShouldBeFalse()
    {
        // System.MissingMethodException:
        // 'Cannot dynamically create an instance of type 'ArchDdd.Application.UseCases.Users.Commands.RegisterUser.RegisterUserCommand'.
        //  Reason: No parameterless constructor defined.'

        // Arrange
        //var registerUserCommandFaker = new Faker<RegisterUserCommand>();
        //registerUserCommandFaker.CustomInstantiator(_ => new RegisterUserCommand(
        //    // "1234567890123456789012345678901", 
        //    Username: _.Random.String2(31),         // 최대 30
        //    Email: _.Random.String(),
        //    Password: _.Random.String(),
        //    ConfirmPassword: _.Random.String()));
        //var registerUserCommand = registerUserCommandFaker.Generate();
        RegisterUserCommand registerUserCommand = new(
            Username: "",                           // Invalid
            Email: "hello@world.com",
            Password: "123456890#aB",
            ConfirmPassword: "123456890#aB");

        HttpResponseMessage actual = await _sut.PostAsJsonAsync(
           "/api/user/register",
           registerUserCommand);

        // Assert
        actual.IsSuccessStatusCode.Should().BeFalse();

        //ProblemDetails problem = await actual.Content.ReadFromJsonAsync<ProblemDetails>();
        string responseContent = await actual.Content.ReadAsStringAsync();
        await VerifyJson(responseContent);
    }
}
