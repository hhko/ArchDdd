using ArchDdd.Adapters.Persistence.Repositories.BaseTypes;
using ArchDdd.Domain.AggregateRoots.Users.Enumerations;
using ArchDdd.Domain.AggregateRoots.Users.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ArchDdd.Adapters.Persistence.Repositories.Users;

internal sealed class AuthorizationRepositoryQuery 
    : RepositoryQuery
    , IAuthorizationRepositoryQuery
{
    public AuthorizationRepositoryQuery(ArchDddDbContext dbContext)
        : base(dbContext)
    {
        
    }

    public async Task<Permission?> GetPermissionAsync(PermissionName permission, CancellationToken cancellationToken)
    {
        var permissionName = $"{permission}";

        return await DbContext
            .Set<Permission>()
            .Where(x => x.Name == permissionName)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
