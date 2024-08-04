using ArchDdd.Domain.Abstractions.BaseTypes.Contracts;
using ArchDdd.Domain.Abstractions.BaseTypes;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using ArchDdd.Domain.AggregateRoots.Users.Events;
using ArchDdd.Domain.AggregateRoots.Users.Enumerations;

namespace ArchDdd.Domain.AggregateRoots.Users;

public sealed class User : AggregateRoot<UserId>, IAuditable
{
    private readonly List<Role> _roles = [];

    private User(UserId id, Username username, Email email)
        : base(id)
    {
        Username = username;
        Email = email;
    }

    // EFCore을 위한 기본 생성자
    private User()
    {
    }

    // NxM
    //  builder.HasMany(u => u.Roles)  // User -> Roles: public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();
    //    .WithMany(r => r.Users)      // Role -> User:  public ICollection<User> Users { get; init; }
    //    .UsingEntity<RoleUser>();    // RoleUser:      public RoleUser(string roleName, UserId userId)

    // CREATE TABLE "User" (
    //     "Id" Char(26) NOT NULL CONSTRAINT "PK_User" PRIMARY KEY,
    //     "Username" TEXT NOT NULL,
    //     "Email" TEXT NOT NULL,
    //     "PasswordHash" NChar(514) NOT NULL,
    //     "CreatedOn" TEXT NOT NULL,
    //     "UpdatedOn" TEXT NULL
    // )

    //public Username Username { get; set; }
    //public Email Email { get; set; }
    public Username Username { get; } = null!;
    public Email Email { get; } = null!;
    public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

    public PasswordHash PasswordHash { get; set; } = null!;

    //
    // IAuditable
    //

    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? UpdatedOn { get; set; }
    //public string CreatedBy { get; set; }
    //public string? UpdatedBy { get; set; }

    public static User Create(UserId id, Username username, Email email)
    {
        var user = new User(id, username, email);
        user.RaiseDomainEvent(UserRegisteredDomainEvent.New(user.Id));
        return user;
    }

    public void SetHashedPassword(PasswordHash passwordHash)
    {
        PasswordHash = passwordHash;
    }

    public void AddRole(Role role)
    {
        _roles.Add(role);
    }

    public void RemoveRole(Role role)
    {
        _roles.Remove(role);
    }
}
