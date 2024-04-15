using Quartz;

namespace ArchDdd.Adapters.Persistence.BackgroundJobs;

public class ProcessOutboxMessagesJob
    : IJob
    , IDisposable
{
    public void Dispose()
    {
    }

    public Task Execute(IJobExecutionContext context)
    {
        return Task.CompletedTask;
    }
}
