using ArchDdd.Domain.Abstractions.BaseTypes;
using ArchDdd.Domain.Abstractions.Results;
using PrimitiveUtilities;
using System.Buffers;
using static ArchDdd.Domain.AggregateRoots.Users.Errors.DomainErrors;
using static PrimitiveUtilities.ListUtilities;

namespace ArchDdd.Domain.AggregateRoots.Users.ValueObjects;

public sealed partial class Username : ValueObject
{
    //
    // 유효성 검사 규칙
    //

    // 유효성 검사 규칙 1.
    public static readonly int MaxLength = 30;

    // 유효성 검사 규칙 2.
    public static readonly char[] IllegalCharacters =
        ['!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '\'', '"', '[', ']', ';', ':', '\\', '|', '/', '.', ',', '>', '<', '?', '-', '_', '+', '+', '~', '`'];
    private static readonly SearchValues<char> _illeagalCharacterSearchValues = SearchValues.Create(IllegalCharacters);

    private Username(string value)
    {
        Value = value;
    }

    public new string Value { get; }

    public static ValidationResult<Username> Create(string username)
    {
        var errors = Validate(username);
        return errors.CreateValidationResult(createValueObject: () => new Username(username));
    }

    public static IList<Error> Validate(string username)
    {
        return EmptyList<Error>()
            .If(username.IsNullOrEmptyOrWhiteSpace(), UsernameError.Empty())
            .If(username.Length > MaxLength, UsernameError.TooLong(username))
            .If(username.ContainsIllegalCharacter(_illeagalCharacterSearchValues), UsernameError.ContainsIllegalCharacter(username));
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
