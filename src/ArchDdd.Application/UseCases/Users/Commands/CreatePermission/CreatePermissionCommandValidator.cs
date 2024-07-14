using ArchDdd.Application.UseCases.Users.Commands.RegisterUser;
using FluentValidation;

namespace ArchDdd.Application.UseCases.Users.Commands.CreatePermission;

internal sealed class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
{
    public CreatePermissionCommandValidator()
    {

    }
}
