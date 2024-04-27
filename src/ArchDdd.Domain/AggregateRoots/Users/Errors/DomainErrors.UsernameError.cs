using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;

namespace ArchDdd.Domain.AggregateRoots.Users.Errors;

public static partial class DomainErrors
{
    public static class UsernameError
    {
        public static readonly Error Empty = Error.New(
            $"{nameof(Username)}.{nameof(Empty)}",
            $"{nameof(Username)} name is empty.");

        public static readonly Error TooLong = Error.New(
            $"{nameof(Username)}.{nameof(TooLong)}",
            $"{nameof(Username)} name must be at most {Username.MaxLength} characters.");

        public static readonly Error ContainsIllegalCharacter = Error.New(
            $"{nameof(Username)}.{nameof(ContainsIllegalCharacter)}",
            $"{nameof(Username)} contains illegal character.");
    }
}
