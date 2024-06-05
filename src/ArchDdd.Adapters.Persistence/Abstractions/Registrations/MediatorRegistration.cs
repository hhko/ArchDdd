using ArchDdd.Adapters.Persistence.Abstractions.Pipelines;
using Microsoft.Extensions.DependencyInjection;

namespace ArchDdd.Adapters.Persistence.Abstractions.Registrations;

internal static class MediatorRegistration
{
    internal static IServiceCollection RegisterMediator(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Adapters.Persistence.AssemblyReference.Assembly);

            // Behavior 순서는 중요하다.
            configuration.AddOpenBehavior(typeof(CommandTransactionPipeline<,>));
            configuration.AddOpenBehavior(typeof(CommandWithResponseTransactionPipeline<,>));
        });

        return services;
    }
}