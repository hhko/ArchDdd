using Microsoft.Extensions.Options;

//namespace ArchDdd.Host.Abstractions.Registration;
namespace Microsoft.Extensions.DependencyInjection;

public static class HostLayerRegistration
{
    public static IServiceCollection RegisterHostOptions(this IServiceCollection services)
    {
        services.RegisterOptions();

        return services;
    }
}

public static class OptionsRegistration
{
    internal static IServiceCollection RegisterOptions(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();

        services.AddSingleton<IValidateOptions<DatabaseOptions>, DatabaseOptionsValidator>();

        return services;
    }
}

internal sealed class DatabaseOptionsSetup(IConfiguration configuration,
                                           IWebHostEnvironment environment)
    : IConfigureOptions<DatabaseOptions>
{
    private const string _defaultConnection = "DefaultConnection";
    private const string _testConnection = "TestConnection";
    private const string _configurationSectionName = "DatabaseOptions";

    private readonly IConfiguration _configuration = configuration;
    private readonly IWebHostEnvironment _environment = environment;

    public void Configure(DatabaseOptions options)
    {
        if (_environment.IsProduction() is true)
        {
            options.ConnectionString = _configuration
                .GetConnectionString(_defaultConnection);
        }
        else if (_environment.IsDevelopment() is true)
        {
            options.ConnectionString = _configuration
                .GetConnectionString(_testConnection);
        }

        _configuration
            .GetSection(_configurationSectionName)
            .Bind(options);     // Validate(string? name, DatabaseOptions options)
    }
}

public sealed class DatabaseOptionsValidator : IValidateOptions<DatabaseOptions>
{
    public ValidateOptionsResult Validate(string? name, DatabaseOptions options)
    {
        var validationResult = string.Empty;

        //if (options.ConnectionString.IsNullOrEmptyOrWhiteSpace())
        //{
        //    validationResult += "Connection string is missing. ";
        //}

        if (options.MaxRetryCount < 1)
        {
            validationResult += "Retry Count is less than one. ";
        }

        if (options.MaxRetryDelay < 1)
        {
            validationResult += "Retry delay is less than one. ";
        }

        //if (options.CommandTimeout < 1)
        //{
        //    validationResult += "Command timeout is less than one. ";
        //}
        validationResult += "Command timeout is less than one. ";

        //if (!validationResult.IsNullOrEmptyOrWhiteSpace())
        //{
        //    return ValidateOptionsResult.Fail(validationResult);
        //}

        return ValidateOptionsResult.Fail(validationResult);
        //return ValidateOptionsResult.Success;
    }
}

public sealed class DatabaseOptions
{
    public string? ConnectionString { get; set; } = string.Empty;
    public int MaxRetryCount { get; set; }
    public int MaxRetryDelay { get; set; }
    public int CommandTimeout { get; set; }
}