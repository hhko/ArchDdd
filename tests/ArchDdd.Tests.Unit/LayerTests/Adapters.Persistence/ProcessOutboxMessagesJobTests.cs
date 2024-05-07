using ArchDdd.Adapters.Persistence.BackgroundJobs;
using ArchDdd.Tests.Unit.Abstractions.Constants;
using NSubstitute;
using Quartz;

namespace ArchDdd.Tests.Unit.LayerTests.Adapters.Persistence;

[Trait(nameof(UnitTest), UnitTest.Persistence)]
public sealed class ProcessOutboxMessagesJobTests
{
    [Fact]
    public async Task ProcessOutboxMessagesJob_ShouldSucceed()
    {
        // Arrange
        var sut = new ProcessOutboxMessagesJob();

        // Act
        await sut.Execute(Substitute.For<IJobExecutionContext>());

        // Assert

    }
}
