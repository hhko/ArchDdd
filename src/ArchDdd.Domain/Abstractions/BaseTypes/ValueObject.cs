using PrimitiveUtilities;
using System.Linq;

namespace ArchDdd.Domain.Abstractions.BaseTypes;

[Serializable]
public abstract class ValueObject : IEquatable<ValueObject>
{
    public const string Value = nameof(Value);

    public abstract IEnumerable<object> GetAtomicValues();

    //
    // 생성 메서드
    //  - Create
    //  - Validate

    //
    // 비교 메서드 | IEquatable
    //

    public static bool operator ==(ValueObject? valueObject, ValueObject? other)
    {
        if (valueObject is null && other is null)
            return true;

        if (valueObject is null || other is null)
            return false;

        return valueObject.Equals(other);
    }

    public static bool operator !=(ValueObject? valueObject, ValueObject? other)
    {
        return !(valueObject == other);
    }

    public bool Equals(ValueObject? other)
    {
        //return other is not null && ValuesAreEqual(other);

        if (other is null)
            return false;

        return ValuesAreEqual(other);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj.GetType() != GetType())
            return false;

        if (obj is not ValueObject other)
            return false;

        return ValuesAreEqual(other);
    }

    private bool ValuesAreEqual(ValueObject other)
    {
        return GetAtomicValues()
            .SequenceEqual(other.GetAtomicValues());
    }

    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Aggregate(default(int), (hashcode, value) => HashCode.Combine(hashcode, value.GetHashCode()));
    }

    //
    // string 반환 메서드
    //

    public override string ToString()
    {
        return GetAtomicValues()
            .Join(", ");
    }

    //
    // 기본 메서드
    //
}
