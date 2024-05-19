using System.Text.RegularExpressions;

namespace ArchDddPrimitivess.Utilities;

public static class RegexUtilities
{
    public static bool NotMatch(this Regex regex, string value)
    {
        return regex.IsMatch(value) is false;
    }
}
