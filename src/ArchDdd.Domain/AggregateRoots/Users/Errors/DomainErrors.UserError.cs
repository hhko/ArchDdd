using ArchDdd.Domain.Abstractions.Results;

namespace ArchDdd.Domain.AggregateRoots.Users.Errors;

public static partial class DomainErrors
{
    public static class UserError
    {
        public static Error NotFound(string uniqueValue)
        {
            return Error.New(
                $"{nameof(DomainErrors)}.{nameof(User)}.{nameof(NotFound)}",
                $"{nameof(User)} for '{uniqueValue}' was not found.");
        }
    }
}
