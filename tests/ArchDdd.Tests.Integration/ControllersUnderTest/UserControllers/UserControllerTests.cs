using ArchDdd.Application.UseCases.Users.Commands.RegisterUser;
using ArchDdd.Tests.Integration.Abstractions.Constants;
using ArchDdd.Tests.Integration.Abstractions.WebApi;
using Microsoft.AspNetCore.Http;
using System.Net;
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
    public async Task Hello1()
    {
        // Act
        HttpResponseMessage actual = await _sut.PostAsJsonAsync(
            "/api/user/register", 
            new RegisterUserCommand("x1", "x2", "x3", "x4444"));

        // Assert

        RegisterUserResponse? response = await actual.Content.ReadFromJsonAsync<RegisterUserResponse>();

        actual.StatusCode.Should().Be(HttpStatusCode.OK);

        //await Verify(response!);
    }

    public class Person
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }

    [Fact]
    public async Task Hello2()
    {
        var person = new Person()
        {
            Id = new("ebced679-45d3-4653-8791-3d969c4a986c"),
            Title = "Title.Mr",
        };

        await Verify(person);
    }
}
