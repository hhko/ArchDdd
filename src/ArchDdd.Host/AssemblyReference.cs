using System.Reflection;

namespace ArchDdd.Host;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}

