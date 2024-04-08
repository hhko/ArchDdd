using System.Collections;

namespace ArchDdd.Tests.Unit.LayerTests.Adapter;

public class DatabaseOptionsInvalidationData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new Dictionary<string, string> {
                { "DatabaseOptions:ConnectionString", "appsettings.메모리.json... ConnectionString" },
                { "DatabaseOptions:MaxRetryCount", "0"},        // Invalid
                { "DatabaseOptions:MaxRetryDelay", "1"},
                { "DatabaseOptions:CommandTimeout", "1"}
            } };
        yield return new object[] { new Dictionary<string, string> {
                { "DatabaseOptions:ConnectionString", "appsettings.메모리.json... ConnectionString" },
                { "DatabaseOptions:MaxRetryCount", "1"},
                { "DatabaseOptions:MaxRetryDelay", "0"},        // Invalid
                { "DatabaseOptions:CommandTimeout", "1"}
            } };
        yield return new object[] { new Dictionary<string, string> {
                { "DatabaseOptions:ConnectionString", "appsettings.메모리.json... ConnectionString" },
                { "DatabaseOptions:MaxRetryCount", "1"},
                { "DatabaseOptions:MaxRetryDelay", "1"},
                { "DatabaseOptions:CommandTimeout", "0"}        // Invalid
            } };
        yield return new object[] { new Dictionary<string, string> {
                { "DatabaseOptions:ConnectionString", "appsettings.메모리.json... ConnectionString" },
                { "DatabaseOptions:MaxRetryCount", "0"},        // Invalid
                { "DatabaseOptions:MaxRetryDelay", "0"},        // Invalid
                { "DatabaseOptions:CommandTimeout", "0"}        // Invalid
            } };
        yield return new object[] { new Dictionary<string, string> {
                { "DatabaseOptions:ConnectionString", "" },     // Invalid
                { "DatabaseOptions:MaxRetryCount", "1"},
                { "DatabaseOptions:MaxRetryDelay", "1"},
                { "DatabaseOptions:CommandTimeout", "1"}
            } };
        yield return new object[] { new Dictionary<string, string> {
                { "DatabaseOptions:ConnectionString", "" },     // Invalid
                { "DatabaseOptions:MaxRetryCount", "0"},        // Invalid
                { "DatabaseOptions:MaxRetryDelay", "0"},        // Invalid
                { "DatabaseOptions:CommandTimeout", "0"}        // Invalid
            } };
        yield return new object[] { new Dictionary<string, string>()
            };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
