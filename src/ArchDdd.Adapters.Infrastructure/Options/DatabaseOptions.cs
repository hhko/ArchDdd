namespace ArchDdd.Adapters.Infrastructure.Options;

//System.MissingMethodException: 'Cannot dynamically create an instance of type 'Microsoft.Extensions.DependencyInjection.DatabaseOptionsSetup'. 
//Reason: No parameterless constructor defined.'
public sealed class DatabaseOptions
{
    public const string ConnectionStrings = nameof(ConnectionStrings);
    public const string DatabaseCountOptions = nameof(DatabaseCountOptions);

    public DatabaseOptions()
    {
        
    }

    // ConnectionStrings
    public string? DefaultConnection { get; set; } = string.Empty;

    // DatabaseCountOptions
    public int MaxRetryCount { get; set; }
    public int MaxRetryDelay { get; set; }
    public int CommandTimeout { get; set; }
}