using ArchDdd.Domain.Abstractions.BaseTypes;

namespace ArchDdd.Domain.AggregateRoots.Users.Events;

public sealed record class UserRegisteredDomainEvent(Ulid Id, UserId UserId) : DomainEvent(Id)
{
    public static UserRegisteredDomainEvent New(UserId userId)
    {
        return new UserRegisteredDomainEvent(Ulid.NewUlid(), userId);
    }
}