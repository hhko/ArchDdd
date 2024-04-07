using ArchDdd.Adapters.Infrastructure.Options;
using ArchDdd.Adapters.Infrastructure.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.LayerTests.Adapter;

[Trait(nameof(UnitTest), UnitTest.Infrastructure)]
public class DatabaseOptionsTests
{
    [Fact]
    public void DatabaseOptions_ShouldValdate()
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

        var inMemorySettings = new Dictionary<string, string> {
            { "TopLevelKey", "TopLevelValue"},
            { "SectionName:SomeKey", "SectionValue"},
            { "DatabaseOptions:ConnectionString", "appsettings.메모리.json... ConnectionString" },
            { "DatabaseOptions:MaxRetryCount", "1"},
            { "DatabaseOptions:MaxRetryDelay", "2"},
            { "DatabaseOptions:CommandTimeout", "3"}
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings!)
            .Build();

        ServiceCollection services = new();
        services
            .AddTransient(_ => configuration)
            .RegisterAdapterInfrastructureLayer();
            //.RegisterAdapterPersistenceLayer();

        var databaseOptions = services.GetOptions<DatabaseOptions>();
    }
}
