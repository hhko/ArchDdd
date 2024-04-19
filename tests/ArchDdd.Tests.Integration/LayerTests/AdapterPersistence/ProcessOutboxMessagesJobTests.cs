//using Quartz.Impl;
//using Quartz;
//using static ArchDdd.Tests.Integration.Abstractions.Constants.Constants;
//using ArchDdd.Adapters.Persistence.BackgroundJobs;

//namespace ArchDdd.Tests.Integration.LayerTests.AdapterPersistence;

//[Trait(nameof(IntegrationTest), IntegrationTest.BackgroundJobs)]
//public class ProcessOutboxMessagesJobTests
//{
//    [Fact]
//    public async Task ProcessOutboxMessagesJob_ShouldSucceed()
//    {
//        //
//        // Arrange
//        //

//        // 스케줄러 생성
//        StdSchedulerFactory sf = new StdSchedulerFactory();
//        IScheduler scheduler = await sf.GetScheduler();
//        await scheduler.Clear();
//        await scheduler.ScheduleJob(
//            JobBuilder.Create<ProcessOutboxMessagesJob>()
//                .WithIdentity(nameof(ProcessOutboxMessagesJob))
//                .Build(),
//            TriggerBuilder.Create()
//                .WithIdentity(nameof(ProcessOutboxMessagesJob))
//                .WithSimpleSchedule(x => x
//                    .WithInterval(TimeSpan.FromSeconds(1))
//                    //.RepeatForever()
//                ).Build()
//        );

//        //
//        // Act
//        //
        
//        // 스케줄러 시작
//        await scheduler.Start();
        
//        // Job 실행까지 대기
//        //  - TestShutdownWithWaitIsClean
//        //  - https://github.com/quartznet/quartznet/blob/main/src/Quartz.Tests.Integration/RAMJobStoreTest.cs#L540
//        while ((await scheduler.GetCurrentlyExecutingJobs()).Count == 0)
//        {
//            await Task.Delay(50);
//        }

//        // 스케줄러 중지: Job 종료까지 대기
//        await scheduler.Shutdown(waitForJobsToComplete: true);

//        //
//        // Assert
//        //

//        // ...
//    }
//}
