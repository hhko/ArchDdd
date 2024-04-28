using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Tests.Unit.Abstractions.Utilities;
using System.Reflection;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.LayerTests.Domain.Abstractions;

[Trait(nameof(UnitTest), UnitTest.Domain)]
public sealed class ErrorTests
{
    private const string InvalidOperationExceptionMessage = "This was invalid operation";
    private const string ArgumentExceptionMessage = "Invalid argument";
    private const string NotFoundExceptionMessage = "Not found";

    //
    // 비교 메서드
    //

    [Fact]
    public void Equality_SameCodeAndMessage_ShouldBeSameObject()
    {
        // Arrange
        Error error1 = Error.New("code", "message");
        Error error2 = Error.New("code", "message");

        // Act & Assert
        EqualityTests.TestEqualObjects(error1, error2);
    }

    [Fact]
    public void Equality_DistinctCodeAndSameMessage_ShouldNotBeSameObject()
    {
        // Arrange
        Error error1 = Error.New("code1", "message");
        Error error2 = Error.New("code2", "message");

        // Act & Assert
        EqualityTests.TestUnequalObjects(error1, error2);
    }

    [Fact]
    public void Equality_SameCodeAndDistinctMessage_ShouldNotBeSameObject()
    {
        // Arrange
        Error error1 = Error.New("code", "message1");
        Error error2 = Error.New("code", "message2");

        // Act & Assert
        EqualityTests.TestUnequalObjects(error1, error2);
    }

    [Fact]
    public void Equality_ComparingWithNull()
    {
        // Arrange
        Error error = Error.ConditionNotSatisfiedError;

        EqualityTests.TestAgainstNull(error);
    }

    [Fact]
    public void Equality_ComparingWithAllNull()
    {
        // Arrange
        EqualityTests.TestAgainstNull<Error>();
    }

    //
    // 기본 메서드
    //

    [Fact]
    public void ThrowIfErrorNone_WhenErrorIsNone_ShouldThrowAnException()
    {
        // Arrange
        var error = Error.None;

        // Act
        var actual = FluentActions
            .Invoking(error.ThrowIfErrorNone);

        // Assert
        actual
            .Should().ThrowExactly<InvalidOperationException>()
            .Which
            .Message
            .Should().Be("Provided error is Error.None");
    }

    public static TheoryData<Error> PredefinedErrorTypes =>
        new()
        {
            Error.NullError,
            Error.ConditionNotSatisfiedError,
            Error.ValidationError
        };

    [Theory]
    [MemberData(nameof(PredefinedErrorTypes))]
    public void ThrowIfErrorNone_WhenErrorIsPredefinedErrorTypes_ShouldNotThrow(Error error)
    {
        // Act
        var actual = FluentActions
            .Invoking(error.ThrowIfErrorNone);

        // Assert
        actual.Should().NotThrow();
    }

    //
    // 생성 메서드: 예외
    //

    [Fact]
    public void FromException_WhenInnerExceptionIsNot_ShouldContainExceptionMessage()
    {
        // Arrange
        var invalidOperationException = new InvalidOperationException(
            message: InvalidOperationExceptionMessage);

        // Act
        var error = Error.FromException(invalidOperationException);

        // Assert
        error.Code.Should().Be($"{nameof(Exception)}.{nameof(InvalidOperationException)}");
        error.Message.Should().Contain(InvalidOperationExceptionMessage);
    }

    [Fact]
    public void FromException_WhenInnerExceptionIs_ShouldContainInnerExceptionMessage()
    {
        // Arrange
        var invalidOperationException = new InvalidOperationException(
            message: InvalidOperationExceptionMessage,
            innerException: new ArgumentException(ArgumentExceptionMessage));

        // Act
        var error = Error.FromException(invalidOperationException);

        // Assert
        error.Code.Should().Be($"{nameof(Exception)}.{nameof(InvalidOperationException)}");
        error.Message.Should().Contain(InvalidOperationExceptionMessage, ArgumentExceptionMessage);
    }

    [Fact]
    public void FromException_WhenAggregateExceptionHasOneInnerException_ShouldContainAllInnerExceptionsMessages()
    {
        // Arrange
        var aggregateException = new AggregateException(
            new InvalidOperationException(InvalidOperationExceptionMessage)
        );

        // Act
        var error = Error.FromException(aggregateException);

        // Assert
        error.Code.Should().Be($"{nameof(Exception)}.{nameof(AggregateException)}");
        error.Message.Should().ContainAll(InvalidOperationExceptionMessage);
    }

    [Fact]
    public void FromException_WhenAggregateExceptionHasManyInnerExceptions_ShouldContainAllInnerExceptionsMessages()
    {
        // Arrange
        var aggregateException = new AggregateException(
            new InvalidOperationException(InvalidOperationExceptionMessage),
            new ArgumentException(ArgumentExceptionMessage)
        );

        // Act
        var error = Error.FromException(aggregateException);

        // Assert
        error.Code.Should().Be($"{nameof(Exception)}.{nameof(AggregateException)}");
        error.Message.Should().ContainAll(InvalidOperationExceptionMessage, ArgumentExceptionMessage);
    }

    //
    // 필수 메서드: string 반환
    //
    
    [Fact]
    public void ReturnString_WhenImplicit_ShouldBeCode()
    {
        // Arrage
        Error error = Error.NullError;

        // Act
        string actual = error;

        // Assert
        actual.Should().Be(error.Code);
    }

    [Fact]
    public void ReturnString_WhenExplicit_ShouldBeMessage()
    {
        // Arrange
        Error error = Error.NullError;

        // Act
        string actual = error.ToString();

        // Assert
        actual.Should().Be(error.Message);
    }
}