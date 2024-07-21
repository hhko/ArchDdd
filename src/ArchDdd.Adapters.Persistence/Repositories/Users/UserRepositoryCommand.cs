using ArchDdd.Application.UseCases.Users.Commands;
using ArchDdd.Domain.AggregateRoots.Users;

namespace ArchDdd.Adapters.Persistence.Repositories.Users;

// {
//   "type": "Exception.InvalidOperationException",
//   "title": "ExceptionOccurred",
//   "status": 500,
//   "detail": "Cannot create a DbSet for 'User' because this type is not included in the model for the context.",
//   "instance": "/api/user/register",
//   "errors": null,
//   "RequestId": "0HN3T76J0SHN0:00000001"
// }


// INNER JOIN: 공통된 값을 가진 행들만 반환.
// LEFT  JOIN: 왼쪽 테이블의 모든 행과 오른쪽 테이블의 일치하는 행들.
// RIGHT JOIN: 오른쪽 테이블의 모든 행과 왼쪽 테이블의 일치하는 행들 (SQLite는 직접 지원하지 않음).
// FULL  JOIN: 양쪽 테이블의 모든 행을 반환(SQLite는 직접 지원하지 않음).
// CROSS JOIN: 두 테이블 간의 모든 행의 조합.
// SELF  JOIN: 동일한 테이블 내의 행들 간의 조인.

internal sealed class UserRepositoryCommand
    : IUserRepositoryCommand
{
    private readonly ArchDddDbContext _dbContext;

    public UserRepositoryCommand(ArchDddDbContext dbContext)
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
}
