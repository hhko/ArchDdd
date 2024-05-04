using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.Net;
using static ArchDdd.Tests.Integration.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Integration.ControllersUnderTest.HelloControllers;

//[Trait(nameof(IntegrationTest), IntegrationTest.WebApi)]
//public class HelloControllerTests_Step1_ExplicitCreation
//{
//    [Fact]
//    public async Task WebApi_GetGretting_ShouldBeTrue()
//    {
//        // Arrange
//        await using var application = new WebApplicationFactory<Program>();

//        // 1. CreateClient 메서드를 호출하면 Program 인스턴스를 생성합니다.
//        // 2. CreateClient N번 호출해도 Program 인스턴스는 1번만 생성합니다.
//        using var sut = application.CreateClient();
//        //using var sut2 = application.CreateClient();

//        // Act
//        var actual = await sut.GetAsync("/api/greeting/Foo");

//        // Assert
//        actual.StatusCode.Should().Be(HttpStatusCode.OK);
//    }
//}

//[Trait(nameof(IntegrationTest), IntegrationTest.WebApi)]
//public class HelloControllerTests_Step2_ClassFixture
//    : IClassFixture<WebApplicationFactory<Program>>
//    , IDisposable
//{
//    readonly HttpClient _sut;

//    public HelloControllerTests_Step2_ClassFixture(WebApplicationFactory<Program> app)
//    {
//        _sut = app.CreateClient();
//    }

//    public void Dispose()
//    {
//    }

//    [Fact]
//    public async Task WebApi_GetGretting_ShouldBeTrue()
//    {
//        // Act
//        var actual = await _sut.GetAsync("/api/greeting/Foo");

//        // Assert
//        actual.StatusCode.Should().Be(HttpStatusCode.OK);
//    }

//    [Fact]
//    public void Others()
//    {

//    }
//}


public class ApiWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(config =>
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();

            // 
            var path = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            builder.AddJsonFile(Path.Combine(path, IntegrationTest.AppsettingsTestJson));

            config.AddConfiguration(builder.Build());
        });

        // ConfigureServices 호출 후 ConfigureTestServices이 호출되어 DI을 재정의할 수 있습니다.
        builder.ConfigureTestServices(services =>
        {
            //services.AddTransient<IWeatherForecastConfigService, WeatherForecastConfigMock>();
        });
    }
}

[Trait(nameof(IntegrationTest), IntegrationTest.WebApi)]
public class HelloControllerTests_Step3_OwnClassFixture 
    : IClassFixture<ApiWebApplicationFactory>
{
    readonly HttpClient _sut;

    public HelloControllerTests_Step3_OwnClassFixture(ApiWebApplicationFactory application)
    {
        _sut = application.CreateClient();
    }

    [Fact]
    public async Task WebApi_GetGretting_ShouldBeTrue()
    {
        // Act
        var actual = await _sut.GetAsync("/api/greeting/Foo");

        // Assert
        actual.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}

//dotnet test --filter Category = Integration
//dotnet test --filter Category!=Integration