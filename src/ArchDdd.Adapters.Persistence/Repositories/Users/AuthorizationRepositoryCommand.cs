﻿using ArchDdd.Adapters.Persistence.Repositories.BaseTypes;
using ArchDdd.Domain.AggregateRoots.Users.Enumerations;
using ArchDdd.Domain.AggregateRoots.Users.Repositories;

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
        _dbContext
            .Set<Permission>()
            .Remove(permission);

        return Task.CompletedTask;
    }
}
