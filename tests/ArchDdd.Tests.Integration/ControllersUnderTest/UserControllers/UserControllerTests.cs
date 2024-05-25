using ArchDdd.Application.UseCases.Users.Commands.RegisterUser;
using ArchDdd.Tests.Integration.Abstractions.Constants;
using ArchDdd.Tests.Integration.Abstractions.WebApi;
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

        string responseContent = await actual.Content.ReadAsStringAsync();
        //ExceptionResponse exceptionResponse = JsonConvert.DeserializeObject<ExceptionResponse>(responseContent);
        //return exceptionResponse;

        //await Verify(responseContent);
    }

    //    {
    //      "type":"ValidationError",
    //      "title":"ValidationError",
    //      "status":400,
    //      "detail":"A validation problem occurred.",
    //      "errors":[
    //        {
    //            "code":"DomainErrors.Username.Empty",
    //            "message":"Username name is empty."
    //        }
    //      ]
    //    }


    //[Fact]
    //public async Task Hello1()
    //{
    //    // Act
    //    HttpResponseMessage actual = await _sut.PostAsJsonAsync(
    //        "/api/user/register", 
    //        new RegisterUserCommand("x1", "x2", "x3", "x4444"));

    //    // Assert

    //    RegisterUserResponse? response = await actual.Content.ReadFromJsonAsync<RegisterUserResponse>();

    //    actual.StatusCode.Should().Be(HttpStatusCode.OK);

    //    //await Verify(response!);
    //}

    //public class Person
    //{
    //    public Guid Id { get; set; }
    //    public string Title { get; set; }
    //}

    //[Fact]
    //public async Task Hello2()
    //{
    //    var person = new Person()
    //    {
    //        Id = new("ebced679-45d3-4653-8791-3d969c4a986c"),
    //        Title = "Title.Mr",
    //    };

    //    await Verify(person);
    //}
}
