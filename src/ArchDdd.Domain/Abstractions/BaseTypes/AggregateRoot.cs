using ArchDdd.Domain.Abstractions.BaseTypes.Contracts;

namespace ArchDdd.Domain.Abstractions.BaseTypes;

public abstract class AggregateRoot<TEntityId> 
    : Entity<TEntityId>
    , IAggregateRoot
    where TEntityId : struct
        , IEntityId<TEntityId>
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected AggregateRoot(TEntityId id)
        : base(id)
    {
    }

    protected AggregateRoot()
    {
    }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
