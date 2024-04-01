namespace ArchDdd.Adapters.Infrastructure.Options;

public sealed class DatabaseOptions
{
    public const string DatabaseConfig = nameof(DatabaseConfig);

    public DatabaseOptions()
    {
        
    }

    public string ConnectionString { get; set; } = default!;

    public int MaxRetryCount { get; set; }
    public int MaxRetryDelay { get; set; }
    public int CommandTimeout { get; set; }
}