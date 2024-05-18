using ArchDdd.Application.Abstractions;
using ArchDdd.Application.UseCases.Users.Commands.RegisterUser;
using ArchDdd.Domain.AggregateRoots.Users;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using ArchDdd.Tests.Unit.Abstractions.Constants;
using Microsoft.AspNetCore.Identity;
using NSubstitute;

namespace ArchDdd.Tests.Unit.LayerTests.Application.Uers;

[Trait(nameof(UnitTest), UnitTest.Application)]
public sealed class RegisterUserTests
{
    [Fact]
    public async Task RegisterUser_IsValid_ShouldBeSuccess()
    {
        // Arrange
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        userRepository
            .IsEmailTakenAsync(Arg.Any<Email>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(false));

        IPasswordHasher<User> passwordHasher = Substitute.For<IPasswordHasher<User>>();
        passwordHasher
            .HashPassword(Arg.Any<User>(), Arg.Any<string>())
            .Returns("AQAAAAIAAYagAAAAEG4tygYdv9yuXah7zgy7Phri32rp0R0Uca9ik5iMjZd5TOyg2VrTcbAAXJlKmxzRrw==");

        IValidator validator = Substitute.For<IValidator>();
        validator
            .IsValid
            .Returns(true);

        var sut = new RegisterUserCommandHandler(userRepository, passwordHasher, validator);

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
