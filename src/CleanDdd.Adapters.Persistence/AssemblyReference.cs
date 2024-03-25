using System.Reflection;

namespace CleanDdd.Adapters.Persistence;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}

