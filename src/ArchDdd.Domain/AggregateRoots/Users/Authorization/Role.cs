using ArchDdd.Domain.Abstractions.BaseTypes;
using System.Reflection;

namespace ArchDdd.Domain.AggregateRoots.Users.Authorization;

//public enum RoleName
//{
//    Customer = 1,
//    Employee = 2,
//    Manager = 3,
//    Administrator = 4
//}

//public sealed class Role //: Enumeration<Role>
//{
//    public static readonly Role Customer = new(1, nameof(Customer));
//    public static readonly Role Employee = new(2, nameof(Employee));
//    public static readonly Role Manager = new(3, nameof(Manager));
//    public static readonly Role Administrator = new(4, nameof(Administrator));

//    public Role(int id, string name)
//        : base(id, name)
//    {
//    }
public sealed class Role
{
    public static readonly Role Customer = new(nameof(Customer));
    public static readonly Role Employee = new(nameof(Employee));
    public static readonly Role Manager = new(nameof(Manager));
    public static readonly Role Administrator = new(nameof(Administrator));

    public Role(string name)
    {
        Name = name;
    }

    // EFCore을 위한 기본 생성자
    private Role()
    {
    }

    public string Name { get; init; }
    public ICollection<User> Users { get; set; }
    //public ICollection<Permission> Permissions { get; set; }

    // 사전 정의된 Role 목록을 반환한다
    public static List<Role> GetPredefinedRoles()
    {
        // 목록 찾기
        //  public static readonly Role Customer = ...
        //  ...
        return typeof(Role)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance)
            .Where(x => x.DeclaringType == typeof(Role))
            .Select(x => x.GetValue(null))
            .Cast<Role>()
            .ToList();
    }
}
