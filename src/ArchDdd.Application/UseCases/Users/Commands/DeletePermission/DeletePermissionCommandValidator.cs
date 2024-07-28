using ArchDdd.Application.Abstractions.Utilities;
using ArchDdd.Application.UseCases.Users.Commands.CreatePermission;
using ArchDdd.Domain.AggregateRoots.Users.Enumerations;
using FluentValidation;

namespace ArchDdd.Application.UseCases.Users.Commands.DeletePermission;

internal sealed class DeletePermissionCommandValidator : AbstractValidator<DeletePermissionCommand>
{
    public DeletePermissionCommandValidator()
    {
        RuleFor(x => x.PermissionName)
            .MustBeAnEnum<DeletePermissionCommand, PermissionName>();
    }
}
