using ArchDdd.Domain.Abstractions.BaseTypes.Contracts;

namespace ArchDdd.Domain.Abstractions.BaseTypes;

public abstract record class DomainEvent(Ulid Id) : IDomainEvent;