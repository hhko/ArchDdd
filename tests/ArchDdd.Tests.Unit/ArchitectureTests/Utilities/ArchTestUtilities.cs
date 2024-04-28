using ArchDdd.Tests.Unit.ArchitectureTests.Utilities.CustomRules;
using NetArchTest.Rules;
using Xunit.Abstractions;

namespace ArchDdd.Tests.Unit.ArchitectureTests.Utilities;

public static class ArchTestUtilities
{
    //public static ConditionList HavePrivateParameterlessConstructor(this Conditions conditions)
    //{
    //    return conditions.MeetCustomRule(new HavePrivateParameterlessConstructor());
    //}

    public static ConditionList DefineMethod(this Conditions conditions, string methodName)
    {
        return conditions.MeetCustomRule(new DefinesMethod(methodName));
    }

    public static void ShouldBeTrue(this TestResult testResult, ITestOutputHelper output)
    {
        if (!testResult.IsSuccessful)
        {
            output.WriteLine("FailingTypeNames:");
            foreach (string failingTypeName in testResult.FailingTypeNames)
            {
                output.WriteLine(failingTypeName);
            }
        }

        testResult.IsSuccessful.Should().BeTrue();
    }
}
