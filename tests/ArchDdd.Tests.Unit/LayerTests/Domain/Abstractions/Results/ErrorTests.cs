using ArchDdd.Domain.Abstractions.Results;
using System.Collections;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.LayerTests.Domain.Abstractions;

[Trait(nameof(UnitTest), UnitTest.Domain)]
public class ErrorTests
{
    private const string InvalidOperationExceptionMessage = "This was invalid operation";
    private const string ArgumentExceptionMessage = "Invalid argument";
    private const string NotFoundExceptionMessage = "Not found";

    ////
    //// 비교 메서드
    ////

    //[Fact]
    //public void Equality_SameCodeAndMessage_ShouldBeSameObject()
    //{
    //    // Arrange
    //    Error error1 = Error.New("code", "message");
    //    Error error2 = Error.New("code", "message");

    //    // Act & Assert
    //    EqualityTests.TestEqualObjects(error1, error2);
    //}

    //[Fact]
    //public void Equality_DistinctCodeAndSameMessage_ShouldNotBeSameObject()
    //{
    //    // Arrange
    //    Error error1 = Error.New("code1", "message");
    //    Error error2 = Error.New("code2", "message");

    //    // Act & Assert
    //    EqualityTests.TestUnequalObjects(error1, error2);
    //}

    //[Fact]
    //public void Equality_SameCodeAndDistinctMessage_ShouldNotBeSameObject()
    //{
    //    // Arrange
    //    Error error1 = Error.New("code", "message1");
    //    Error error2 = Error.New("code", "message2");

    //    // Act & Assert
    //    EqualityTests.TestUnequalObjects(error1, error2);
    //}

    //[Fact]
    //public void Equality_ComparingWithNull()
    //{
    //    // Arrange
    //    Error error = Error.ConditionNotSatisfiedError;

    //    EqualityTests.TestAgainstNull(error);
    //}

    //[Fact]
    //public void Equality_ComparingWithAllNull()
    //{
    //    // Arrange
    //    EqualityTests.TestAgainstNull<Error>();
    //}

    //
    // 기본 메서드
    //

    [Fact]
    public void ErrorIsNone_ThrowIfErrorNone_ShouldRasieAnException()
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

    // xUnit1044 Info   Avoid using TheoryData type arguments that are not serializable
    // xUnit1045 Info   Avoid using TheoryData type arguments that might not be serializable
    // xUnit1046 Info   Avoid using TheoryDataRow arguments that are not serializable
    // xUnit1047 Info   Avoid using TheoryDataRow arguments that might not be serializable
    [Theory]
    [ClassData(typeof(PredefinedErrorTypes))]
    public void ErrorIsNotNone_ThrowIfErrorNone_ShouldNotRaiseAnyExceptions(Error error)
    {
        // Act
        var actual = FluentActions
            .Invoking(error.ThrowIfErrorNone);

        // Assert
        actual.Should().NotThrow();
    }

    public class PredefinedErrorTypes : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { Error.NullError };
            yield return new object[] { Error.ConditionNotSatisfiedError };
            yield return new object[] { Error.ValidationError };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //
    // 생성 메서드: 예외
    //

    [Fact]
    public void InnerExceptionsAreNot_FromException_ShouldHaveMessage()
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
    public void InnerExceptionsAre_FromException_ShouldHaveMessageAndInnerExceptionMessages()
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
    public void AggregateExceptionIsInnerException_FromException_ShouldHaveInnerExceptionsMessage()
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
    public void AggregateExceptionAreInnerExceptions_FromException_ShouldHaveInnerExceptionsMessages()
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
    // 변환 메서드 | string
    //

    [Fact]
    public void ErrorIs_ReturnImplicitString_ShouldBeCode()
    {
        // Arrage
        Error error = Error.NullError;

        // Act
        string actual = error;

        // Assert
        actual.Should().Be(error.Code);
    }

    [Fact]
    public void ErrorIs_REturnExplicitString_ShouldBeMessage()
    {
        // Arrange
        Error error = Error.NullError;

        // Act
        string actual = error.ToString();

        // Assert
        actual.Should().Be(error.Message);
    }
}
