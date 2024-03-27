using NetArchTest.Rules;
using Xunit.Abstractions;

namespace ArchDdd.Tests.Unit.Abstractions.Utilities;

public static class TestResultUtilities
{
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