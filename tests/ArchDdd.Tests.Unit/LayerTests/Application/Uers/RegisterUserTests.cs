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
    public async Task Test()
    {
        // Arrange
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        userRepository
            .IsEmailTakenAsync(Arg.Any<Email>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(false));

        IValidator validator = Substitute.For<IValidator>();
        validator.IsValid.Returns(true);

        IPasswordHasher<User> passwordHasher = Substitute.For<IPasswordHasher<User>>();
        
        RegisterUserCommandHandler sut = new(userRepository, validator, passwordHasher);

        //// Act
        //var actual = await sut.Handle(
        //    new RegisterUserCommand(
        //        "username",
        //        "hello@world.com",
        //        "1234567890#aB",
        //        "1234567890#aB"), 
        //    CancellationToken.None);
    }
}
