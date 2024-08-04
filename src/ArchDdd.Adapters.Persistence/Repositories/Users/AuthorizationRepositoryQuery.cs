using ArchDdd.Adapters.Persistence.Repositories.BaseTypes;
using ArchDdd.Application.UseCases.Users.Queries;
using ArchDdd.Domain.AggregateRoots.Users.Enumerations;

namespace ArchDdd.Adapters.Persistence.Repositories.Users;

internal sealed class AuthorizationRepositoryQuery
    : RepositoryQuery
    , IAuthorizationRepositoryQuery
{
    public AuthorizationRepositoryQuery(ArchDddDbContext dbContext)
        : base(dbContext)
    {

    }

    public async Task<T?> GetPermissionAsync<T>(PermissionName permissionName, CancellationToken cancellationToken)
        where T : class
    {
        var paramPermissionName = $"{permissionName}";

        // 1. "객체 -> string"으로 명시적 변환이 필요합니다.
        // 2. Parameters 세부 값을 확인할 수 있습니다.
        //      optionsBuilder.EnableSensitiveDataLogging();
        //      Executed DbCommand(13ms) [Parameters= [p0 = 'OrderHeader_Read_Customer'(Size = 25)], ... ]}

        // Case 1. "객체 -> string" 변환 후 일 때
        //
        // var paramPermissionName = $"{permissionName}";
        // {paramPermissionName} 
        //      --> [p0 = 'OrderHeader_Read_Customer'(Size = 25)]
        //
        // Executed DbCommand(13ms) [Parameters= [p0 = 'OrderHeader_Read_Customer'(Size = 25)], CommandType = 'Text', CommandTimeout = '1']
        // SELECT "p"."Name", "p"."Properties", "p"."RelatedAggregateRoot", "p"."RelatedEntity", "p"."Type"
        // FROM "Permission" AS "p"
        // WHERE "p"."Name" = @p0

        // Case 2. "객체"일 때
        //
        // {permissionName}
        //      --> [p0 = '8']
        //
        // Executed DbCommand(6ms) [Parameters= [p0 = '8'], CommandType = 'Text', CommandTimeout = '1']
        // SELECT "p"."Name", "p"."Properties", "p"."RelatedAggregateRoot", "p"."RelatedEntity", "p"."Type"
        // FROM "Permission" AS "p"
        // WHERE "p"."Name" = @p0

        return await SqlQuerySingleAsync<T>(
            $"""
            SELECT "p"."Name", "p"."Properties", "p"."RelatedAggregateRoot", "p"."RelatedEntity", "p"."Type"
            FROM "Permission" AS "p"
            WHERE "p"."Name" = {paramPermissionName}
            """,
            cancellationToken);
        
    }
}
