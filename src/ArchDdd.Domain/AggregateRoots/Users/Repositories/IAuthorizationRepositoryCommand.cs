using ArchDdd.Domain.AggregateRoots.Users.Enumerations;

namespace ArchDdd.Domain.AggregateRoots.Users.Repositories;

public interface IAuthorizationRepositoryCommand
{
    Task CreatePermissionAsync(Permission value);
    //Task DeletePermissionAsync(Permission permission);
}
