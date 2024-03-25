using NetArchTest.Rules;

namespace CleanDdd.Tests.Unit.ArchitectureTests;

public sealed class DependencyTests
{
    [Fact]
    public void DomainLayer_ShouldNotHaveDependency_OnOtherLayers()
    {
        // Arrange
        var assembly = Domain.AssemblyReference.Assembly;

        var otherAssemblies = new[]
        {
            Application.AssemblyReference.Assembly.GetName().Name,
            Adapters.Infrastructure.AssemblyReference.Assembly.GetName().Name,
            Adapters.Persistence.AssemblyReference.Assembly.GetName().Name,
            Adapters.Presentation.AssemblyReference.Assembly.GetName().Name,
            Host.AssemblyReference.Assembly.GetName().Name,
        };

        // Act
        var actual = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherAssemblies)
            .GetResult();

        // Assert
        actual.IsSuccessful.Should().BeTrue();
    }

    //[Fact]
    //public void Application_ShouldNotHaveDependencyOnOtherProjectsThanDomain()
    //{
    //    //Arrange
    //    var assembly = Application.AssemblyReference.Assembly;

    //    var otherAssemblies = new[]
    //    {
    //        Infrastructure.AssemblyReference.Assembly.GetName().Name,
    //        Persistence.AssemblyReference.Assembly.GetName().Name,
    //        Presentation.AssemblyReference.Assembly.GetName().Name,
    //        App.AssemblyReference.Assembly.GetName().Name,
    //    };

    //    //Act
    //    var result = Types
    //        .InAssembly(assembly)
    //        .ShouldNot()
    //        .HaveDependencyOnAll(otherAssemblies)
    //        .GetResult();

    //    //Assert
    //    result.IsSuccessful.Should().BeTrue();
    //}


    //[Fact]
    //public void Infrastructure_ShouldNotHaveDependencyOnOtherProjectsThanApplicationAndDomain()
    //{
    //    //Arrange
    //    var assembly = Infrastructure.AssemblyReference.Assembly;

    //    var otherAssemblies = new[]
    //    {
    //        Persistence.AssemblyReference.Assembly.GetName().Name,
    //        Presentation.AssemblyReference.Assembly.GetName().Name,
    //        App.AssemblyReference.Assembly.GetName().Name,
    //    };

    //    //Act
    //    var result = Types
    //        .InAssembly(assembly)
    //        .ShouldNot()
    //        .HaveDependencyOnAll(otherAssemblies)
    //        .GetResult();

    //    //Assert
    //    result.IsSuccessful.Should().BeTrue();
    //}

    //[Fact]
    //public void Persistence_ShouldNotHaveDependencyOnOtherProjectsThanInfrastructureAndApplicationAndDomain()
    //{
    //    //Arrange
    //    var assembly = Persistence.AssemblyReference.Assembly;

    //    var otherAssemblies = new[]
    //    {
    //        Presentation.AssemblyReference.Assembly.GetName().Name,
    //        App.AssemblyReference.Assembly.GetName().Name,
    //    };

    //    //Act
    //    var result = Types
    //        .InAssembly(assembly)
    //        .ShouldNot()
    //        .HaveDependencyOnAll(otherAssemblies)
    //        .GetResult();

    //    //Assert
    //    result.IsSuccessful.Should().BeTrue();
    //}

    //[Fact]
    //public void Presentation_ShouldNotHaveDependencyOnOtherProjectsThanApplicationAndDomain()
    //{
    //    //Arrange
    //    var assembly = Presentation.AssemblyReference.Assembly;

    //    var otherAssemblies = new[]
    //    {
    //        Infrastructure.AssemblyReference.Assembly.GetName().Name,
    //        Persistence.AssemblyReference.Assembly.GetName().Name,
    //        App.AssemblyReference.Assembly.GetName().Name,
    //    };

    //    //Act
    //    var result = Types
    //        .InAssembly(assembly)
    //        .ShouldNot()
    //        .HaveDependencyOnAll(otherAssemblies)
    //        .GetResult();

    //    //Assert
    //    result.IsSuccessful.Should().BeTrue();
    //}
}