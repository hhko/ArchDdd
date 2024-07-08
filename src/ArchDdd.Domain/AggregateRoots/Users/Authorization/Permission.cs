using ArchDdd.Domain.Abstractions.Results;
using static PrimitiveUtilities.ListUtilities;

namespace ArchDdd.Domain.AggregateRoots.Users.Authorization;

//public sealed class Permission : Enumeration<Permission>
//{
//    private const char floor = '_';

//    public static readonly Permission Review_Read = new(1, nameof(Review_Read));
//    public static readonly Permission Review_Add = new(2, nameof(Review_Add));
//    public static readonly Permission Review_Update = new(3, nameof(Review_Update));
//    public static readonly Permission Review_Remove = new(4, nameof(Review_Remove));
//    public static readonly Permission INVALID_PERMISSION = new(5, nameof(INVALID_PERMISSION));

//    public Permission(int id, string name)
//        : base(id, name)
//    {
//        if (name.NotContains(floor))
//        {
//            throw new ArgumentException($"Permission must contain {floor}.");
//        }
//    }

//    //// Empty constructor in this case is required by EF Core
//    //private Permission()
//    //{
//    //}
//}

public enum PermissionType
{
    Other = 0,
    Add = 1,
    Update = 2,
    Remove = 3,
    Delete = 4,
    Read = 5,
}

// C: Add
// R: Read
// U: Update
// D: Delete, Remove
// -: Other

public sealed partial class Permission
{
    private const char _floor = '_';
    public static Permission INVALID_PERMISSION = new(nameof(INVALID_PERMISSION)) //Test purposes
    {
        Type = PermissionType.Other
    };

    public string Name { get; init; }
    public PermissionType Type { get; init; } = PermissionType.Other;
    public string? RelatedAggregateRoot { get; init; }
    public string? RelatedEntity { get; init; }
    public List<string>? Properties { get; init; } = null;

    private Permission(string name)
    {
        Name = name;
    }

    public static Result<Permission> CreatePermission
    (
        string name,
        string relatedAggregateRoot,
        string relatedEntity,
        string permissionTypeAsString,
        List<string>? allowedProperties = null
    )
    {
        var parsePermissionTypeResult = Enum.TryParse<PermissionType>(permissionTypeAsString, out var permissionType);

        //var errors = Validate(name, relatedAggregateRoot, relatedEntity, parsePermissionTypeResult, permissionTypeAsString, allowedProperties);

        //if (errors.NotNullOrEmpty())
        //{
        //    return ValidationResult<Permission>.WithErrors([.. errors]);
        //}

        return new Permission(name)
        {
            RelatedAggregateRoot = relatedAggregateRoot,
            RelatedEntity = relatedEntity,
            Type = permissionType,
            Properties = allowedProperties
        };
    }

    //public static IList<Error> Validate(
    //    string name,
    //    string relatedAggregateRoot,
    //    string relatedEntity,
    //    bool parsePermissionTypeResult,
    //    string permissionTypeAsString,
    //    List<string>? allowedProperties = null)
    //{

    //    return EmptyList<Error>()
    //        .If(name.NotContains(_floor), Error.InvalidArgument($"Permission must contain '{_floor}'."))
    //        .If(parsePermissionTypeResult is false, Error.InvalidArgument($"{permissionTypeAsString} is not a valid PermissionType. Valid PermissionTypes: {string.Join(", ", PermissionType.Other.GetEnumNames())}"))
    //        .If(IsAggregateRoot(relatedAggregateRoot) is false, Error.InvalidArgument($"{relatedAggregateRoot} is not a valid RelatedAggregateRoot"))
    //        .If(IsEntity(relatedEntity) is false, Error.InvalidArgument($"{relatedEntity} is not a valid Entity"))
    //        .If(IsEntity(relatedEntity) && ReatedEntityPropertiesAreInvalid(relatedEntity, allowedProperties), Error.InvalidArgument($"{relatedEntity} is not a valid Entity"));
    //}
}