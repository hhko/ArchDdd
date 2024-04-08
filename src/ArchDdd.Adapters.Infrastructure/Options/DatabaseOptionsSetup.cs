using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ArchDdd.Adapters.Infrastructure.Options;

internal sealed class DatabaseOptionsSetup(
    IConfiguration configuration,
    IWebHostEnvironment environment) 
    : IConfigureOptions<DatabaseOptions>
{
    private readonly IConfiguration _configuration = configuration;
    private readonly IWebHostEnvironment _environment = environment;

    private const string _configurationSectionName = "DatabaseOptions";

    public void Configure(DatabaseOptions options)
    {
        //if (_environment.IsProduction() is true)
        //{
        //    options.ConnectionString = _configuration
        //        .GetConnectionString(_defaultConnection);
        //}
        //else if (_environment.IsDevelopment() is true)
        //{
        //    options.ConnectionString = _configuration
        //        .GetConnectionString(_testConnection);
        //}

        _configuration
            .GetSection(_configurationSectionName)
            .Bind(options);
    }
}