using ArchDdd.Domain.Abstractions.Results;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.LayerTests.Domain.Abstractions;

[Trait(nameof(UnitTest), UnitTest.Domain)]
public class ResultTests
{
    [Fact]
    public void TwoSuccessResults_ShouldReferTheSameCachedResultInstance_WhenTwoNonGenericSuccessResultsAreCreated()
    {
        //Arrange
        var firstResult = Result.Success();
        var secondResult = Result.Success();

        //Act
        var actual = ReferenceEquals(firstResult, secondResult);

        //Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void GettingValueFromGenericResult_ShouldThrowAnException_WhenResultIsFailureStringResult()
    {
        // Arrange
        var result = Result.Failure<string>(Error.ConditionNotSatisfiedError);
        string GetValueFromFailureResult() => result.Value;

        // Act
        var actual = FluentActions.Invoking(GetValueFromFailureResult);

        // Assert
        actual
            .Should().ThrowExactly<InvalidOperationException>()
            .Which
            .Message
            .Should().Be("The value of a failure result can not be accessed. Type 'System.String'.");
    }

    [Fact]
    public void GettingValueFromGenericResult_ShouldThrowAnException_WhenResultIsFailureIntResult()
    {
        // Arrange
        var result = Result.Failure<int>(Error.ConditionNotSatisfiedError);
        var action = () => result.Value;

        // Act
        var actual = FluentActions.Invoking(action);
        
        // Assert
        actual
            .Should().ThrowExactly<InvalidOperationException>()
            .Which
            .Message
            .Should().Be("The value of a failure result can not be accessed. Type 'System.Int32'.");
    }
}
