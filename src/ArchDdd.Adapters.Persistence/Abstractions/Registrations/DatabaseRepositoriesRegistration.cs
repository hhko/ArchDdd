using ArchDdd.Adapters.Persistence.Repositories.UserRepositories;
using ArchDdd.Domain.AggregateRoots.Users;

namespace Microsoft.Extensions.DependencyInjection;

internal static class DatabaseRepositoriesRegistration
{
    internal static IServiceCollection RegisterDatabaseRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepositoryQuery, UserRepositoryQuery>();
        services.AddScoped<IUserRepositoryCommand, UserRepositoryCommand>();

        return services;
    }
}