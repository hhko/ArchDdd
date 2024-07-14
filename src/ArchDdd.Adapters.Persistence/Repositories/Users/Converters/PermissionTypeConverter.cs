using ArchDdd.Domain.AggregateRoots.Users.Enumerations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArchDdd.Adapters.Persistence.Repositories.Users.Converters;

internal sealed class PermissionTypeConverter 
    : ValueConverter<PermissionType, string>
{
    public PermissionTypeConverter() 
        : base(
            // object -> string
            convertToProviderExpression: status => status.ToString(),
            // string -> object
            convertFromProviderExpression: @string => (PermissionType)Enum.Parse(typeof(PermissionType), @string))
    {
    }
}