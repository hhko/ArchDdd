using System.Collections;

namespace ArchDdd.Tests.Unit.LayerTests.Adapter;

public class DatabaseOptionsValidationData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new Dictionary<string, string> {
                { "DatabaseOptions:ConnectionString", "appsettings.메모리.json... ConnectionString" },
                { "DatabaseOptions:MaxRetryCount", "1"},
                { "DatabaseOptions:MaxRetryDelay", "1"},
                { "DatabaseOptions:CommandTimeout", "1"}
            } };
        yield return new object[] { new Dictionary<string, string> {
                { "DatabaseOptions:ConnectionString", "appsettings.메모리.json... ConnectionString" },
                { "DatabaseOptions:MaxRetryCount", "2"},
                { "DatabaseOptions:MaxRetryDelay", "2"},
                { "DatabaseOptions:CommandTimeout", "2"}
            } };
        yield return new object[] { new Dictionary<string, string> {
                { "DatabaseOptions:ConnectionString", "appsettings.메모리.json... ConnectionString" },
                { "DatabaseOptions:MaxRetryCount", "3"},
                { "DatabaseOptions:MaxRetryDelay", "3"},
                { "DatabaseOptions:CommandTimeout", "3"}
            } };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
