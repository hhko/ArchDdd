using ArchDdd.Domain.Abstractions.BaseTypes;
using System.Collections;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.LayerTests.Domain.Abstractions.BaseTypes;

[Trait(nameof(UnitTest), UnitTest.Domain)]
public sealed class EnumerationTests
{
    public sealed class TestRole : Enumeration<TestRole>
    {
        public static readonly TestRole Customer = new(1, nameof(Customer));
        public static readonly TestRole Employee = new(2, nameof(Employee));
        public static readonly TestRole Manager = new(3, nameof(Manager));
        public static readonly TestRole Administrator = new(4, nameof(Administrator));

        public TestRole(int id, string name)
            : base(id, name)
        {
        }
    }

    ////
    //// 비교 메서드 | IEquatable
    ////

    //[Fact]
    //public void Equality_SameValues_ShouldBeSameObject()
    //{
    //    // Arrange
    //    TestRole role1 = TestRole.Administrator;
    //    TestRole role2 = TestRole.Administrator;

    //    // Act & Assert
    //    EqualityTests.TestEqualObjects(role1, role2);
    //}

    //[Fact]
    //public void Equality_DistinctValues_ShouldNotBeSameObject()
    //{
    //    // Arrange
    //    TestRole role1 = TestRole.Administrator;
    //    TestRole role2 = TestRole.Customer;

    //    // Act & Assert
    //    EqualityTests.TestUnequalObjects(role1, role2);
    //}

    //[Fact]
    //public void Equality_ComparingWithNull()
    //{
    //    // Arrange
    //    TestRole role = TestRole.Administrator;

    //    EqualityTests.TestAgainstNull(role);
    //}

    //[Fact]
    //public void Equality_ComparingWithAllNull()
    //{
    //    // Arrange
    //    EqualityTests.TestAgainstNull<TestRole>();
    //}

    [Theory]
    [ClassData(typeof(ValidData))]
    public void EnumAre_FromId_ShouldBeT(int id, TestRole role)
    {
        TestRole? actual = TestRole.FromId(id);

        actual.Should().Be(role);
    }

    private class ValidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { TestRole.Customer.Id, TestRole.Customer };
            yield return new object[] { TestRole.Employee.Id, TestRole.Employee };
            yield return new object[] { TestRole.Manager.Id, TestRole.Manager };
            yield return new object[] { TestRole.Administrator.Id, TestRole.Administrator };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    [Fact]
    public void EnumAreNot_FromId_ShouldBeNull()
    {
        TestRole? actual = TestRole.FromId(-1);

        actual.Should().BeNull();
    }
}
