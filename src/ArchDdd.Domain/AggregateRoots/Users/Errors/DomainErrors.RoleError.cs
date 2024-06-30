using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.AggregateRoots.Users.Authorization;

namespace ArchDdd.Domain.AggregateRoots.Users.Errors;

public static partial class DomainErrors
{
    public static class RoleError
    {
        public static Error NotFound(string uniqueValue)
        {
            return Error.New(
                $"{nameof(DomainErrors)}.{nameof(Role)}.{nameof(NotFound)}",
                $"{nameof(Role)} for '{uniqueValue}' was not found.");
        }

        public static Error InvalidOperation(string roleName)
        {
            return Error.New(
                $"{nameof(DomainErrors)}.{nameof(Role)}.{nameof(NotFound)}",
                $"Adding permission to {roleName} {nameof(Role)} is forbidden.");
        }
    }
}