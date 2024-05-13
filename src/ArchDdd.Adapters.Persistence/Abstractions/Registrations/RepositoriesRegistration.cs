using ArchDdd.Adapters.Persistence.Repositories;
using ArchDdd.Domain.AggregateRoots.Users;

namespace Microsoft.Extensions.DependencyInjection;

internal static class RepositoriesRegistration
{
    internal static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}