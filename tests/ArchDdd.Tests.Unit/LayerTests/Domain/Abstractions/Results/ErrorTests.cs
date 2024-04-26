using ArchDdd.Domain.Abstractions.Results;
using System.Reflection;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.LayerTests.Domain.Abstractions;

[Trait(nameof(UnitTest), UnitTest.Domain)]
public class ErrorTests
{
    private const string InvalidOperationExceptionMessage = "This was invalid operation";
    private const string ArgumentExceptionMessage = "Invalid argument";
    private const string NotFoundExceptionMessage = "Not found";

    #region ThrowIfErrorNone

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

    #endregion

    #region FromException

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

    #endregion

    //private sealed class TestSet
    //{
    //    public sealed class Email
    //    {
    //        public static readonly Error Empty = Error.New(
    //            $"{nameof(Email)}.{nameof(Empty)}",
    //            $"{nameof(Email)} is empty.");
    //    }
    //}

    //[Fact]
    //public void New_When_Should()
    //{
    //    // Act
    //    var actual = TestSet.Email.Empty;

    //    // Assert
    //    actual.Code.Should().Be($"{nameof(TestSet.Email)}.{nameof(TestSet.Email.Empty)}");
    //    actual.Message.Should().Contain($"{nameof(TestSet.Email)}");
    //}

    //[Fact]
    //public void Compare_Predefined_Same()
    //{
    //    Error errorFirst = Error.None;
    //    Error errorSecond = Error.None;

    //    var actual = errorFirst == errorSecond;

    //    actual.Should().BeTrue();
    //}

    //[Fact]
    //public void Compare_Predefined_NotSame()
    //{
    //    Error errorFirst = Error.None;
    //    Error errorSecond = Error.ValidationError;

    //    var actual = errorFirst != errorSecond;

    //    actual.Should().BeTrue();
    //}

    //[Fact]
    //public void Compare_New()
    //{
    //    Error errorFirst = Error.New("Code", "Message");
    //    Error errorSecond = Error.New("Code", "Message");

    //    var actual = errorFirst == errorSecond;

    //    actual.Should().BeTrue();
    //}

    //[Fact]
    //public void Compare_New_NotSameCode()
    //{
    //    Error errorFirst = Error.New("Code", "Message");
    //    Error errorSecond = Error.New("CodeNot", "Message");

    //    var actual = errorFirst != errorSecond;

    //    actual.Should().BeTrue();
    //}

    //[Fact]
    //public void Compare_New_NotSameMessage()
    //{
    //    Error errorFirst = Error.New("Code", "Message");
    //    Error errorSecond = Error.New("Code", "MessageNot");

    //    var actual = errorFirst != errorSecond;

    //    actual.Should().BeTrue();
    //}

    //[Fact]
    //public void Compare_New_NotSameAll()
    //{
    //    Error errorFirst = Error.New("Code", "Message");
    //    Error errorSecond = Error.New("CodeNot", "MessageNot");

    //    var actual = errorFirst != errorSecond;

    //    actual.Should().BeTrue();
    //}

    //[Fact]
    //public void CompareEqualsError_WhenNull()
    //{
    //    Error errorFirst = Error.NullError;
    //    Error? errorSecond = null;

    //    var actual = errorFirst.Equals(errorSecond);

    //    actual.Should().BeFalse();
    //}

    //[Fact]
    //public void CompareEqualsObject_WhenNull()
    //{
    //    Error errorFirst = Error.NullError;
    //    object? errorSecond = null;

    //    var actual = errorFirst.Equals(errorSecond);

    //    actual.Should().BeFalse();
    //}

    //[Fact]
    //public void CompareEqualsObject_When()
    //{
    //    Error errorFirst = Error.NullError;
    //    string errorSecond = "fun.";

    //    var actual = errorFirst.Equals(errorSecond);

    //    actual.Should().BeFalse();
    //}

    //[Fact]
    //public void CompareEqualsObject_WhenError()
    //{
    //    Error errorFirst = Error.NullError;
    //    Error errorSeconde = Error.ValidationError;

    //    var actual = errorFirst.Equals(errorSeconde);

    //    actual.Should().BeFalse();
    //}

    //[Fact]
    //public void Compare_Null_All()
    //{
    //    var actual = (Error?)null == (Error?)null;

    //    actual.Should().BeTrue();
    //}

    //[Fact]
    //public void Compare_Null_First()
    //{
    //    Error error = Error.NullError;

    //    var actual = (Error?)null == error;

    //    actual.Should().BeFalse();
    //}

    //[Fact]
    //public void Compare_Null_Second()
    //{
    //    Error error = Error.NullError;

    //    var actual = error == (Error?)null;

    //    actual.Should().BeFalse();
    //}



    //[Fact]
    //public void Equality_WhenSameCodeAndMessage_ShouldBeTrue()
    //{
    //    ////Vehicle vehicle1 = new Vehicle("Renault", "Fluence", 2011);
    //    ////Vehicle vehicle2 = new Vehicle("Renault", "Fluence", 2012);
    //    //Error error1 = Error.New("Code", "Message");
    //    //Error error2 = Error.New("Code", "Message");


