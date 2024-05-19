using MediatR;

namespace ArchDddPrimitivess.BaseTypes.Contracts;

public interface IDomainEvent : INotification
{
    Ulid Id { get; init; }
}
