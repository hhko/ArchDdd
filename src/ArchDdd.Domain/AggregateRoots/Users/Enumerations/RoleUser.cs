namespace ArchDdd.Domain.AggregateRoots.Users.Enumerations;

public sealed class RoleUser
{
    public RoleUser(string roleName, UserId userId)
    {
        RoleName = roleName;
        UserId = userId;
    }

    private RoleUser()
    {
    }

    public string RoleName { get; init; } = null!;

    public UserId UserId { get; init; }
}

