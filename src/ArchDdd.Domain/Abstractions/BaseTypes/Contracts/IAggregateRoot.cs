namespace ArchDdd.Domain.Abstractions.BaseTypes.Contracts;

public interface IAggregateRoot : IEntity
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}
