using ArchDdd.Domain.Abstractions.BaseTypes.Contracts;

namespace ArchDdd.Domain.AggregateRoots.Users;

public readonly record struct UserId
    : IEntityId<UserId>
{
    public UserId(Ulid id)
    {
        Value = id;
    }

    public Ulid Value { get; }

    public static UserId Create(Ulid id)
    {
        return new UserId(id);
    }

    public static UserId New()
    {
        return new UserId(Ulid.NewUlid());
    }

    //
    //
    //

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    //
    // 비교 메서드 | IComparable
    //

    public int CompareTo(IEntityId? other)
    {
        if (other is null)
            return 1;

        if (other is not UserId otherUserId)
            throw new ArgumentNullException($"IEntity is not {GetType().FullName}");

        return Value.CompareTo(otherUserId.Value);
    }

    public static bool operator >(UserId a, UserId b) => a.CompareTo(b) is 1;
    public static bool operator <(UserId a, UserId b) => a.CompareTo(b) is -1;
    public static bool operator >=(UserId a, UserId b) => a.CompareTo(b) >= 0;
    public static bool operator <=(UserId a, UserId b) => a.CompareTo(b) <= 0;
}