    //    // EqualityTests.TestEqualObjects(error1, error2);

    //    EqualityTests.TestEqualObjects(null, null);
    //}

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
}

public static class EqualityTests
{
    private struct TestResult
    {
        public bool IsSuccess { get; set; }
        public string FailureMessage { get; set; }

        public static TestResult CreateSuccess()
        {
            return new TestResult()
            {
                IsSuccess = true
            };
        }

        public static TestResult CreateFailure(string message)
        {
            return new TestResult()
            {
                IsSuccess = false,
                FailureMessage = message
            };
        }
    }

    public static void TestEqualObjects<T>(T obj1, T obj2)
    {
        ThrowIfAnyIsNull(obj1, obj2);

        IList<TestResult> testResults = new List<TestResult>()
        {
            // GetHashCode
            TestGetHashCodeOnEqualObjects<T>(obj1, obj2),

            // Other Type
            TestEqualsReceivingNonNullOfOtherType<T>(obj1),

            // Equals(object?)
            TestEquals<T>(obj1, obj2, true),

            // Equals<T>(T)
            TestEqualsOfT<T>(obj1, obj2, true),

            // operator ==
            TestEqualityOperator<T>(obj1, obj2, true),

            // operator !=
            TestInequalityOperator<T>(obj1, obj2, false)
        };

        AssertAllTestsHavePassed(testResults);
    }

    public static void TestUnequalObjects<T>(T obj1, T obj2)
    {
        ThrowIfAnyIsNull(obj1, obj2);

        IList<TestResult> testResults = new List<TestResult>()
        {
            // Other Type
            TestEqualsReceivingNonNullOfOtherType<T>(obj1),

            // Equals(object?)
            TestEquals<T>(obj1, obj2, false),

            // Equals<T>(T)
            TestEqualsOfT<T>(obj1, obj2, false),

            // operator ==
            TestEqualityOperator<T>(obj1, obj2, false),

            // operator !=
            TestInequalityOperator<T>(obj1, obj2, true)
        };

        AssertAllTestsHavePassed(testResults);
    }

    public static void TestAgainstNull<T>(T obj)
    {
        ThrowIfAnyIsNull(obj);

        IList<TestResult> testResults = new List<TestResult>()
        {
            // Equals(object?)
            TestEqualsReceivingNull<T>(obj),

            // Equals<T>(T)
            TestEqualsOfTReceivingNull<T>(obj),

            // operator ==
            TestEqualityOperatorReceivingNull<T>(obj, false),

            // operator !=
            TestInequalityOperatorReceivingNull<T>(obj, true),
        };

        AssertAllTestsHavePassed(testResults);
    }

    public static void TestAgainstNull<T>()
    {
        IList<TestResult> testResults = new List<TestResult>()
        {
            // operator ==
            TestEqualityOperatorReceivingNull<T>(true),

            // operator !=
            TestInequalityOperatorReceivingNull<T>(false),
        };

        AssertAllTestsHavePassed(testResults);
    }

    private static TestResult TestGetHashCodeOnEqualObjects<T>(T obj1, T obj2) 
    {
        return SafeCall("GetHashCode", () =>
        {
            if (obj1.GetHashCode() != obj2.GetHashCode())
                return TestResult.CreateFailure("GetHashCode of equal objects returned different values.");

            return TestResult.CreateSuccess();
        });
    }

    private static TestResult TestEqualsReceivingNonNullOfOtherType<T>(T obj)
    {
        return SafeCall("Equals", () =>
        {
            if (obj.Equals(new object()))
                return TestResult.CreateFailure("Equals returned true when comparing with object of a different type.");

            return TestResult.CreateSuccess();
        });
    }

    private static TestResult TestEqualsReceivingNull<T>(T obj)
    {
        if (typeof(T).IsClass)
            return TestEquals<T>(obj, default(T), false);

        return TestResult.CreateSuccess();
    }

    private static TestResult TestEqualsOfTReceivingNull<T>(T obj)
    {
        if (typeof(T).IsClass)
            return TestEqualsOfT<T>(obj, default(T), false);

        return TestResult.CreateSuccess();
    }

    private static TestResult TestEquals<T>(T obj1, T obj2, bool expectedEqual)
    {
        return SafeCall("Equals", () =>
        {
            if (obj1.Equals((object)obj2) != expectedEqual)
            {
                return TestResult.CreateFailure(string.Format(
                    "Equals returns {0} on {1}equal objects.",
                        !expectedEqual,
                        expectedEqual 
                            ? ""
                            : "non-"));
            }

            return TestResult.CreateSuccess();
        });
    }

    private static TestResult TestEqualsOfT<T>(T obj1, T obj2, bool expectedEqual)
    {
        if (obj1 is IEquatable<T> equatable)
            return TestEqualsOfTOnIEquatable<T>(equatable, obj2, expectedEqual);

        return TestResult.CreateSuccess();
    }

