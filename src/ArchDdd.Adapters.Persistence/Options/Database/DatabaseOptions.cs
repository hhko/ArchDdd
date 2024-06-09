namespace ArchDdd.Adapters.Persistence.Options.Database;

public sealed class DatabaseOptions
{
    public string Provider { get; set; } = default!;
    public string ConnectionString { get; set; } = default!;

    public int MaxRetryCount { get; set; }
    public int MaxRetryDelay { get; set; }
    public int CommandTimeout { get; set; }
}