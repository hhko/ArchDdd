using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;

namespace ArchDdd.Domain.AggregateRoots.Users.Errors;

public static partial class DomainErrors
{
    public static class EmailError
    {
        public static Error Empty()
        {
            return Error.New(
                $"{nameof(DomainErrors)}.{nameof(Email)}.{nameof(Empty)}",
                $"{nameof(Email)} is empty.");
        }

        public static Error TooLong(string value)
        {
            return Error.New(
                $"{nameof(DomainErrors)}.{nameof(Email)}.{nameof(TooLong)}",
                $"{nameof(Email)} must be at most {Email.MaxLength} characters long. the current value is {value}.");
        }

        public static Error Invalid(string value)
        {
            return Error.New(
                $"{nameof(DomainErrors)}.{nameof(Email)}.{nameof(Invalid)}",
                $"{nameof(Email)} must start from a letter, contain '@' and after that '.'. the current value is {value}.");
        }

        public static Error EmailAlreadyTaken(string value)
        {
            return Error.New(
                $"{nameof(DomainErrors)}.{nameof(Email)}.{nameof(EmailAlreadyTaken)}",
                $"{nameof(Email)} is already taken. the current value is {value}.");
        }

        //public static readonly Error Empty = Error.New(
        //    $"{nameof(DomainErrors)}.{nameof(Email)}.{nameof(Empty)}",
        //    $"{nameof(Email)} is empty.");

        //public static readonly Error TooLong = Error.New(
        //    $"{nameof(DomainErrors)}.{nameof(Email)}.{nameof(TooLong)}",
        //    $"{nameof(Email)} must be at most {Email.MaxLength} characters long.");

        //public static readonly Error Invalid = Error.New(
        //    $"{nameof(DomainErrors)}.{nameof(Email)}.{nameof(Invalid)}",
        //    $"{nameof(Email)} must start from a letter, contain '@' and after that '.'.");

        //public static readonly Error EmailAlreadyTaken = Error.New(
        //    $"{nameof(DomainErrors)}.{nameof(Email)}.{nameof(EmailAlreadyTaken)}",
        //    $"{nameof(Email)} is already taken.");
    }
}
