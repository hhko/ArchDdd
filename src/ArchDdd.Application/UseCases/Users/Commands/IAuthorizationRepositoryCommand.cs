using ArchDdd.Domain.AggregateRoots.Users.Enumerations;

namespace ArchDdd.Application.UseCases.Users.Commands;

public interface IAuthorizationRepositoryCommand
{
    Task CreatePermissionAsync(Permission permission);
    Task DeletePermissionAsync(Permission permission);
}
