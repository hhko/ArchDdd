using FluentValidation;

namespace ArchDdd.Application.UseCases.Users.Commands.RegisterUser;

public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        
    }
}
