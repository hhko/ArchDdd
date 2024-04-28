using ArchDdd.Domain.Abstractions.BaseTypes;
using ArchDdd.Domain.AggregateRoots.Users.Enumerations;
using ArchDdd.Tests.Unit.Abstractions.Utilities;
using System.Collections;
using static ArchDdd.Tests.Unit.Abstractions.Constants.Constants;

namespace ArchDdd.Tests.Unit.LayerTests.Domain.Abstractions.BaseTypes;

[Trait(nameof(UnitTest), UnitTest.Domain)]
public sealed class EnumerationTests
{
    public sealed class DumyRole : Enumeration<DumyRole>
    {
        public static readonly DumyRole Customer = new(1, nameof(Customer));
        public static readonly DumyRole Employee = new(2, nameof(Employee));
        public static readonly DumyRole Manager = new(3, nameof(Manager));
        public static readonly DumyRole Administrator = new(4, nameof(Administrator));

        public DumyRole(int id, string name)
            : base(id, name)
        {
        }
    }

    //
    // 비교 메서드 | IEquatable
    //

    [Fact]
    public void Equality_SameValues_ShouldBeSameObject()
    {
        // Arrange
        DumyRole role1 = DumyRole.Administrator;
        DumyRole role2 = DumyRole.Administrator;

        // Act & Assert
        EqualityTests.TestEqualObjects(role1, role2);
    }

    [Fact]
    public void Equality_DistinctValues_ShouldNotBeSameObject()
    {
        // Arrange
        DumyRole role1 = DumyRole.Administrator;
        DumyRole role2 = DumyRole.Customer;

        // Act & Assert
        EqualityTests.TestUnequalObjects(role1, role2);
    }

    [Fact]
    public void Equality_ComparingWithNull()
    {
        // Arrange
        DumyRole role = DumyRole.Administrator;

        EqualityTests.TestAgainstNull(role);
    }

    [Fact]
    public void Equality_ComparingWithAllNull()
    {
        // Arrange
        EqualityTests.TestAgainstNull<DumyRole>();
    }

    [Theory]
    [ClassData(typeof(ValidData))]
    public void FromId_FoundFromId_ShouldReutnT(int id, DumyRole role)
    {
        DumyRole? actual = DumyRole.FromId(id);

        actual.Should().Be(role);
    }

    private class ValidData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { DumyRole.Customer.Id, DumyRole.Customer };
            yield return new object[] { DumyRole.Employee.Id, DumyRole.Employee };
            yield return new object[] { DumyRole.Manager.Id, DumyRole.Manager };
            yield return new object[] { DumyRole.Administrator.Id, DumyRole.Administrator };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    [Fact]
    public void FromId_NotFoundFromId_ShouldReutnNull()
    {
        DumyRole? actual = DumyRole.FromId(-1);

        actual.Should().BeNull();
    }
}
