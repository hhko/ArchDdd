using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;

namespace ArchDdd.Domain.AggregateRoots.Users.Errors;

public static partial class DomainErrors
{
    public static class PasswordHashError
    {
        public static readonly Error Empty = Error.New(
            $"{nameof(DomainErrors)}.{nameof(PasswordHash)}.{nameof(Empty)}",
            $"{nameof(PasswordHash)} is empty.");

        public static readonly Error BytesLong = Error.New(
            $"{nameof(DomainErrors)}.{nameof(PasswordHash)}.{nameof(BytesLong)}",
            $"{nameof(PasswordHash)} needs to be less than {PasswordHash.BytesLong} bytes long.");
    }
}
