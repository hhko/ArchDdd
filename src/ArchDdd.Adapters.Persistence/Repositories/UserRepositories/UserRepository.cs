using ArchDdd.Domain.AggregateRoots.Users;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

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
        return await Task.FromResult(false);
    }

    public async Task<User?> GetByUsernameAsync(Username username, CancellationToken cancellationToken)
    {
        return await Task.FromResult(User.Create(
            UserId.New(),
            username,
            Email.Create("hello@world.com").Value));
    }
}
