using ArchDdd.Domain.Abstractions.BaseTypes.Contracts;

namespace ArchDdd.Domain.Abstractions.BaseTypes;

public abstract class Entity<TEntityId>
    : IEntity
    where TEntityId : struct, IEntityId<TEntityId>
{
    protected Entity(TEntityId id)
    {
        Id = id;
    }

    protected Entity()
    {
    }

    public TEntityId Id { get; private init; }
}
