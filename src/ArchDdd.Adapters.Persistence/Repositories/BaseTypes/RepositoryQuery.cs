using ArchDdd.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ArchDdd.Adapters.Persistence.Repositories.BaseTypes;

public class RepositoryQuery : IRepositoryQuery
{
    protected readonly ArchDddDbContext DbContext;

    public RepositoryQuery(ArchDddDbContext dbContext)
    {
        DbContext = dbContext;
    }

    protected async Task<IReadOnlyCollection<T>> SqlQueryAsync<T>(FormattableString sql, CancellationToken cancellationToken) where T : class
    {
        return await DbContext.Database
            .SqlQuery<T>(sql)
            .ToListAsync(cancellationToken);
    }

    protected async Task<T?> SqlQuerySingleAsync<T>(FormattableString sql, CancellationToken cancellationToken) 
        where T : class
    {
        // ------------------------------------------------------
        // FirstOrDefaultAsync일 때는 중첩 SELECT가 생성된다.
        // ------------------------------------------------------
        //
        // EFCore ------------------------------------
        // return await DbContext.Database
        //    .SqlQuery<T>(sql)
        //    .FirstOrDefaultAsync(cancellationToken);
        //
        // SQL ---------------------------------------
        // Executed DbCommand(13ms) [
        //    Parameters= [
        //        p0 = 'Lucas'(Size = 5)
        //    ],
        //    CommandType = 'Text',
        //    CommandTimeout = '1'
        // ]
        // SELECT "a"."Email", "a"."Id", "a"."Username"                   <-- 중첩 SELECT
        // FROM(
        //     SELECT "u"."Id", "u"."Username", "u"."Email"
        //         FROM "User" AS "u"
        //         WHERE "u"."Username" = @p0
        //         LIMIT 1
        // ) AS "a"
        // LIMIT 1
        //

        // VS.

        // ------------------------------------------------------
        // ToListAsync일 때는 중첩 SELECT가 생성되지 않는다.
        // ------------------------------------------------------
        //
        // Executed DbCommand(29ms) [
        //  Parameters= [
        //      p0 = 'Lucas'(Size = 5)
        //  ],
        //  CommandType = 'Text',
        //  CommandTimeout = '1']
        //  SELECT "u"."Id", "u"."Username", "u"."Email"
        //      FROM "User" AS "u"
        //      WHERE "u"."Username" = @p0
        //      LIMIT 1
        var x = await DbContext.Database
            .SqlQuery<T>(sql)
            .ToListAsync(cancellationToken);

        return x.Count > 0
            ? x[0]
            : null;
    }
}
