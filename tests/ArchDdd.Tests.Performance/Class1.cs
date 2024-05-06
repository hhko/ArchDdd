using NBomber.CSharp;
using System.Net.Http;

// -------------------------------
// ----- Hello World examples -----
// -------------------------------
new HelloWorldExample().Run();
// new ScenarioWithInit().Run();
// new ScenarioWithSteps().Run();
// new StepsShareData().Run();
// new LoggerExample().Run();

// ----- Load Simulations -----
// new ParallelScenarios().Run();
// new ScenarioInjectRate().Run();
// new ScenarioKeepConstant().Run();
// new DelayedScenarioStart().Run();
// new ScenarioTotalIterations().Run();

// new ScenarioWithTimeout().Run();
// new ScenarioWithStepRetry().Run();
// new EmptyScenario().Run();

public class HelloWorldExample
{
    public void Run()
    {
        using var httpClient = new HttpClient();

        var scenario = Scenario.Create("hello_world_scenario", async context =>
        {
            //// you can define and execute any logic here,
            //// for example: send http request, SQL query etc
            //// NBomber will measure how much time it takes to execute your logic
            //await Task.Delay(500);

            //return Response.Ok();

            var response = await httpClient.GetAsync("http://localhost:54011/api/greeting/foo");

            return response.IsSuccessStatusCode
                ? Response.Ok()
                : Response.Fail();
        })
        .WithoutWarmUp()
        .WithLoadSimulations(
            Simulation.Inject(rate: 150,
                              interval: TimeSpan.FromSeconds(1),
                              during: TimeSpan.FromSeconds(30)) // keep injecting with rate 150
        );

        NBomberRunner
            .RegisterScenarios(scenario)
            .Run();
    }
}