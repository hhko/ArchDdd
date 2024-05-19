using ArchDddPrimitivess.BaseTypes.Contracts;

namespace ArchDddPrimitivess.BaseTypes;

public abstract record class DomainEvent(Ulid Id) : IDomainEvent;