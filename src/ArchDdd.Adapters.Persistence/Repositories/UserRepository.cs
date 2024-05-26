using ArchDdd.Domain.AggregateRoots.Users;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;

namespace ArchDdd.Adapters.Persistence.Repositories;

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
