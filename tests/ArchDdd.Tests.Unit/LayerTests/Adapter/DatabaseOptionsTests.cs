using ArchDdd.Adapters.Infrastructure.Options;
using ArchDdd.Adapters.Infrastructure.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NSubstitute;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.LayerTests.Adapter;

[Trait(nameof(UnitTest), UnitTest.Infrastructure)]
public class DatabaseOptionsTests
{
    //{
    //    "TopLevelKey": "TopLevelValue",
    //    "SectionName": {
    //                "SomeKey": "SectionValue"
    //    }
    //}
    //
    //var inMemorySettings = new Dictionary<string, string> {
    //    {"TopLevelKey", "TopLevelValue"},
    //    {"SectionName:SomeKey", "SectionValue"},
    //};

    //{
    //    "ArrayKey": [
    //        1,
    //        2,
    //        3
    //    ]
    //}
    //
    //var inMemorySettings = new Dictionary<string, string> {
    //    {"ArrayKey:0", "1"},
    //    {"ArrayKey:1", "2"},
    //    {"ArrayKey:2", "3"},
    //};

    [Theory]
    [ClassData(typeof(DatabaseOptionsValidationData))]
    public void DatabaseOptions_WhenAppsettingsIsValid_ShouldNotThrow(Dictionary<string, string> inMemorySettings)
    {
        // Arrange
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings!)
            .Build();

        ServiceCollection services = new();
        services
            .AddTransient(_ => configuration)
            .AddTransient(_ => Substitute.For<IWebHostEnvironment>())
            .RegisterAdapterInfrastructureLayer();

        // Act
        Action act = () => services.GetOptions<DatabaseOptions>();

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [ClassData(typeof(DatabaseOptionsInvalidationData))]
    public void DatabaseOptions_WhenAppsettingsIsInvalid_ShouldThrow(Dictionary<string, string> inMemorySettings)
    {
        // Arrange
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings!)
            .Build();

        ServiceCollection services = new();
        services
            .AddTransient(_ => configuration)
            .AddTransient(_ => Substitute.For<IWebHostEnvironment>())
            .RegisterAdapterInfrastructureLayer();

        // Act
        Action act = () => services.GetOptions<DatabaseOptions>();

        // Assert
        act.Should().ThrowExactly<OptionsValidationException>();
    }
}
