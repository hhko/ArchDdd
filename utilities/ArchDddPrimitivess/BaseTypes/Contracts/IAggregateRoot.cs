namespace ArchDddPrimitivess.BaseTypes.Contracts;

public interface IAggregateRoot : IEntity
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}
