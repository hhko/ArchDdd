﻿using ArchDdd.Domain.Abstractions.BaseTypes.Contracts;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
//using static Microsoft.EntityFrameworkCore.EntityState;

namespace ArchDdd.Adapters.Persistence.Repositories.BaseTypes;

//UnitOfWork class to handler transactions
//Benefits:
//1. We do not want to pollute the application layer with entity framework
//2. We do not expose any implementation details when we inject IUnitOfWork interface
//   a) since we use the repository pattern with UnitOfWork, the repositories do not contain SaveChanges method.
//      This force us to call SaveChanges at the end of our business transactions from the UnitOfWork.
//      So this removes the responsibility of SavingChanges from the repositories and moves it to the UnitOfWork
//   b) since we use IUnitOfWork interface we can provide a mock for this interface
//3. Move the logic from the interceptors to the UnitOfWork
//public sealed class UnitOfWork<TContext>
//(
//    TContext dbContext,
//    IUserContextService userContext,
//    IOutboxRepository outboxRepository,
//    IFusionCache fusionCache
//)
//    : IUnitOfWork<TContext>
//        where TContext : DbContext
//{
//    private const string DefaultUsername = "Unknown";
//    private readonly TContext _dbContext = dbContext;
//    private readonly IUserContextService _userContext = userContext;
//    private readonly IOutboxRepository _outboxRepository = outboxRepository;
//    private readonly IFusionCache _fusionCache = fusionCache;

public sealed class UnitOfWork<TContext>
    : IUnitOfWork<TContext>
    where TContext : DbContext
{
    //private const string DefaultUsername = "Unknown";
    private readonly TContext _dbContext;

    public TContext Context => _dbContext;

    public UnitOfWork(TContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
    {
        return Context
            .Database
            .BeginTransactionAsync(cancellationToken);
    }

    public IExecutionStrategy CreateExecutionStrategy()
    {
        return Context
            .Database
            .CreateExecutionStrategy();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        //_outboxRepository.PersistOutboxMessagesFromDomainEvents();

        UpdateAuditableEntities();
        //UpdateCache();

        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditableEntities()
    {
        IEnumerable<EntityEntry<IAuditable>> entries =
            _dbContext
                .ChangeTracker
                .Entries<IAuditable>()
                .Where(entry => entry.State is EntityState.Added or EntityState.Modified);

        foreach (EntityEntry<IAuditable> entityEntry in entries)
        {
            if (entityEntry.State is EntityState.Added)
            {
                entityEntry.Property(a => a.CreatedOn).CurrentValue = DateTimeOffset.UtcNow;
                //entityEntry.Property(a => a.CreatedBy).CurrentValue ??= _userContext.Username ?? DefaultUsername;
            }

            if (entityEntry.State is EntityState.Modified)
            {
                entityEntry.Property(a => a.UpdatedOn).CurrentValue = DateTimeOffset.UtcNow;
                //entityEntry.Property(a => a.UpdatedBy).CurrentValue = _userContext.Username ?? DefaultUsername;
            }
        }
    }

    //private void UpdateCache()
    //{
    //    IEnumerable<EntityEntry<IAggregateRoot>> entries =
    //        _dbContext
    //            .ChangeTracker
    //            .Entries<IAggregateRoot>()
    //            .Where(entity => entity.State is Deleted);

    //    foreach (var entityEntry in entries)
    //    {
    //        var entityId = entityEntry.Entity.GetEntityIdFromEntity();

    //        if (entityEntry.State is Deleted)
    //        {
    //            _fusionCache.Remove(entityId);
    //        }
    //    }
    //}
}