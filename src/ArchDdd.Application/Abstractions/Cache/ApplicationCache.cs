namespace ArchDdd.Application.Abstractions.Cache;

public static partial class ApplicationCache
{
    public static bool SeedCache { get; set; }

    static ApplicationCache()
    {
        ValidationResultCache = CreateValidationResultCache();
    }
}
