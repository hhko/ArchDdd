using ArchDdd.Domain.AggregateRoots.Users.Enumerations;
using ArchDdd.Tests.Unit.Abstractions.Utilities;
using System.Collections;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.LayerTests.Domain.Users.Enumerations;

[Trait(nameof(UnitTest), UnitTest.Domain)]
public sealed class RoleTests
{
    //
    // 비교 메서드 | IEquatable
    //

    [Fact]
    public void Equality_SameValues_ShouldBeSameObject()
    {
        // Arrange
        Role role1 = Role.Administrator;
        Role role2 = Role.Administrator;

        // Act & Assert
        EqualityTests.TestEqualObjects(role1, role2);
    }

    [Fact]
    public void Equality_DistinctValues_ShouldNotBeSameObject()
    {
        // Arrange
        Role role1 = Role.Administrator;
        Role role2 = Role.Customer;

        // Act & Assert
        EqualityTests.TestUnequalObjects(role1, role2);
    }

    [Fact]
    public void Equality_ComparingWithNull()
    {
        // Arrange
        Role role = Role.Administrator;

        EqualityTests.TestAgainstNull(role);
    }

    [Fact]
    public void Equality_ComparingWithAllNull()
    {
        // Arrange
        EqualityTests.TestAgainstNull<Role>();
    }

    [Theory]
    [ClassData(typeof(ValidData))]
    public void FromId_FoundFromId_ShouldReutnT(int id, Role role)
    {
        Role? actual = Role.FromId(id);

        actual.Should().Be(role);
    }

    private class ValidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { Role.Customer.Id, Role.Customer };
            yield return new object[] { Role.Employee.Id, Role.Employee };
            yield return new object[] { Role.Manager.Id, Role.Manager };
            yield return new object[] { Role.Administrator.Id, Role.Administrator };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    [Fact]
    public void FromId_NotFoundFromId_ShouldReutnNull()
    {
        Role? actual = Role.FromId(-1);

        actual.Should().BeNull();
    }

    [Fact]
    public void FromName_FoundName_ShouldReutnT()
    {
        // Customer: 참
        // customer: 거짓, 대/소문자 구분
        Role? actual = Role.FromName("Customer");

        actual.Should().Be(Role.Customer);
    }
}
