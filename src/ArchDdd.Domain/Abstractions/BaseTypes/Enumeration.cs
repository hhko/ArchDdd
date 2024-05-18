using ArchDdd.Domain.Abstractions.Exceptions;
using System.Reflection;

namespace ArchDdd.Domain.Abstractions.BaseTypes;

public abstract class Enumeration<TEnum> 
    : IEquatable<Enumeration<TEnum>>
    , IComparable<Enumeration<TEnum>> 
    where TEnum : Enumeration<TEnum>
{
    private static readonly string EnumerationName = typeof(TEnum).Name;
    private static readonly Lazy<Dictionary<int, TEnum>> EnumerationsDictionary =
        new(() => CreateEnumerationDictionary(typeof(TEnum)));

    //
    // 생성 메서드
    //

    protected Enumeration(int id, string name)
        : this()
    {
        Id = id;
        Name = name;
    }

    protected Enumeration()
    {
        Id = default;
        Name = string.Empty;
    }

    public int Id { get; protected init; }

    public string Name { get; protected init; }

    //
    // 비교 메서드 | IEquatable
    //

    public static bool operator ==(Enumeration<TEnum>? enumeration, Enumeration<TEnum>? other)
    {
        if (enumeration is null && other is null)
            return true;

        if (enumeration is null || other is null)
            return false;

        return enumeration.Equals(other);
    }

    public static bool operator !=(Enumeration<TEnum> enumeration, Enumeration<TEnum> other)
    {
        return !(enumeration == other);
    }

    public virtual bool Equals(Enumeration<TEnum>? other)
    {
        if (other is null)
            return false;

        return GetType() == other.GetType() && other.Id.Equals(Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj.GetType() != GetType())
            return false;

        //return obj is Enumeration<TEnum> otherValue && otherValue.Id.Equals(Id);
        if (obj is not Enumeration<TEnum> other)
            return false;

        return ValuesAreEqual(other);
    }

    private bool ValuesAreEqual(Enumeration<TEnum> other)
    {
        return other.Id.Equals(Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() * 37;
    }

    //
    // 비교 메서드 | IComparable
    //

    public int CompareTo(Enumeration<TEnum>? other)
    {
        return other is null
            ? 1
            : Id.CompareTo(other.Id);
    }

    //
    // 비교 메서드 | 포함
    //

    public static bool Contains(int id)
    {
        return EnumerationsDictionary
            .Value
            .ContainsKey(id);
    }

    //
    // 키/값 반환 메서드
    //  - 키: int
    //  - 값: TEnum
    //

    public static IReadOnlyCollection<int> Ids => EnumerationsDictionary.Value
        .Keys           // Dictionary<int, TEnum>: int
        .ToList()
        .AsReadOnly();

    public static IReadOnlyCollection<TEnum> List => EnumerationsDictionary.Value
        .Values         // Dictionary<int, TEnum>: TEnum
        .ToList()
        .AsReadOnly();

    //
    // 값 변환 메서드
    //

    public static TEnum? FromId(int id)
    {
        var isValueInDictionary = EnumerationsDictionary
            .Value
            .TryGetValue(id, out TEnum? enumeration);

        //return isValueInDictionary
        //    ? enumeration
        //    : throw new EnumerationNotFoundException(EnumerationName, id);

        return isValueInDictionary
            ? enumeration
            : default;
    }

    public static TEnum? FromName(string name)
    {
        return EnumerationsDictionary
            .Value      // Dictionary<int, TEnum>
            .Values
            .SingleOrDefault(x => x.Name == name);
    }

    //
    //
    //

    //public static HashSet<string> GetNames()
    //{
    //    return List
    //        .Select(p => p.Name)
    //        .ToHashSet();
    //}

    //
    //
    //

    private static Dictionary<int, TEnum> CreateEnumerationDictionary(Type enumType)
    {
        return GetFieldsForType(enumType)
            .ToDictionary(t => t.Id);
    }

    private static IEnumerable<TEnum> GetFieldsForType(Type enumType)
    {
        return enumType
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fieldInfo => enumType.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo => (TEnum)fieldInfo.GetValue(default)!);
    }
}
