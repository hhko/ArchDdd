using ArchDdd.Domain.Abstractions.BaseTypes;
using ArchDdd.Domain.Abstractions.Results;
using PrimitiveUtilities;
using System.Text;
using static PrimitiveUtilities.ListUtilities;
using static ArchDdd.Domain.AggregateRoots.Users.Errors.DomainErrors;

namespace ArchDdd.Domain.AggregateRoots.Users.ValueObjects;

public sealed class PasswordHash : ValueObject
{
    public const int BytesLong = 514;

    public new string Value { get; }

    private PasswordHash(string value)
    {
        Value = value;
    }

    public static ValidationResult<PasswordHash> Create(string passwordHash)
    {
        var errors = Validate(passwordHash);
        return errors.CreateValidationResult(() => new PasswordHash(passwordHash));
    }

    public static IList<Error> Validate(string passwordHash)
    {
        return EmptyList<Error>()
            .If(passwordHash.IsNullOrEmptyOrWhiteSpace(), PasswordHashError.Empty)
            .If(Encoding.ASCII.GetByteCount(passwordHash) > BytesLong, PasswordHashError.BytesLong);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}