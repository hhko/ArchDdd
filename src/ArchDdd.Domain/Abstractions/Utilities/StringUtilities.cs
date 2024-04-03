namespace ArchDdd.Domain.Abstractions.Utilities;

public static class StringUtilities
{
    public static bool IsNullOrEmptyOrWhiteSpace(this string? input)
    {
        return string.IsNullOrWhiteSpace(input);
    }
}
