using ArchDdd.Domain.AggregateRoots.Users;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArchDdd.Adapters.Persistence.Repositories.Converters.EntityIds;

// UserId
public sealed class UserIdConverter : ValueConverter<UserId, string>
{
    public UserIdConverter() : base(id => id.Value.ToString(), ulid => UserId.Create(Ulid.Parse(ulid))) 
    { 
    }
}

public sealed class UserIdComparer : ValueComparer<UserId>
{
    public UserIdComparer() : base((id1, id2) => id1!.Value == id2!.Value, id => id.Value.GetHashCode()) 
    { 
    }
}

// Username
public sealed class UsernameConverter : ValueConverter<Username, string>
{
    public UsernameConverter() : base(username => username.Value, ulid => Username.Create(ulid).Value)
    {
    }
}

public sealed class UsernameComparer : ValueComparer<Username>
{
    public UsernameComparer() : base((id1, id2) => id1!.Value == id2!.Value, id => id.Value.GetHashCode())
    {
    }
}

// Email
public sealed class EmailConverter : ValueConverter<Email, string>
{
    public EmailConverter() : base(id => id.Value, ulid => Email.Create(ulid).Value)
    {
    }
}

public sealed class EmailComparer : ValueComparer<Email>
{
    public EmailComparer() : base((id1, id2) => id1!.Value == id2!.Value, id => id.Value.GetHashCode())
    {
    }
}

//
public sealed class PasswordHashConverter : ValueConverter<PasswordHash, string>
{
    public PasswordHashConverter() : base(id => id.Value, ulid => PasswordHash.Create(ulid).Value)
    {
    }
}

public sealed class PasswordHashComparer : ValueComparer<PasswordHash>
{
    public PasswordHashComparer() : base((id1, id2) => id1!.Value == id2!.Value, id => id.Value.GetHashCode())
    {
    }
}