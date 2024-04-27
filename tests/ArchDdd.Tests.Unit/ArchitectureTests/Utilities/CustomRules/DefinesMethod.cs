using Mono.Cecil;
using NetArchTest.Rules;

namespace ArchDdd.Tests.Unit.ArchitectureTests.Utilities.CustomRules;

public sealed class DefinesMethod(string methodName) : ICustomRule
{
    //private readonly Func<TypeDefinition, bool> _test = typeDefinition => typeDefinition
    //    .Methods
    //    .Any(methodDefinition => methodDefinition.Name == methodName);

    public bool MeetsRule(TypeDefinition type)
    {
        //return _test(type);
        return type
            .Methods
            .Any(methodDefinition => methodDefinition.Name == methodName);
    }
}