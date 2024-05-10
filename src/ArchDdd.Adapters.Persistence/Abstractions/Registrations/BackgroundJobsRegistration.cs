using ArchDdd.Adapters.Persistence.BackgroundJobs;
using Quartz;

namespace Microsoft.Extensions.DependencyInjection;

internal static class BackgroundJobsRegistration
{
    internal static IServiceCollection RegisterBackgroundJobs(this IServiceCollection services)
    {
        services.AddQuartz();

        services.AddQuartzHostedService(options =>
        {
            options.WaitForJobsToComplete = true;
        });

        services.ConfigureOptions<QuartzOptionsSetup>();

        return services;
    }
}