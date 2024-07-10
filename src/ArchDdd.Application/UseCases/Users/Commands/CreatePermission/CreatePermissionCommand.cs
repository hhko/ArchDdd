using ArchDdd.Application.Abstractions.CQRS;

namespace ArchDdd.Application.UseCases.Users.Commands.CreatePermission;

public sealed record CreatePermissionCommand(
    string PermissionName,
    string RelatedAggregateRoot,
    string RelatedEntity,
    string PermissionType,
    List<string>? AllowedProperties
) : ICommand;
