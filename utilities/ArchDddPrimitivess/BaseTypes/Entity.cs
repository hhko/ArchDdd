using ArchDddPrimitivess.BaseTypes.Contracts;

namespace ArchDddPrimitivess.BaseTypes;

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
