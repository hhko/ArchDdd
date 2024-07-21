using ArchDdd.Application.Abstractions.CQRS;

namespace ArchDdd.Application.UseCases.Users.Commands.DeletePermission;

public sealed record DeletePermissionCommand(
    string PermissionName)
    : ICommand;