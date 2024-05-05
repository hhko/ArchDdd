# 통합 테스트

## 패키지
- Microsoft.AspNetCore.Mvc.Testing

## 테스트 단위
```cs
public class HelloControllerTests_Step1_ExplicitCreation
{
    [Fact]
    public async Task WebApi_GetGretting_ShouldBeTrue()
    {
         Arrange
        await using var application = new WebApplicationFactory<Program>();

        // 1. CreateClient 메서드를 호출하면 Program 인스턴스를 생성합니다.
        // 2. CreateClient N번 호출해도 Program 인스턴스는 1번만 생성합니다.
        using var sut = application.CreateClient();
        using var sut2 = application.CreateClient();

         Act
        var actual = await sut.GetAsync("/api/greeting/Foo");

         Assert
        actual.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
```

<br/>

## 클래스 단위
```cs
public class HelloControllerTests_Step2_ClassFixture
    : IClassFixture<WebApplicationFactory<Program>>
    , IDisposable
{
    readonly HttpClient _sut;

    public HelloControllerTests_Step2_ClassFixture(WebApplicationFactory<Program> app)
    {
        _sut = app.CreateClient();
    }

    public void Dispose()
    {
    }

    [Fact]
    public async Task WebApi_GetGretting_ShouldBeTrue()
    {
         Act
        var actual = await _sut.GetAsync("/api/greeting/Foo");

         Assert
        actual.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public void Others()
    {

    }
}
```

<br/>

## 클래스 단위(자신 클래스)
```cs
public class ApiWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(config =>
        {
            var path = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;

            IConfiguration configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile(IntegrationTest.AppsettingsTestJson)
                .Build();

            er.AddJsonFile(Path.Combine(path, IntegrationTest.AppsettingsTestJson));

            config.AddConfiguration(configuration);
        });

        // ConfigureServices 호출 후 ConfigureTestServices이 호출되어 DI을 재정의할 수 있습니다.
        builder.ConfigureTestServices(services =>
        {
            services.AddTransient<IWeatherForecastConfigService, WeatherForecastConfigMock>();
        });
    }
}

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
         Act
        var actual = await _sut.GetAsync("/api/greeting/Foo");

         Assert
        actual.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
```
- dotnet test --filter Category = Integration
- dotnet test --filter Category != Integration

<br/>

## 어셈블리
```cs
// WebAppFactoryCollection          : Collection 사용
// WebAppFactoryCollectionFixture   : Collection 정의
// WebAppFactoryFixture             : Fixture

[CollectionDefinition(CollectionName.WebAppFactoryCollection)]
public sealed class WebAppFactoryCollectionFixture
    : ICollectionFixture<WebAppFactoryFixture>
{
}

public sealed class WebAppFactoryFixture
    : WebApplicationFactory<Program>
    , IAsyncLifetime
{
    // ...
}

[Collection(CollectionName.WebAppFactoryCollection)]
public sealed class UserControllerTests
{
    public UserControllerTests(WebAppFactoryFixture webAppFactory)
    { 
        _sut = webAppFactory.CreateClient();
    }

    // ...
}
```

