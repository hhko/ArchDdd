using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ArchDdd.Adapters.Infrastructure.Options.OpenTelemetry;

internal sealed class OpenTelemetryOptionsSetup(IConfiguration configuration) : IConfigureOptions<OpenTelemetryOptions>
{
    private const string _configurationSectionName = nameof(OpenTelemetryOptions);
    private readonly IConfiguration _configuration = configuration;

    public void Configure(OpenTelemetryOptions options)
    {
        _configuration
            .GetSection(_configurationSectionName)
            .Bind(options);
    }
}
