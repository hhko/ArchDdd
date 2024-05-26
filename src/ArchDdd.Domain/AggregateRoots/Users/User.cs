using ArchDdd.Domain.Abstractions.BaseTypes.Contracts;
using ArchDdd.Domain.Abstractions.BaseTypes;
using ArchDdd.Domain.AggregateRoots.Users.Enumerations;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using ArchDdd.Domain.AggregateRoots.Users.Events;

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

    // Empty constructor in this case is required by EF Core
    private User()
    {
    }

    //public Username Username { get; set; }
    //public Email Email { get; set; }
    public Username Username { get; }
    public Email Email { get; }
    public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

    public PasswordHash PasswordHash { get; set; }

    //
    // IAuditable
    //

    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? UpdatedOn { get; set; }
    public string CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

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
}
