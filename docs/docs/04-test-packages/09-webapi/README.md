---
sidebar_position: 9
---

# Microsoft.AspNetCore.Mvc.Testing

## WebApi 호출
```shell
curl -X POST --location "https://localhost:7230/people" \
    -H "Content-Type: application/json" \
    -d "{ \"FirstName\": \"Maarten\" }"

Invoke-WebRequest `
    -Uri https://localhost:7230/people `
    -Method Post `
    -ContentType "application/json" `
    -Body '{"FirstName": "Maarten"}'
```

## WebApplicationFactory 생성 방법
### 테스트 단위
```cs
public class HelloControllerTests_Step1_ExplicitCreation
{
    [Fact]
    public async Task WebApi_GetGretting_ShouldBeTrue()
    {
        // Arrange
        await using var application = new WebApplicationFactory<Program>();

        // 1. CreateClient 메서드를 호출하면 Program 인스턴스를 생성합니다.
        // 2. CreateClient N번 호출해도 Program 인스턴스는 1번만 생성합니다.
        using var sut = application.CreateClient();
        using var sut2 = application.CreateClient();

        // Act
        var actual = await sut.GetAsync("/api/greeting/Foo");

        // Assert
        actual.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
```

### 클래스 1개 단위
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
        // Act
        var actual = await _sut.GetAsync("/api/greeting/Foo");

        // Assert
        actual.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public void Others()
    {

    }
}
```

### 클래스 1개 단위(자신 클래스)
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
        // Act
        var actual = await _sut.GetAsync("/api/greeting/Foo");

        // Assert
        actual.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
```
- dotnet test --filter Category = Integration
- dotnet test --filter Category != Integration

### 클래스 N개 단위
```cs
// WebAppFactoryCollection          : Collection 사용
// WebAppFactoryCollectionFixture   : CollectionDefinition 정의
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

<br/>

## 디버깅 환경
### VS 디버깅일 때 Web Browser 활성화 비활성화
- launchSettings.json
  ```
  {
    "profiles": {
      "Api": {
        "launchBrowser": false,
      }
    }
  }
  ```

### REST Client VS 확장 도구
- 확장 도구: https://github.com/madskristensen/RestClientVS
- 단축키: Ctrl+Alt+S

```http
@hostname=localhost
@port=5168
@host = http://{{hostname}}:{{port}}
@contentType = application/json

### GET
GET {{host}}/api/students/1

### PUT & POST
PUT {{host}}/api/students/2
Content-Type:{{contentType}}

{
    "name": "foo",
    "address": "hello world 1004"
}
```
