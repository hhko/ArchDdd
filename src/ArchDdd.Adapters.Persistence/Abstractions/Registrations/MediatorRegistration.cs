using ArchDdd.Adapters.Persistence.Abstractions.Pipelines;

namespace Microsoft.Extensions.DependencyInjection;

internal static class MediatorRegistration
{
    internal static IServiceCollection RegisterMediator(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(ArchDdd.Adapters.Persistence.AssemblyReference.Assembly);

            // Behavior 순서는 중요하다.
            configuration.AddOpenBehavior(typeof(CommandTransactionPipeline<,>));
            configuration.AddOpenBehavior(typeof(CommandWithResponseTransactionPipeline<,>));
        });

        return services;
    }
}