using FluentAssertions;

namespace CleanDdd.Tests.Unit;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Domain.Class1 c1 = new();

        c1.Should().NotBeNull();
    }
}