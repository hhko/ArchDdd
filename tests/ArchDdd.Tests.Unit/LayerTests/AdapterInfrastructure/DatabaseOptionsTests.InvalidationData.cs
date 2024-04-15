using ArchDdd.Adapters.Infrastructure.Options;
using ArchDdd.Adapters.Infrastructure.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NSubstitute;

namespace ArchDdd.Tests.Unit.LayerTests.Adapter;

public partial class DatabaseOptionsTests
{
    [Theory]
    [MemberData(nameof(InvalidationData))]
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

    public static IEnumerable<object[]> InvalidationData =>
        new List<object[]>
        {
            new object[] { new Dictionary<string, string> {
                { "DatabaseOptions:ConnectionString", "appsettings.메모리.json... ConnectionString" },
                { "DatabaseOptions:MaxRetryCount", "0"},        // Invalid
                { "DatabaseOptions:MaxRetryDelay", "1"},
                { "DatabaseOptions:CommandTimeout", "1"}
            } },
            new object[] { new Dictionary<string, string> {
                { "DatabaseOptions:ConnectionString", "appsettings.메모리.json... ConnectionString" },
                { "DatabaseOptions:MaxRetryCount", "1"},
                { "DatabaseOptions:MaxRetryDelay", "0"},        // Invalid
                { "DatabaseOptions:CommandTimeout", "1"}
            } },
            new object[] { new Dictionary<string, string> {
                { "DatabaseOptions:ConnectionString", "appsettings.메모리.json... ConnectionString" },
                { "DatabaseOptions:MaxRetryCount", "1"},
                { "DatabaseOptions:MaxRetryDelay", "1"},
                { "DatabaseOptions:CommandTimeout", "0"}        // Invalid
            } },
            new object[] { new Dictionary<string, string> {
                { "DatabaseOptions:ConnectionString", "appsettings.메모리.json... ConnectionString" },
                { "DatabaseOptions:MaxRetryCount", "0"},        // Invalid
                { "DatabaseOptions:MaxRetryDelay", "0"},        // Invalid
                { "DatabaseOptions:CommandTimeout", "0"}        // Invalid
            } },
            new object[] { new Dictionary<string, string> {
                { "DatabaseOptions:ConnectionString", "" },     // Invalid
                { "DatabaseOptions:MaxRetryCount", "1"},
                { "DatabaseOptions:MaxRetryDelay", "1"},
                { "DatabaseOptions:CommandTimeout", "1"}
            } },
            new object[] { new Dictionary<string, string> {
                { "DatabaseOptions:ConnectionString", "" },     // Invalid
                { "DatabaseOptions:MaxRetryCount", "0"},        // Invalid
                { "DatabaseOptions:MaxRetryDelay", "0"},        // Invalid
                { "DatabaseOptions:CommandTimeout", "0"}        // Invalid
            } },
            new object[] { new Dictionary<string, string>() }   // Invalid
        };
}
