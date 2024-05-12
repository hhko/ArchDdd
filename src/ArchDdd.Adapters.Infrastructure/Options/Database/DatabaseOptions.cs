namespace ArchDdd.Adapters.Infrastructure.Options;

public sealed class DatabaseOptions
{
    public string ConnectionString { get; set; } = default!;

    public int MaxRetryCount { get; set; }
    public int MaxRetryDelay { get; set; }
    public int CommandTimeout { get; set; }
}