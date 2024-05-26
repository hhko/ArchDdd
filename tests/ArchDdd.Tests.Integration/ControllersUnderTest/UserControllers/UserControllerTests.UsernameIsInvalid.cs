using ArchDdd.Application.UseCases.Users.Commands.RegisterUser;
using ArchDdd.Tests.Integration.Abstractions.WebApi;
using System.Collections;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace ArchDdd.Tests.Integration.ControllersUnderTest.UserControllers;

public sealed partial class UserControllerTests
{
    [Theory]
    [ClassData(typeof(InvalidData))]
    public async Task UsernameIsInvalid_ShouldBeFalse(Dictionary<string, RegisterUserCommand> arg)
    {
        // Arrange
        HttpResponseMessage actual = await _sut.PostAsJsonAsync(
            "/api/user/register",
            arg.Values.First());

        // Assert
        actual.IsSuccessStatusCode.Should().BeFalse();

        string responseContent = await actual.Content.ReadAsStringAsync();
        await VerifyJson(responseContent)
            .UseParameters(arg.Keys.First());
    }

    //private Task VerifyWithMethodName(object target, [CallerMemberName] string? methodName = default)
    //{
    //    var settings = new VerifySettings();
    //    settings.UseFileName(methodName!);

    //    return Verifier.Verify(target, settings);
    //}

    private class InvalidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Dictionary<string, RegisterUserCommand> {
            {
                "Empty",
                new RegisterUserCommand(
                    Username: "",                                   // Invalid: Emtpy
                    Email: "hello@world.com",
                    Password: "123456890#aB",
                    ConfirmPassword: "123456890#aB")
            } } };
            yield return new object[] { new Dictionary<string, RegisterUserCommand> {
            {
                "TooLong",
                new RegisterUserCommand(
                    Username: "1234567890123456789012345678901",    // Invalid: TooLong > 30
                    Email: "hello@world.com",
                    Password: "123456890#aB",
                    ConfirmPassword: "123456890#aB")
            } } };
            yield return new object[] { new Dictionary<string, RegisterUserCommand> {
            {
                "ContainsIllegalCharacter",
                new RegisterUserCommand(
                    Username: "#",                                  // Invalid: ContainsIllegalCharacter
                    Email: "hello@world.com",
                    Password: "123456890#aB",
                    ConfirmPassword: "123456890#aB")
            } } };
            yield return new object[] { new Dictionary<string, RegisterUserCommand> {
            {
                "TooLong_ContainsIllegalCharacter",
                new RegisterUserCommand(
                    Username: "1234567890123456789012345678901#",   // Invalid: TooLong + ContainsIllegalCharacter
                    Email: "hello@world.com",
                    Password: "123456890#aB",
                    ConfirmPassword: "123456890#aB")
            } } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}