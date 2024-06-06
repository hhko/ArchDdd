using ArchDdd.Application.UseCases.Users.Queries.GetUserByUsername;
using ArchDdd.Domain.AggregateRoots.Users;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ArchDdd.Adapters.Persistence.Repositories.UserRepositories;

// {
//   "type": "Exception.InvalidOperationException",
//   "title": "ExceptionOccurred",
//   "status": 500,
//   "detail": "Cannot create a DbSet for 'User' because this type is not included in the model for the context.",
//   "instance": "/api/user/register",
//   "errors": null,
//   "RequestId": "0HN3T76J0SHN0:00000001"
// }

public class UserRepository : IUserRepository
{
    private readonly ArchDddDbContext _dbContext;

    public UserRepository(ArchDddDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext
            .Set<User>()
            .Add(user);

        // info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        //    Executed DbCommand(16ms)
        //    [Parameters= [
        //        @p0 = '01HZ8JV1NG0YKDBE2YG81K099G'(Nullable = false)(Size = 26), 
        //        @p1 = '2024-06-01T00:22:53.2442080+00:00', 
        //        @p2 = 'lucas@fun.com'(Nullable = false)(Size = 13), 
        //        @p3 = 'AQAAAAIAAYagAAAAEFZjoVVx0WkTNXReZo347Th1IVgBEPFam8ZMGgTaUn9eL96wPSGBmiBizk3EeBBrgg=='(Nullable = false)(Size = 84), 
        //        @p4 = NULL(DbType = DateTimeOffset), 
        //        @p5 = 'Lucas'(Nullable = false)(Size = 5)], 
        //        CommandType = 'Text', CommandTimeout = '2'
        //    ]
        //    INSERT INTO "User"("Id", "CreatedOn", "Email", "PasswordHash", "UpdatedOn", "Username")
        //    VALUES(@p0, @p1, @p2, @p3, @p4, @p5);
    }

    public void Update(User user)
    {
    }

    public async Task<bool> IsEmailTakenAsync(Email email, CancellationToken cancellationToken)
    {
        // info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        //       Executed DbCommand (8ms)
        //       [Parameters=[
        //          @__email_0='lucas@fun.com' (Size = 13)],
        //          CommandType='Text', CommandTimeout='1'
        //       ]
        //       SELECT EXISTS (
        //           SELECT 1
        //           FROM "User" AS "u"
        //           WHERE "u"."Email" = @__email_0)

        return await _dbContext
           .Set<User>()
           .Where(user => user.Email == email)
           .AnyAsync(cancellationToken);
    }

    public async Task<User?> GetByUsernameAsync(Username username, CancellationToken cancellationToken)
    {
        // info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        //      Executed DbCommand(41ms)
        //      [Parameters= [
        //          @__username_0 = 'Lucas'(Size = 5)],
        //          CommandType = 'Text',
        //          CommandTimeout = '1'
        //      ]
        //      SELECT "u"."Id", "u"."CreatedOn", "u"."Email", "u"."PasswordHash", "u"."UpdatedOn", "u"."Username"
        //      FROM "User" AS "u"
        //      WHERE "u"."Username" = @__username_0
        //      LIMIT 1

        return await _dbContext
            .Set<User>()
            //.Include(user => user.Roles)
            //    .ThenInclude(role => role.Permissions)
            .Where(user => user.Username == username)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<T>> SqlQueryAsync<T>(FormattableString sql, CancellationToken cancellationToken) where T : class
    {
        return await _dbContext.Database
            .SqlQuery<T>(sql)
            .ToListAsync(cancellationToken);
    }

    public async Task<T?> SqlQuerySingleAsync<T>(FormattableString sql, CancellationToken cancellationToken) where T : class
    {
        return await _dbContext.Database
            .SqlQuery<T>(sql)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> SqlQuerySingleAsync(FormattableString sql, CancellationToken cancellationToken)
    {
        return await _dbContext.Database
            .SqlQuery<bool>(sql)
            .AnyAsync(cancellationToken);
    }
}
