using ArchDdd.Domain.Abstractions.Repositories;
using ArchDdd.Domain.AggregateRoots.Users;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

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
        // - EFCore
        // return await DbContext.Database
        //    .SqlQuery<T>(sql)
        //    .FirstOrDefaultAsync(cancellationToken);           <-- 중첩 SELECT 구문 생성 유도
        //
        // - SQL
        // Executed DbCommand(13ms) [
        //    Parameters= [
        //        p0 = 'Lucas'(Size = 5)
        //    ],
        //    CommandType = 'Text',
        //    CommandTimeout = '1'
        // ]
        // SELECT "a"."Email", "a"."Id", "a"."Username"          <-- 중첩 SELECT
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
        var _ = await DbContext.Database
            .SqlQuery<T>(sql)
            .ToListAsync(cancellationToken);

        return _.Count > 0
            ? _[0]
            : null;
    }

    protected async Task<T> SqlQueryScalarAsync<T>(FormattableString sql, CancellationToken cancellationToken)
        where T : struct
    {
        // ToListAsync vs. SingleOrDefaultAsync
        //
        //  - ToListAsync          : 중첩 SELECT 구문 없음
        //  - SingleOrDefaultAsync : 중첩 SELECT 구문 있음

        // info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        //   Executed DbCommand(35ms) [Parameters= [p0 = '?'(Size = 15)], CommandType = 'Text', CommandTimeout = '1']
        //   SELECT EXISTS(
        //       SELECT 1
        //       FROM User AS u
        //       WHERE u.Email = @p0) as VALUE
        var _ = await DbContext.Database
            .SqlQuery<T>(sql)
            .ToListAsync(cancellationToken);

        return _[0];

        // info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        //   Executed DbCommand(22ms) [Parameters= [p0 = '?'(Size = 15)], CommandType = 'Text', CommandTimeout = '1']
        //   SELECT "t"."Value"                         <-- 중첩 SELECT 구문 생성
        //   FROM(
        //       SELECT EXISTS(
        //           SELECT 1
        //           FROM User AS u
        //           WHERE u.Email = @p0) as VALUE
        //   ) AS "t"
        //   LIMIT 2
        //
        //return await DbContext.Database
        //    .SqlQuery<T>(sql)
        //    .SingleOrDefaultAsync(cancellationToken);
    }
}
