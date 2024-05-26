using ArchDdd.Domain.Abstractions.BaseTypes;
using System.Collections;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.LayerTests.Domain.Abstractions.BaseTypes;

//[Trait(nameof(UnitTest), UnitTest.Domain)]
//public sealed class ValueObjectTests
//{
//    private sealed class TestValueObject : ValueObject
//    {
//        private TestValueObject(int value)
//        {
//            Value = value;
//        }

//        public new int Value { get; }

//        public static ValidationResult<TestValueObject> Create(int value)
//        {
//            var errors = Validate(value);
//            return errors.CreateValidationResult(createValueObject: () => new TestValueObject(value));
//        }

//        public static IList<Error> Validate(int value)
//        {
//            return EmptyList<Error>()
//                .If(false, Error.NullError);
//        }

//        public override IEnumerable<object> GetAtomicValues()
//        {
//            yield return Value;
//        }
//    }

//    ////
//    //// 비교 메서드 | IEquatable
//    ////

//    //[Fact]
//    //public void Equality_SameValues_ShouldBeSameObject()
//    //{
//    //    // Arrange
//    //    TestValueObject valueObject1 = TestValueObject.Create(1).Value;
//    //    TestValueObject valueObject2 = TestValueObject.Create(1).Value;

//    //    // Act & Assert
//    //    EqualityTests.TestEqualObjects(valueObject1, valueObject2);
//    //}

//    //[Fact]
//    //public void Equality_DistinctValues_ShouldNotBeSameObject()
//    //{
//    //    // Arrange
//    //    TestValueObject valueObject1 = TestValueObject.Create(1).Value;
//    //    TestValueObject valueObject2 = TestValueObject.Create(2).Value;

//    //    // Act & Assert
//    //    EqualityTests.TestUnequalObjects(valueObject1, valueObject2);
//    //}

//    //[Fact]
//    //public void Equality_ComparingWithNull()
//    //{
//    //    // Arrange
//    //    TestValueObject valueObject = TestValueObject.Create(1).Value;

//    //    EqualityTests.TestAgainstNull(valueObject);
//    //}

//    //[Fact]
//    //public void Equality_ComparingWithAllNull()
//    //{
//    //    // Arrange
//    //    EqualityTests.TestAgainstNull<TestValueObject>();
//    //}
//}


