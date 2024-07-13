using ArchDdd.Application.Abstractions;
using ArchDdd.Application.UseCases.Users.Commands.RegisterUser;
using ArchDdd.Domain.AggregateRoots.Users;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using Microsoft.AspNetCore.Identity;
using NSubstitute;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.LayerTests.Application.Uers;

[Trait(nameof(UnitTest), UnitTest.Application)]
public sealed class RegisterUserTests
{
    [Fact]
    public async Task RegisterUser_IsValid_ShouldBeSuccess()
    {
        // Arrange
        IUserRepositoryCommand userRepositoryCommand = Substitute.For<IUserRepositoryCommand>();
        IUserRepositoryQuery userRepositoryQuery = Substitute.For<IUserRepositoryQuery>();
        userRepositoryQuery
            .IsEmailTakenAsync(Arg.Any<string>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(false));

        IPasswordHasher<User> passwordHasher = Substitute.For<IPasswordHasher<User>>();
        passwordHasher
            .HashPassword(Arg.Any<User>(), Arg.Any<string>())
            .Returns("AQAAAAIAAYagAAAAEG4tygYdv9yuXah7zgy7Phri32rp0R0Uca9ik5iMjZd5TOyg2VrTcbAAXJlKmxzRrw==");

        IValidator validator = Substitute.For<IValidator>();
        validator
            .IsValid
            .Returns(true);

        var sut = new RegisterUserCommandUseCase(
            userRepositoryCommand,
            userRepositoryQuery,
            passwordHasher,
            validator);

        // Act
        var actual = await sut.Handle(
            new RegisterUserCommand(
                "username",
                "hello@world.com",
                "1234567890#aB",
                "1234567890#aB"),
            CancellationToken.None);

        // Assert
        actual.IsSuccess.Should().BeTrue();
    }
}
