using ArchDdd.Adapters.Persistence.BackgroundJobs;
using NSubstitute;
using Quartz;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.LayerTests.Adapters.Persistence;

[Trait(nameof(UnitTest), UnitTest.Persistence)]
public class ProcessOutboxMessagesJobTests
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
