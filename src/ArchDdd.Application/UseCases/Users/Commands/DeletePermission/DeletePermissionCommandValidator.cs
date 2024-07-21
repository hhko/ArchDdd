using ArchDdd.Application.UseCases.Users.Commands.CreatePermission;
using FluentValidation;

namespace ArchDdd.Application.UseCases.Users.Commands.DeletePermission;

internal sealed class DeletePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
{
    public DeletePermissionCommandValidator()
    {
        
    }
}
