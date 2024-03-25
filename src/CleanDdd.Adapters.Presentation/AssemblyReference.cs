using System.Reflection;

namespace CleanDdd.Adapters.Presentation;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}

