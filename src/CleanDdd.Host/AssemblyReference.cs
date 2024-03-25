using System.Reflection;

namespace CleanDdd.Host;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}

