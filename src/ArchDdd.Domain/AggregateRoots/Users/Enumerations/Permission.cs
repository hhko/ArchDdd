using ArchDdd.Domain.Abstractions.Results;
using PrimitiveUtilities;
using static PrimitiveUtilities.ListUtilities;

namespace ArchDdd.Domain.AggregateRoots.Users.Enumerations;

public enum PermissionType
{
    Other = 0,
    Add = 1,
    Update = 2,
    Remove = 3,
    Delete = 4,
    Read = 5,
}

// _: Other
// C: Add
// R: Read
// U: Update
// D: Remove, Delete

public enum PermissionName
{
    INVALID_PERMISSION = 1,

    Review_Add = 2,
    Review_Update = 3,
    Review_Remove = 4,
    Review_Read = 5,

    Product_Read = 6,
    Product_Read_Customer = 7,
    OrderHeader_Read_Customer = 8,
    User_Read_Customer = 9
}

public sealed partial class Permission
{
    private const char _floor = '_';
    //public static Permission INVALID_PERMISSION = new(nameof(INVALID_PERMISSION)) //Test purposes
    //{
    //    Type = PermissionType.Other
    //};

    public string Name { get; init; }
    public PermissionType Type { get; init; } = PermissionType.Other;
    public string? RelatedAggregateRoot { get; init; }
    public string? RelatedEntity { get; init; }
    public List<string>? Properties { get; init; } = null;

    // EF Core을 위한 생성자
    private Permission()
    {
    }

    private Permission(string name)
    {
        Name = name;
    }

    //public static Result<Permission> CreatePermission(
    //public static ValidationResult<Permission> Create(
    public static Result<Permission> Create(
        string name,
        string relatedAggregateRoot,            // string?
        string relatedEntity,                   // string?
        string permissionTypeAsString,
        List<string>? allowedProperties = null)
    {
        var parsePermissionTypeResult = Enum.TryParse<PermissionType>(permissionTypeAsString, out var permissionType);

        var errors = Validate(name, relatedAggregateRoot, relatedEntity, parsePermissionTypeResult, permissionTypeAsString, allowedProperties);
        //return errors.CreateValidationResult(() => new Permission(name)
        //{
        //    RelatedAggregateRoot = relatedAggregateRoot,
        //    RelatedEntity = relatedEntity,
        //    Type = permissionType,
        //    Properties = allowedProperties
        //});
        if (errors.NotNullOrEmpty())
        {
            return ValidationResult<Permission>.WithErrors([.. errors]);
        }

        return new Permission(name)
        {
            RelatedAggregateRoot = relatedAggregateRoot,
            RelatedEntity = relatedEntity,
            Type = permissionType,
            Properties = allowedProperties
        };
    }

    public static IList<Error> Validate(
        string name,
        string relatedAggregateRoot,        // string?
        string relatedEntity,               // string?
        bool parsePermissionTypeResult,
        string permissionTypeAsString,
        List<string>? allowedProperties = null)
    {
        return EmptyList<Error>()
            .If(name.NotContains(_floor), Error.InvalidArgument($"Permission must contain '{_floor}'."))
            .If(parsePermissionTypeResult is false, Error.InvalidArgument($"{permissionTypeAsString} is not a valid PermissionType. Valid PermissionTypes: {string.Join(", ", PermissionType.Other.GetEnumNames())}"));
            //.If(IsAggregateRoot(relatedAggregateRoot) is false, Error.InvalidArgument($"{relatedAggregateRoot} is not a valid RelatedAggregateRoot"))
            //.If(IsEntity(relatedEntity) is false, Error.InvalidArgument($"{relatedEntity} is not a valid Entity"))
            //.If(IsEntity(relatedEntity) && ReatedEntityPropertiesAreInvalid(relatedEntity, allowedProperties), Error.InvalidArgument($"{relatedEntity} is not a valid Entity"));
    }

    //public static Result<Permission> CreatePermission<TAggregateRoot, TEntity>(
    //    string name,
    //    PermissionType permissionType,
    //    List<string>? allowedProperties = null)
    //    where TAggregateRoot : class, IAggregateRoot
    //    where TEntity : class, IEntity
    //{
    //    return CreatePermission(name, typeof(TAggregateRoot).Name, typeof(TEntity).Name, permissionType.ToString(), allowedProperties);
    //}

    //public PermissionName GetRelatedEnum()
    //{
    //    return Enum.Parse<PermissionName>(Name);
    //}


    //private static bool ReatedEntityPropertiesAreInvalid(string relatedEntity, List<string>? allowedProperties)
    //{
    //    return allowedProperties is not null && ValidateEntityProperties(relatedEntity, allowedProperties).IsFailure;
    //}
}