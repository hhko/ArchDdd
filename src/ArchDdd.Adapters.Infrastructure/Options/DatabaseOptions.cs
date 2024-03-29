namespace ArchDdd.Adapters.Infrastructure.Options;

//System.MissingMethodException: 'Cannot dynamically create an instance of type 'Microsoft.Extensions.DependencyInjection.DatabaseOptionsSetup'. 
//Reason: No parameterless constructor defined.'
public sealed class DatabaseOptions
{
    public string? ConnectionString { get; set; } = string.Empty;
    public int MaxRetryCount { get; set; }
    public int MaxRetryDelay { get; set; }
    public int CommandTimeout { get; set; }
}