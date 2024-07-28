using ArchDdd.Application.Abstractions.Cache;
using Microsoft.Extensions.DependencyInjection;

namespace ArchDdd.Application.Abstractions.Registrations;

public static class ApplicationLayerRegistration
{
    public static IServiceCollection RegisterApplicationLayer(
        this IServiceCollection services)
    {
        Console.WriteLine($"Seeding Application Layer Memory Cache: {ApplicationCache.SeedCache}");

        services
            .RegisterValidation()
            .RegisterMediator();

        return services;
    }
}
