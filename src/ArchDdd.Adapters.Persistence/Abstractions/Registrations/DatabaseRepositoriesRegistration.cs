using ArchDdd.Adapters.Persistence.Repositories.UserRepositories;
using ArchDdd.Domain.AggregateRoots.Users;

namespace Microsoft.Extensions.DependencyInjection;

internal static class DatabaseRepositoriesRegistration
{
    internal static IServiceCollection RegisterDatabaseRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}