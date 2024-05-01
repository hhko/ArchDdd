using Mono.Cecil;
using Mono.Cecil.Rocks;
using NetArchTest.Rules;

namespace ArchDdd.Tests.Unit.ArchitectureTests.Utilities.CustomRules;

public sealed class HavePrivateParametersConstructor : ICustomRule
{
    public bool MeetsRule(TypeDefinition type)
    {
        return type
            .GetConstructors()
            .Any(c => c.IsPrivate && c.HasParameters is true);
    }
}
