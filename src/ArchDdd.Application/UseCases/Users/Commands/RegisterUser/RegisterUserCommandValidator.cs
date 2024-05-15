using FluentValidation;

namespace ArchDdd.Application.UseCases.Users.Commands.RegisterUser;

internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        
    }
}
