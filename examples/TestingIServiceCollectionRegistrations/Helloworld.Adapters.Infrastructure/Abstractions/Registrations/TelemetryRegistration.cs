using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Metrics;

namespace Helloworld.Adapters.Infrastructure.Abstractions.Registrations;

internal static class TelemetryRegistration
{
    internal static IServiceCollection RegisterTelemetry(this IServiceCollection services)
    {
        // OpenTelemetry.Extensions.Hosting
        // https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry.Extensions.Hosting
        services.AddOpenTelemetry()
            .WithMetrics(builder =>
            {
                //builder.AddHttpClientInstrumentation();
                //builder.AddAspNetCoreInstrumentation();
                //builder.AddMeter("MyApplicationMetrics");

                // OpenTelemetry.Instrumentation.Runtime
                // https://github.com/open-telemetry/opentelemetry-dotnet-contrib/tree/main/src/OpenTelemetry.Instrumentation.Runtime
                builder.AddRuntimeInstrumentation();

                // OpenTelemetry.Exporter.OpenTelemetryProtocol
                // https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/src/OpenTelemetry.Exporter.OpenTelemetryProtocol
                builder.AddOtlpExporter(options => options.Endpoint = new Uri("http://localhost:4317"));
            });

        return services;
    }
}
