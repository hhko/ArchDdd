using Mono.Cecil;
using Mono.Cecil.Rocks;
using NetArchTest.Rules;

namespace ArchDdd.Tests.Unit.ArchitectureTests.Utilities.CustomRules;

public sealed class HavePrivateParametersConstructor : ICustomRule
{
    private readonly Func<TypeDefinition, bool> _test = typeDefinition => typeDefinition
            .GetConstructors()
            .Any(c => c.IsPrivate && c.HasParameters is true);

    public bool MeetsRule(TypeDefinition type)
    {
        return _test(type);
        //return type
        //    .GetConstructors()
        //    .Any(c => c.IsPrivate && c.Parameters.Count >= 1);
    }
}
