using ArchDdd.Adapters.Persistence.Repositories.Users;
using ArchDdd.Application.UseCases.Users.Commands;
using ArchDdd.Application.UseCases.Users.Queries;

namespace Microsoft.Extensions.DependencyInjection;

internal static class DatabaseRepositoriesRegistration
{
    internal static IServiceCollection RegisterDatabaseRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepositoryQuery, UserRepositoryQuery>();
        services.AddScoped<IUserRepositoryCommand, UserRepositoryCommand>();

        services.AddScoped<IAuthorizationRepositoryQuery, AuthorizationRepositoryQuery>();
        services.AddScoped<IAuthorizationRepositoryCommand, AuthorizationRepositoryCommand>();

        return services;
    }
}