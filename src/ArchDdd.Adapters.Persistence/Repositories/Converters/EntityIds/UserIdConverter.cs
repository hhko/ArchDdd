using ArchDdd.Domain.AggregateRoots.Users;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArchDdd.Adapters.Persistence.Repositories.Converters.EntityIds;

// UserId
public sealed class UserIdConverter : ValueConverter<UserId, string>
{
    public UserIdConverter() 
        : base(id => id.Value.ToString(), 
            ulid => UserId.Create(Ulid.Parse(ulid))) 
    { 
    }
}

public sealed class UserIdComparer : ValueComparer<UserId>
{
    public UserIdComparer() 
        : base((id1, id2) => id1!.Value == id2!.Value, 
            id => id.GetHashCode()) //.Value.GetHashCode()) 
    { 
    }
}



//
