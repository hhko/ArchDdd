using ArchDdd.Application.Abstractions.CQRS;

namespace ArchDdd.Application.UseCases.Users.Commands.AddPermissionToRole;

public sealed record AddPermissionToRoleCommand(
    string Role,
    string Permission
): ICommand;