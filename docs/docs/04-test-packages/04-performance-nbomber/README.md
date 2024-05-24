# NBomber

```
dotnet run -c Release --project .\tests\ArchDdd.Tests.Performance\
  _   _   ____                        _                       ____
 | \ | | | __ )    ___    _ __ ___   | |__     ___   _ __    | ___|
 |  \| | |  _ \   / _ \  | '_ ` _ \  | '_ \   / _ \ | '__|   |___ \
 | |\  | | |_) | | (_) | | | | | | | | |_) | |  __/ | |       ___) |
 |_| \_| |____/   \___/  |_| |_| |_| |_.__/   \___| |_|      |____/

17:12:07 [INF] NBomber "5.6.0" started a new session: "2024-05-06_08.12.18_session_acd46090"
17:12:07 [INF] NBomber started as single node
17:12:07 [INF] License validation....
17:12:07 [WRN] THIS VERSION IS FREE ONLY FOR PERSONAL USE. You can't use it for an organization.
17:12:07 [INF] Reports folder: "C:\Workspace\Github\archddd\tests\ArchDdd.Tests.Performance\bin\Release\net8.0\reports\2024-05-06_08.12.18_session_acd46090"
17:12:07 [INF] Plugins: no plugins were loaded
17:12:07 [INF] Reporting sinks: no reporting sinks were loaded
17:12:07 [INF] Starting init...
17:12:07 [INF] Target scenarios: "hello_world_scenario"
17:12:07 [INF] Init finished
17:12:07 [INF] Starting bombing...
17:12:38 [INF] Waiting on scenarios completion...
17:12:42 [INF] Stopping scenarios...
17:12:42 [INF] Calculating final statistics...

─────────────────────────────────────────────────────────────────────── test info ────────────────────────────────────────────────────────────────────────
test suite: nbomber_default_test_suite_name
test name: nbomber_default_test_name
session id: 2024-05-06_08.12.18_session_acd46090

───────────────────────────────────────────────────────────────────── scenario stats ─────────────────────────────────────────────────────────────────────
scenario: hello_world_scenario
  - ok count: 4500
  - fail count: 0
  - all data: 0 MB
  - duration: 00:00:30

load simulations:
  - inject, rate: 150, interval: 00:00:01, during: 00:00:30

┌────────────────────┬────────────────────────────────────────────────────────────────────┐
│               step │ ok stats                                                           │
├────────────────────┼────────────────────────────────────────────────────────────────────┤
│               name │ global information                                                 │
│      request count │ all = 4500, ok = 4500, RPS = 150                                   │
│            latency │ min = 498.78 ms, mean = 509.94 ms, max = 543.5 ms, StdDev = 5.51   │
│ latency percentile │ p50 = 512.51 ms, p75 = 514.05 ms, p95 = 515.07 ms, p99 = 515.84 ms │
└────────────────────┴────────────────────────────────────────────────────────────────────┘


17:12:43 [INF] Reports saved in folder: "C:\Workspace\Github\archddd\reports\2024-05-06_08.12.18_session_acd46090"
17:12:43 [WRN] THIS VERSION IS FREE ONLY FOR PERSONAL USE. You can't use it for an organization.
```
```cs
public void Run()
{
    var scenario = Scenario.Create("hello_world_scenario", async context =>
    {
        // you can define and execute any logic here,
        // for example: send http request, SQL query etc
        // NBomber will measure how much time it takes to execute your logic
        await Task.Delay(500);

        return Response.Ok();
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
```