    private static TestResult TestEqualsOfTOnIEquatable<T>(IEquatable<T> obj1, T obj2, bool expectedEqual)
    {
        return SafeCall("Strongly typed Equals", () =>
        {
            if (obj1.Equals(obj2) != expectedEqual)
            {
                return TestResult.CreateFailure(string.Format(
                    "Strongly typed Equals returns {0} on {1}equal objects.",
                        !expectedEqual,
                        expectedEqual 
                            ? ""
                            : "non-"));
            }

            return TestResult.CreateSuccess();
        });
    }

    private static TestResult TestEqualityOperatorReceivingNull<T>(T? obj, bool expectedEqual)
    {
        if (typeof(T).IsClass)
            return TestEqualityOperator<T>(obj, default(T), expectedEqual);

        return TestResult.CreateSuccess();
    }

    private static TestResult TestEqualityOperatorReceivingNull<T>(bool expectedEqual)
    {
        if (typeof(T).IsClass)
            return TestEqualityOperator<T>(default(T), default(T), expectedEqual);

        return TestResult.CreateSuccess();
    }

    private static TestResult TestEqualityOperator<T>(T? obj1, T? obj2, bool expectedEqual)
    {
        MethodInfo? equalityOperator = GetEqualityOperator<T>();
        if (equalityOperator == null)
            return TestResult.CreateFailure("Type does not override equality operator.");

        return TestEqualityOperator<T>(obj1, obj2, expectedEqual, equalityOperator);
    }

    private static TestResult TestEqualityOperator<T>(T? obj1, T? obj2, bool expectedEqual, MethodInfo equalityOperator)
    {
        return SafeCall("Operator ==", () =>
        {
            bool equal = (bool)equalityOperator.Invoke(null, [obj1, obj2])!;
            if (equal != expectedEqual)
            {
                return TestResult.CreateFailure(string.Format(
                    "Equality operator returned {0} on {1}equal objects.",
                        equal,
                        expectedEqual 
                            ? "" 
                            : "non-"));
            }

            return TestResult.CreateSuccess();
        });
    }

    private static TestResult TestInequalityOperatorReceivingNull<T>(T obj, bool expectedEqual)
    {
        if (typeof(T).IsClass)
            return TestInequalityOperator<T>(obj, default(T), expectedEqual);

        return TestResult.CreateSuccess();
    }

    private static TestResult TestInequalityOperatorReceivingNull<T>(bool expectedEqual)
    {
        if (typeof(T).IsClass)
            return TestInequalityOperator<T>(default(T), default(T), expectedEqual);

        return TestResult.CreateSuccess();
    }

    private static TestResult TestInequalityOperator<T>(T obj1, T obj2, bool expectedUnequal)
    {
        MethodInfo? inequalityOperator = GetInequalityOperator<T>();
        if (inequalityOperator == null)
            return TestResult.CreateFailure("Type does not override inequality operator.");

        return TestInequalityOperator<T>(obj1, obj2, expectedUnequal, inequalityOperator);
    }

    private static TestResult TestInequalityOperator<T>(T obj1, T obj2, bool expectedUnequal, MethodInfo inequalityOperator)
    {
        return SafeCall("Operator !=", () =>
        {
            bool unequal = (bool)inequalityOperator.Invoke(null, [obj1, obj2])!;
            if (unequal != expectedUnequal)
            {
                return TestResult.CreateFailure(string.Format(
                    "Inequality operator retrned {0} when comparing {1}equal objects.",
                        unequal,
                        expectedUnequal 
                            ? "non-" 
                            : ""));
            }

            return TestResult.CreateSuccess();
        });
    }

    private static void ThrowIfAnyIsNull(params object?[] objects)
    {
        if (objects.Any(o => o is null))
            throw new ArgumentNullException();
    }

    private static TestResult SafeCall(string functionName, Func<TestResult> test)
    {
        try
        {
            return test();
        }
        catch (Exception ex)
        {
            return TestResult.CreateFailure($"{functionName} threw {ex.GetType().Name}: {ex.Message}");
        }
    }

    private static MethodInfo? GetEqualityOperator<T>()
    {
        // operator ==
        return GetOperator<T>("op_Equality");
    }

    private static MethodInfo? GetInequalityOperator<T>()
    {
        // operator !=
        return GetOperator<T>("op_Inequality");
    }

    private static MethodInfo? GetOperator<T>(string methodName)
    {
        return typeof(T).GetMethod(
            methodName, 
            BindingFlags.Static | BindingFlags.Public);
    }

    private static void AssertAllTestsHavePassed(IList<TestResult> testResults)
    {
        bool allTestsPass = testResults.All(r => r.IsSuccess);

        string[] errors = testResults
            .Where(r => !r.IsSuccess)
            .Select(r => r.FailureMessage)
            .ToArray();

        string compoundMessage = string.Join(Environment.NewLine, errors);

        allTestsPass.Should().BeTrue(
            "Some tests have failed:\n" + 
            compoundMessage);
    }
}