namespace ArchDdd.Tests.Integration.Abstractions.WebApi;

public abstract class ControllerTestsBase
{
    protected HttpClient _sut;

    public ControllerTestsBase(WebAppFactoryFixture webAppFactory)
    {
        // 1. CreateClient 메서드를 호출하면 Program 인스턴스를 생성합니다.
        // 2. CreateClient N번 호출해도 Program 인스턴스는 1번만 생성합니다.
        _sut = webAppFactory.CreateClient();
    }
}
