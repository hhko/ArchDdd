using ArchDdd.Domain.Abstractions.BaseTypes;
using ArchDdd.Tests.Unit.ArchitectureTests.Utilities;
using ArchDdd.Tests.Unit.ArchitectureTests.Utilities.CustomRules;
using NetArchTest.Rules;
using Xunit.Abstractions;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.ArchitectureTests;

[Trait(nameof(UnitTest), UnitTest.Architecture)]
public sealed class ValueObjectTests
{
    private readonly ITestOutputHelper _output;

    public ValueObjectTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void ValueObjects_BeSealedClass_ShouldBeTrue()
    {
        // Arrange
        var assembly = Domain.AssemblyReference.Assembly;

        // Act
        var actual = Types
            .InAssembly(assembly).That().Inherit(typeof(ValueObject))
            .Should().BeSealed()        // sealed class
            .GetResult();

        // Assert
        actual.ShouldBeTrue(_output);
    }

    [Fact]
    public void ValueObject_HavePrivateParametersConstructor_ShouldBeTrue()
    {
        // Arrange
        var assembly = Domain.AssemblyReference.Assembly;

        // Act
        var actual = Types
            .InAssembly(assembly).That().Inherit(typeof(ValueObject))
            .Should().MeetCustomRule(new HavePrivateParametersConstructor())
            .GetResult();

        // Assert
        actual.ShouldBeTrue(_output);
    }

    [Fact]
    public void ValueObjects_ShouldBeImmutable()
    {
        // Arrange
        var assembly = Domain.AssemblyReference.Assembly;

        // Act
        var actual = Types
            .InAssembly(assembly).That().Inherit(typeof(ValueObject))
            .Should().BeImmutable()      // { get; } : 성공
            .GetResult();

        // Assert
        actual.ShouldBeTrue(_output);
    }

    [Theory]
    [InlineData("Validate")]
    [InlineData("Create")]
    public void ValueObjects_HaveDefineMethods_ShouldBeTrue(string methodName)
    {
        // Arrange
        var assembly = Domain.AssemblyReference.Assembly;

        // Act
        var actual = Types
            .InAssembly(assembly).That().Inherit(typeof(ValueObject))
            .Should().MeetCustomRule(new HaveMethod(methodName))
            .GetResult();

        // Assert
        actual.ShouldBeTrue(_output);
    }
}
