using Mono.Cecil;
using Mono.Cecil.Rocks;
using NetArchTest.Rules;

namespace ArchDdd.Tests.Unit.ArchitectureTests.Utilities.CustomRules;

public sealed class HaveMethod(string methodName) : ICustomRule
{
    public bool MeetsRule(TypeDefinition type)
    {
        return type
            .Methods
            .Any(methodDefinition => methodDefinition.Name == methodName);
    }
}