using Helloworld.Adapters.Infrastructure.Abstractions.Registrations;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Metrics;

namespace Helloworld.Tests.Unit.LayerTests.Adapters.Infrastructure;

public class RegistrationsTests
{
    [Theory]
    [InlineData(typeof(MeterProvider), null, ServiceLifetime.Singleton)]
    public void GivenDependenciesExists_WhenServiceIsRegistered_ThenServiceIsRegistered(Type interfaceType, Type? classType, ServiceLifetime serviceLifetime)
    {
        // Arrange
        IServiceCollection serviceCollection = new ServiceCollection();
        IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

        // Act
        var serviceType = serviceProvider.GetService(interfaceType);

        // Assert
        Assert.NotNull(serviceType);

        var serviceDescriptor = serviceCollection.SingleOrDefault(
            d => d.ServiceType == interfaceType &&
                 d.ImplementationType == classType &&
                 d.Lifetime == serviceLifetime);

        Assert.NotNull(serviceDescriptor);
    }
}
