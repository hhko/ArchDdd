using FluentAssertions;

namespace CleanDdd.Tests.Unit;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        Domain.ClassDomain c1 = new();

        // Act
        int actual = c1.Add(1, 6);

        // Assert
        actual.Should().Be(7);
    }
}