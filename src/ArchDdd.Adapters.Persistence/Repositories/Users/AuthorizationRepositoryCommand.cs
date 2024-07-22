using ArchDdd.Application.UseCases.Users.Commands;
using ArchDdd.Domain.AggregateRoots.Users.Enumerations;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ArchDdd.Adapters.Persistence.Repositories.Users;

internal sealed class AuthorizationRepositoryCommand(
    ArchDddDbContext dbContext)
    : IAuthorizationRepositoryCommand
{
    private readonly ArchDddDbContext _dbContext = dbContext;

    public Task CreatePermissionAsync(Permission permission)
    {
        _dbContext
            .Set<Permission>()
            .Add(permission);

        return Task.CompletedTask;
    }

    public Task DeletePermissionAsync(Permission permission)
    {
        // Exception message:
        //  'The instance of entity type 'Permission' cannot be tracked
        //  because another instance with the same key value for {'Name'} is already being tracked.
        //  When attaching existing entities,
        //  ensure that only one entity instance with a given key value is attached.
        //  Consider using 'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the conflicting key values.'.

       _dbContext
            .Set<Permission>()
            .Remove(permission);

        return Task.CompletedTask;
    }
}
