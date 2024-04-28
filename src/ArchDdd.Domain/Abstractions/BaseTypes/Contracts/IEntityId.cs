using System.ComponentModel;

namespace ArchDdd.Domain.Abstractions.BaseTypes.Contracts;

public interface IEntityId : IComparable<IEntityId>
{
    const string Id = nameof(Id);
    Ulid Value { get; }

    static bool operator >(IEntityId a, IEntityId b) => a.CompareTo(b) is 1;
    static bool operator <(IEntityId a, IEntityId b) => a.CompareTo(b) is -1;
    static bool operator >=(IEntityId a, IEntityId b) => a.CompareTo(b) >= 0;
    static bool operator <=(IEntityId a, IEntityId b) => a.CompareTo(b) <= 0;
}

//[TypeConverter(typeof(EntityIdConverter))]
public interface IEntityId<TEntityId> : IEntityId
{
    abstract static TEntityId Create(Ulid id);

    abstract static TEntityId New();
}