using ArchDdd.Adapters.Infrastructure.Validators;
using ArchDdd.Application.Abstractions;
using ArchDdd.Domain.AggregateRoots.Users;
using Microsoft.AspNetCore.Identity;

namespace Microsoft.Extensions.DependencyInjection;

internal static class ServiceRegistration
{
    internal static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        // Validators
        services.AddScoped<IValidator, Validator>();

        return services;
    }
}