[Trait(nameof(UnitTest), UnitTest.Domain)]
public sealed class ValueObjectTests
{
    public class Address(string street, string city, string postalCode) : ValueObject
    {
        public string Street { get; } = street;
        public string City { get; } = city;
        public string PostalCode { get; } = postalCode;

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return PostalCode;
        }
    }

    //
    // bool Equal(T? other)
    //

    [Fact]
    public void IdenticalValueObjects_EqualsOfT_ShouldBeTrue()
    {
        // Arrange
        Address address1 = new("123 Elm St", "Somewhere", "12345");
        Address address2 = new("123 Elm St", "Somewhere", "12345");

        // Act
        var actual = address1.Equals(address2);

        // Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void DifferentValueObjects_EqualsOfT_ShouldBeFalse()
    {
        // Arrange
        Address address1 = new("123 Elm St", "Somewhere", "12345");
        Address address2 = new("124 Elm St", "Somewhere", "12345");

        // Act
        var actual = address1.Equals(address2);

        // Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void NullValueObjects_EqualsOfT_ShouldBeFalse()
    {
        // Arrange
        Address address1 = new("123 Elm St", "Somewhere", "12345");
        Address? address2 = null;

        // Act
        var actual = address1.Equals(address2);

        // Assert
        actual.Should().BeFalse();
    }

    //
    // bool Equal(object? other)
    //

    [Fact]
    public void IdenticalValueObjects_Equals_ShouldBeTrue()
    {
        // Arrange
        Address address1 = new("123 Elm St", "Somewhere", "12345");
        Address address2 = new("123 Elm St", "Somewhere", "12345");

        // Act
        var actual = address1.Equals((object?)address2);

        // Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void DifferentValueObjects_Equals_ShouldBeFalse()
    {
        // Arrange
        Address address1 = new("123 Elm St", "Somewhere", "12345");
        Address address2 = new("124 Elm St", "Somewhere", "12345");

        // Act
        var actual = address1.Equals((object?)address2);

        // Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void NullValueObjects_Equals_ShouldBeFalse()
    {
        // Arrange
        Address address1 = new("123 Elm St", "Somewhere", "12345");
        Address? address2 = null;

        // Act
        var actual = address1.Equals((object?)address2);

        // Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void OtherTypeValueObject_Euqal_ShouldBeFalse()
    {
        // Arrange
        Address address1 = new("123 Elm St", "Somewhere", "12345");
        object? address2 = new object();

        // Act
        var actual = address1.Equals((object?)address2);

        // Assert
        actual.Should().BeFalse();
    }

    //
    // GetHashCode
    //

    [Fact]
    public void IdenticalValueObjects_GetHashCode_ShouldBeTrue()
    {
        // Arrange
        Address address1 = new("123 Elm St", "Somewhere", "12345");
        Address address2 = new("123 Elm St", "Somewhere", "12345");

        // Act
        var actual = address1.GetHashCode() == address2.GetHashCode();

        // Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void DifferentValueObjects_GetHashCode_ShouldBeFalse()
    {
        // Arrange
        Address address1 = new("123 Elm St", "Somewhere", "12345");
        Address address2 = new("124 Elm St", "Somewhere", "12345");

        // Act
        var actual = address1.GetHashCode() == address2.GetHashCode();

        // Assert
        actual.Should().BeFalse();
    }

    //
    // Operator Equality: operator ==
    //

    [Fact]
    public void IdenticalValueObjects_OperatorEquality_ShouldBeTrue()
    {
        // Arrange
        Address address1 = new("123 Elm St", "Somewhere", "12345");
        Address address2 = new("123 Elm St", "Somewhere", "12345");

        // Act
        var actual = address1 == address2;

        // Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void DifferentValueObjects_OperatorEquality_ShouldBeFalse()
    {
        // Arrange
        Address address1 = new("123 Elm St", "Somewhere", "12345");
        Address address2 = new("124 Elm St", "Somewhere", "12345");

        // Act
        var actual = address1 == address2;

        // Assert
        actual.Should().BeFalse();
    }

    [Theory]
    [ClassData(typeof(NullValueObjects))]
    public void NullValueObjects_OperatorEquality_ShouldBe(Address? address1, Address? address2, bool expected)
    {
        // Act
        var actual = (address1 == address2);

        // Assert
        actual.Should().Be(expected);
    }

    //
    // Operator Inequality: operator !=
    //

    [Fact]
    public void DifferentValueObjects_OperatorInequality_ShouldBeTrue()
    {
        // Arrange
        Address address1 = new("123 Elm St", "Somewhere", "12345");
        Address address2 = new("124 Elm St", "Somewhere", "12345");

        // Act
        var actual = (address1 != address2);

        // Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void IdenticalValueObjects_OperatorInequality_ShouldBeFalse()
    {
        // Arrange
        Address address1 = new("123 Elm St", "Somewhere", "12345");
        Address address2 = new("123 Elm St", "Somewhere", "12345");

        // Act
        var actual = (address1 != address2);

        // Assert
        actual.Should().BeFalse();
    }

    [Theory]
    [ClassData(typeof(NullValueObjects))]
    public void NullValueObjects_OperatorInequality_ShouldBe(Address? address1, Address? address2, bool expected)
    {
        // Act
        var actual = (address1 != address2);

        // Assert
        actual.Should().Be(!expected);
    }

    private class NullValueObjects : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator()
        {
            yield return new object?[] { null, null, true };
            yield return new object?[] { new Address("", "", ""), null, false };
            yield return new object?[] { null, new Address("", "", ""), false };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
