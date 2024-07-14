using ArchDdd.Adapters.Persistence.Repositories.BaseTypes;
using ArchDdd.Domain.AggregateRoots.Users;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ArchDdd.Adapters.Persistence.Repositories.UserRepositories;

internal class UserRepositoryQuery 
    : RepositoryQuery
    , IUserRepositoryQuery
{
    public UserRepositoryQuery(ArchDddDbContext dbContext)
        : base(dbContext)
    {
        
    }

    public async Task<T?> GetByUsernameAsync<T>(string username, CancellationToken cancellationToken)
        where T : class
    {
        return await SqlQuerySingleAsync<T>(
            $"""
            SELECT u.Id, u.Username, u.Email
            FROM User AS u
            WHERE u.Username = {username}
            LIMIT 1
            """,
            cancellationToken);
    }

    //public async Task<User?> GetByUsernameAsync(Username username, CancellationToken cancellationToken)
    //{
    //    // info: Microsoft.EntityFrameworkCore.Database.Command[20101]
    //    //      Executed DbCommand(41ms)
    //    //      [Parameters= [
    //    //          @__username_0 = 'Lucas'(Size = 5)],
    //    //          CommandType = 'Text',
    //    //          CommandTimeout = '1'
    //    //      ]
    //    //      SELECT "u"."Id", "u"."CreatedOn", "u"."Email", "u"."PasswordHash", "u"."UpdatedOn", "u"."Username"
    //    //      FROM "User" AS "u"
    //    //      WHERE "u"."Username" = @__username_0
    //    //      LIMIT 1

    //    return await DbContext
    //        .Set<User>()
    //        //.Include(user => user.Roles)
    //        //    .ThenInclude(role => role.Permissions)
    //        .Where(user => user.Username == username)
    //        .FirstOrDefaultAsync(cancellationToken);
    //}

    public async Task<bool> IsEmailTakenAsync(string email, CancellationToken cancellationToken)
    {
        // no such column: t.Value
        return await SqlQueryScalarAsync<bool>($"""
            SELECT EXISTS (
                SELECT 1
                FROM User AS u
                WHERE u.Email = {email}) as VALUE
            """, cancellationToken);
    }

    //public async Task<bool> (Email email, CancellationToken cancellationToken)
    //{
    //    // info: Microsoft.EntityFrameworkCore.Database.Command[20101]
    //    //       Executed DbCommand (8ms)
    //    //       [Parameters=[
    //    //          @__email_0='lucas@fun.com' (Size = 13)],
    //    //          CommandType='Text', CommandTimeout='1'
    //    //       ]
    //    //       SELECT EXISTS (
    //    //           SELECT 1
    //    //           FROM "User" AS "u"
    //    //           WHERE "u"."Email" = @__email_0)

    //    return await DbContext
    //       .Set<User>()
    //       .Where(user => user.Email == email)
    //       .AnyAsync(cancellationToken);
    //}
}
