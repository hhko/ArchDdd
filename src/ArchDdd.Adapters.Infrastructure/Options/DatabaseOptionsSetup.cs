using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ArchDdd.Adapters.Infrastructure.Options;

internal sealed class DatabaseOptionsSetup(IConfiguration configuration,
                                           IHostEnvironment environment)
    : IConfigureOptions<DatabaseOptions>
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IHostEnvironment _environment = environment;

    // ConnectionStrings KeyName
    private const string _defaultConnectionSectionName = "DefaultConnection";
    private const string _testConnectionSectionName = "TestConnection";

    // DatabaseOptions KeyName
    private const string _configurationSectionName = "DatabaseOptions";

    public void Configure(DatabaseOptions options)
    {
        //if (_environment.IsProduction() is true)
        //{
        //    options.ConnectionString = _configuration.GetConnectionString(_defaultConnectionSectionName);
        //}
        //else if (_environment.IsDevelopment() is true)
        //{
        //    options.ConnectionString = _configuration.GetConnectionString(_testConnectionSectionName);
        //}

        _configuration
            .GetSection(_configurationSectionName)
            .Bind(options);     // Validate(string? name, DatabaseOptions options)
    }
}
