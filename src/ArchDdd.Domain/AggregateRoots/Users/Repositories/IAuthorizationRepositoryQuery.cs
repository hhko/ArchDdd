using ArchDdd.Domain.AggregateRoots.Users.Enumerations;

namespace ArchDdd.Domain.AggregateRoots.Users.Repositories;

public interface IAuthorizationRepositoryQuery
{
    //Task CreatePermissionAsync(Permission value);
    //Task DeletePermissionAsync(Permission permission);

    Task<T?> GetPermissionAsync<T>(PermissionName permission, CancellationToken cancellationToken) where T : class;
    //Task<HashSet<string>> GetPermissionsAsync(UserId userId);
    //Task<Role?> GetRolePermissionsAsync(RoleName role, CancellationToken cancellationToken);
    //Task<bool> HasPermissionsAsync(UserId userId, PermissionName[] requiredPermissions, LogicalOperation logicalOperation = LogicalOperation.And);
    //Task<bool> HasPermissionToReadAsync(UserId userId, string entity, List<string> requestedProperties);
    //Task<bool> HasRolesAsync(UserId userId, RoleName[] roles);
}
