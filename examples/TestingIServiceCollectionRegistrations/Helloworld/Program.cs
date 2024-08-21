using Helloworld.Adapters.Infrastructure.Abstractions.Registrations;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Metrics;

var services = new ServiceCollection();
services.RegisterAdaptersInfrastructureLayer();
var serviceProvider = services.BuildServiceProvider();

MeterProvider meterProvider = serviceProvider.GetService<MeterProvider>()!;

Console.WriteLine("Hello, World!");
