using FluentValidation;

namespace ArchDdd.Application.UseCases.Users.Commands.AddPermissionToRole;

internal sealed class AddPermissionToRoleCommandValidator : AbstractValidator<AddPermissionToRoleCommand>
{
    public AddPermissionToRoleCommandValidator()
    {

    }
}
