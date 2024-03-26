using NetArchTest.Rules;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.ArchitectureTests;

[Trait(nameof(UnitTest), UnitTest.Architecture)]
public sealed class DependencyTests
{
    // HaveDependencyOnAny
    // HaveDependencyOnAll
    [Fact]
    public void HostLayer_ShouldNotDependOn_AnythingOtherThanAdapterLayer()
    {
        // Arrange
        var assembly = Host.AssemblyReference.Assembly;

        var otherAssemblies = new[]
        {
            Application.AssemblyReference.Assembly.GetName().Name,
            Domain.AssemblyReference.Assembly.GetName().Name,
        };

        // Act
        var actual = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherAssemblies)
            .GetResult();

        // Assert
        actual.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void AdapterLayer_ShouldNotDependOn_AnthingOtherThanApplicationLayer()
    {
        // Arrange
        var assemblies = new[]
        {
            Adapters.Persistence.AssemblyReference.Assembly,
            Adapters.Infrastructure.AssemblyReference.Assembly,
            Adapters.Presentation.AssemblyReference.Assembly
        };

        var otherAssemblies = new[]
        {
            Host.AssemblyReference.Assembly.GetName().Name,
            Domain.AssemblyReference.Assembly.GetName().Name,
        };

        // Act
        var actual = Types
            .InAssemblies(assemblies)
            .ShouldNot()
            .HaveDependencyOnAny(otherAssemblies)
            .GetResult();

        // Assert
        actual.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void ApplicationLayer_ShouldNotDependOn_AnythingOtherThanDomainLayer()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        var otherAssemblies = new[]
        {
            Host.AssemblyReference.Assembly.GetName().Name,
            Adapters.Persistence.AssemblyReference.Assembly.GetName().Name,
            Adapters.Infrastructure.AssemblyReference.Assembly.GetName().Name,
            Adapters.Presentation.AssemblyReference.Assembly.GetName().Name,
        };

        // Act
        var actual = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherAssemblies)
            .GetResult();

        // Assert
        actual.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void DomainLayer_ShouldNotDependOn_OtherLayers()
    {
        // Arrange
        var assembly = Domain.AssemblyReference.Assembly;

        var otherAssemblies = new[]
        {
            Host.AssemblyReference.Assembly.GetName().Name,
            Adapters.Persistence.AssemblyReference.Assembly.GetName().Name,
            Adapters.Infrastructure.AssemblyReference.Assembly.GetName().Name,
            Adapters.Presentation.AssemblyReference.Assembly.GetName().Name,
            Application.AssemblyReference.Assembly.GetName().Name,
        };

        // Act
        var actual = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherAssemblies)
            .GetResult();

        // Assert
        actual.IsSuccessful.Should().BeTrue();
    }
}