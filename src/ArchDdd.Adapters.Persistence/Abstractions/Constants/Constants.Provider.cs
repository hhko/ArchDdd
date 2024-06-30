namespace ArchDdd.Adapters.Persistence.Abstractions.Constants;

internal static partial class Constants
{
    internal static class Provider
    {
        //internal static string Sqlite;
        //internal static string PostgreSQL;

        //static Provider()
        //{
        //    Sqlite = nameof(Sqlite).ToLowerInvariant();
        //    PostgreSQL = nameof(PostgreSQL).ToLowerInvariant();
        //}

        internal const string Sqlite = "sqlite";
        internal const string PostgreSQL = "postgresql";
    }
}
