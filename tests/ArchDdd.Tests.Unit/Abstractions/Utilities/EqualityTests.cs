using System.Reflection;

namespace ArchDdd.Tests.Unit.Abstractions.Utilities;

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
            if (obj1!.GetHashCode() != obj2!.GetHashCode())
                return TestResult.CreateFailure("GetHashCode of equal objects returned different values.");

            return TestResult.CreateSuccess();
        });
    }

    private static TestResult TestEqualsReceivingNonNullOfOtherType<T>(T obj)
    {
        return SafeCall("Equals", () =>
        {
            if (obj!.Equals(new object()))
                return TestResult.CreateFailure("Equals returned true when comparing with object of a different type.");

            return TestResult.CreateSuccess();
        });
    }

    private static TestResult TestEqualsReceivingNull<T>(T obj)
    {
        if (typeof(T).IsClass)
            return TestEquals<T>(obj, default(T)!, false);

        return TestResult.CreateSuccess();
    }

    private static TestResult TestEqualsOfTReceivingNull<T>(T obj)
    {
        if (typeof(T).IsClass)
            return TestEqualsOfT<T>(obj, default(T)!, false);

        return TestResult.CreateSuccess();
    }

    private static TestResult TestEquals<T>(T obj1, T obj2, bool expectedEqual)
    {
        return SafeCall("Equals", () =>
        {
            if (obj1!.Equals((object)obj2!) != expectedEqual)
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
            return TestInequalityOperator<T>(obj, default(T)!, expectedEqual);

        return TestResult.CreateSuccess();
    }

    private static TestResult TestInequalityOperatorReceivingNull<T>(bool expectedEqual)
    {
        if (typeof(T).IsClass)
            return TestInequalityOperator<T>(default(T)!, default(T)!, expectedEqual);

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
            BindingFlags.Static |                   // static
                BindingFlags.Public |               // public
                BindingFlags.FlattenHierarchy);     // 부모 클래스 포함
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
