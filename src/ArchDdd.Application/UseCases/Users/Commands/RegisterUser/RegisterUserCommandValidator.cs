using ArchDdd.Application.Abstractions.Utilities;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using FluentValidation;

namespace ArchDdd.Application.UseCases.Users.Commands.RegisterUser;

internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .WithMessage("{PropertyName} is not equal.");

        RuleFor(x => x.Email)
            .MustSatisfyValueObjectValidation(Email.Validate);

        RuleFor(x => x.Username)
            .MustSatisfyValueObjectValidation(Username.Validate);

        RuleFor(x => x.Password)
            .MustSatisfyValueObjectValidation(Password.Validate);
    }
}
