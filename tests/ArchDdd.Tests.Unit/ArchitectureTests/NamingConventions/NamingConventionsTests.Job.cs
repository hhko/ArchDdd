using ArchDdd.Tests.Unit.ArchitectureTests.Utilities;
using NetArchTest.Rules;
using Quartz;
using Xunit.Abstractions;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.ArchitectureTests.NamingConventions;

[Trait(nameof(UnitTest), UnitTest.Architecture)]
public sealed partial class NamingConventionsTests
{
    private readonly ITestOutputHelper _output;

    public NamingConventionsTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void JobNames_ShouldEndWithJob()
    {
        // Arrange
        var assembly = Adapters.Persistence.AssemblyReference.Assembly;

        // Act
        var actual = Types
            .InAssembly(assembly).That().ImplementInterface(typeof(IJob))
            .Should().HaveNameEndingWith(NamingConvention.Job)
            .GetResult();

        // Assert
        actual.ShouldBeTrue(_output);
    }
}
