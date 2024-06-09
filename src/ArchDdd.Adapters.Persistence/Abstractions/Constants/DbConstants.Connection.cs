namespace ArchDdd.Adapters.Persistence.Abstractions.Constants;

internal static partial class DbConstants
{
    internal static class Connection
    {
        internal const string TestConnection = nameof(TestConnection);
        internal const string DefaultConnection = nameof(DefaultConnection);
        internal const string ConnectionStringJsonFile = "connectionString.json";
    }
}