using ArchDdd.Adapters.Persistence.Repositories.BaseTypes;
using ArchDdd.Domain.AggregateRoots.Users.Enumerations;
using ArchDdd.Domain.AggregateRoots.Users.Repositories;

namespace ArchDdd.Adapters.Persistence.Repositories.Users;

internal sealed class AuthorizationRepositoryQuery
    : RepositoryQuery
    , IAuthorizationRepositoryQuery
{
    public AuthorizationRepositoryQuery(ArchDddDbContext dbContext)
        : base(dbContext)
    {

    }

    public async Task<T?> GetPermissionAsync<T>(PermissionName permission, CancellationToken cancellationToken)
        where T : class
    {
        //return await DbContext
        //    .Set<Permission>()
        //    .Where(x => x.Name == permissionName)
        //    .FirstOrDefaultAsync(cancellationToken);
        return await SqlQuerySingleAsync<T>(
            $"""
            SELECT "p"."Name", "p"."Properties", "p"."RelatedAggregateRoot", "p"."RelatedEntity", "p"."Type"
            FROM "Permission" AS "p"
            WHERE "p"."Name" = {permission}
            LIMIT 1
            """,
            cancellationToken);
    }
}
