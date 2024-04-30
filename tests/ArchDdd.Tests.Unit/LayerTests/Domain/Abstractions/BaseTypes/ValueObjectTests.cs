using ArchDdd.Domain.Abstractions.BaseTypes;
using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Tests.Unit.Abstractions.Utilities;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;
using static PrimitiveUtilities.ListUtilities;

namespace ArchDdd.Tests.Unit.LayerTests.Domain.Abstractions.BaseTypes;

[Trait(nameof(UnitTest), UnitTest.Domain)]
public sealed class ValueObjectTests
{
    private sealed class TestValueObject : ValueObject
    {
        private TestValueObject(int value)
        {
            Value = value;
        }

        public new int Value { get; }

        public static ValidationResult<TestValueObject> Create(int value)
        {
            var errors = Validate(value);
            return errors.CreateValidationResult(createValueObject: () => new TestValueObject(value));
        }

        public static IList<Error> Validate(int value)
        {
            return EmptyList<Error>()
                .If(false, Error.NullError);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }

    ////
    //// 비교 메서드 | IEquatable
    ////

    //[Fact]
    //public void Equality_SameValues_ShouldBeSameObject()
    //{
    //    // Arrange
    //    TestValueObject valueObject1 = TestValueObject.Create(1).Value;
    //    TestValueObject valueObject2 = TestValueObject.Create(1).Value;

    //    // Act & Assert
    //    EqualityTests.TestEqualObjects(valueObject1, valueObject2);
    //}

    //[Fact]
    //public void Equality_DistinctValues_ShouldNotBeSameObject()
    //{
    //    // Arrange
    //    TestValueObject valueObject1 = TestValueObject.Create(1).Value;
    //    TestValueObject valueObject2 = TestValueObject.Create(2).Value;

    //    // Act & Assert
    //    EqualityTests.TestUnequalObjects(valueObject1, valueObject2);
    //}

    //[Fact]
    //public void Equality_ComparingWithNull()
    //{
    //    // Arrange
    //    TestValueObject valueObject = TestValueObject.Create(1).Value;

    //    EqualityTests.TestAgainstNull(valueObject);
    //}

    //[Fact]
    //public void Equality_ComparingWithAllNull()
    //{
    //    // Arrange
    //    EqualityTests.TestAgainstNull<TestValueObject>();
    //}
}
