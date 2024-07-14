using ArchDdd.Adapters.Persistence.Repositories.Users;
using ArchDdd.Domain.AggregateRoots.Users.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

internal static class DatabaseRepositoriesRegistration
{
    internal static IServiceCollection RegisterDatabaseRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepositoryQuery, UserRepositoryQuery>();
        services.AddScoped<IUserRepositoryCommand, UserRepositoryCommand>();

        services.AddScoped<IAuthorizationRepositoryQuery, AuthorizationRepositoryQuery>();

        return services;
    }
}