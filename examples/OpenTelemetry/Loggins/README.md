## 목표
- OpenTelemetry와 Serilog 통합
  - **로그**: Microsoft
    ```
    ILogger<Foo> logger
    ```
  - **콘솔**: Serilog
    ```
    .WriteTo.Console()          // Serilog
    .AddConsoleExporter()       // OpenTelemetry
    ```
  - **파일**: Serilog
    ```
    .WriteTo.File( ... )
    ```
  - **전송**: OpenTelemetry
    ```
    .AddOtlpExporter( ... )
    ```
- `OpenTelemetry은 OpenTelemetry.Exporter.File을 제공하지 않습니다.`

```shell
dotnet add package Microsoft.Extensions.Hosting --version 8.0.1

dotnet add package OpenTelemetry.Extensions.Hosting --version 1.9.0
dotnet add package OpenTelemetry.Exporter.Console --version 1.9.0
dotnet add package OpenTelemetry.Exporter.OpenTelemetryProtocol --version 1.9.0

dotnet add package Serilog.Extensions.Hosting --version 8.0.0
dotnet add package Serilog.Sinks.Console --version 6.0.0
dotnet add package Serilog.Sinks.File --version 6.0.0
```

```cs
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using Serilog;

Console.WriteLine("Hello, World!");

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// TODO: builder.Logging. ... 개선
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();
builder.Logging.AddOpenTelemetry(configure =>
{
    // TODO: OpenTelemetry 로그 설정 이해
    configure.IncludeFormattedMessage = true;
    configure.IncludeScopes = true;
    configure.ParseStateValues = true;
    //configure.AddConsoleExporter();

    // TODO: 로그 전송 컨테이너
    configure.AddOtlpExporter(options =>
    {
        options.Endpoint = new Uri("http://localhost:4317");
        options.Protocol = OtlpExportProtocol.HttpProtobuf;
    });
});

builder.Services.AddTransient<Foo>();

using IHost host = builder.Build();

Foo foo = host.Services.GetRequiredService<Foo>();

await host.RunAsync();

public class Foo
{
    public Foo(ILogger<Foo> logger)
    {
        logger.LogInformation("{xyz} is good.", "Foo");
    }
}

// TODO: Serilog 로그 환경 설정
// TODO: Serilog 필수 패키지 ---> OpenTelemetry로 모든 구조적 정보가 전송되는가?
//  - 프로세스
//  - 데이터 제한
//  - ...

// TODO: 구조적 로그 사전 정의(Microsoft)
```