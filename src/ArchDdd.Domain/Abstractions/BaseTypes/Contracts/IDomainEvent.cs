using MediatR;

namespace ArchDdd.Domain.Abstractions.BaseTypes.Contracts;

public interface IDomainEvent : INotification
{
    Ulid Id { get; init; }
}
