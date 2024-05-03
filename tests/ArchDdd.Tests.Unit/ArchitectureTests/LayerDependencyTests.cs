using ArchDdd.Tests.Unit.ArchitectureTests.Utilities;
using NetArchTest.Rules;
using Xunit.Abstractions;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.ArchitectureTests;

[Trait(nameof(UnitTest), UnitTest.Architecture)]
public sealed class LayerDependencyTests
{
    private readonly ITestOutputHelper _output;

    public LayerDependencyTests(ITestOutputHelper output)
    {
        _output = output;
    }

    //[Fact]
    //public void HostLayer_ShouldNotHaveDependency_OnOtherLayersThanAdapter()
    //{
    //    // Arrange
    //    var assembly = Host.AssemblyReference.Assembly;

    //    var otherAssemblies = new[]
    //    {
    //        // Host.AssemblyReference.Assembly.GetName().Name,
    //        // Adapters.Infrastructure.AssemblyReference.Assembly.GetName().Name,
    //        // Adapters.Persistence.AssemblyReference.Assembly.GetName().Name,
    //        // Adapters.Presentation.AssemblyReference.Assembly.GetName().Name,
    //        Application.AssemblyReference.Assembly.GetName().Name,
    //        Domain.AssemblyReference.Assembly.GetName().Name,
    //    };

    //    // Act
    //    var actual = Types
    //        .InAssembly(assembly)
    //        .ShouldNot().HaveDependencyOnAny(otherAssemblies)
    //        .GetResult();

    //    // Assert
    //    actual.ShouldBeTrue(_output);
    //}

    //[Fact]
    //public void AdapterLayers_CheckDependencisExceptApplicationLayer_ShouldNotHaveDependencies()
    //{
    //    // Arrange
    //    var assemblies = new[]
    //    {
    //        Adapters.Persistence.AssemblyReference.Assembly,
    //        Adapters.Infrastructure.AssemblyReference.Assembly,
    //        Adapters.Presentation.AssemblyReference.Assembly
    //    };

    //    var otherAssemblies = new[]
    //    {
    //        // Host.AssemblyReference.Assembly.GetName().Name,
    //        // Adapters.Infrastructure.AssemblyReference.Assembly.GetName().Name,
    //        // Adapters.Persistence.AssemblyReference.Assembly.GetName().Name,
    //        // Adapters.Presentation.AssemblyReference.Assembly.GetName().Name,
    //        // Application.AssemblyReference.Assembly.GetName().Name,
    //        Domain.AssemblyReference.Assembly.GetName().Name,
    //    };

    //    // Act
    //    var actual = Types
    //        .InAssemblies(assemblies)
    //        .ShouldNot().HaveDependencyOnAny(otherAssemblies)
    //        .GetResult();

    //    // Assert
    //    actual.ShouldBeTrue(_output);
    //}

    [Fact]
    public void ApplicationLayer_CheckDependencisExceptDomainLayer_ShouldNotHaveDependencies()
    {
        // Arrange
        var assembly = Application.AssemblyReference.Assembly;

        var otherAssemblies = new[]
        {
            //Host.AssemblyReference.Assembly.GetName().Name,
            Adapters.Infrastructure.AssemblyReference.Assembly.GetName().Name,
            Adapters.Persistence.AssemblyReference.Assembly.GetName().Name,
            Adapters.Presentation.AssemblyReference.Assembly.GetName().Name,
            // Application.AssemblyReference.Assembly.GetName().Name,
            // Domain.AssemblyReference.Assembly.GetName().Name,
        };

        // Act
        var actual = Types
            .InAssembly(assembly)
            .ShouldNot().HaveDependencyOnAny(otherAssemblies)
            .GetResult();

        // Assert
        actual.ShouldBeTrue(_output);
    }

    [Fact]
    public void DomainLayer_CheckDependencisAnyLayers_ShouldNotHaveDependencies()
    {
        // Arrange
        var assembly = Domain.AssemblyReference.Assembly;

        var otherAssemblies = new[]
        {
            //Host.AssemblyReference.Assembly.GetName().Name,
            Adapters.Infrastructure.AssemblyReference.Assembly.GetName().Name,
            Adapters.Persistence.AssemblyReference.Assembly.GetName().Name,
            Adapters.Presentation.AssemblyReference.Assembly.GetName().Name,
            Application.AssemblyReference.Assembly.GetName().Name,
            // Domain.AssemblyReference.Assembly.GetName().Name,
        };

        // Act
        var actual = Types
            .InAssembly(assembly)
            .ShouldNot().HaveDependencyOnAny(otherAssemblies)
            .GetResult();

        // Assert
        actual.ShouldBeTrue(_output);
    }
}