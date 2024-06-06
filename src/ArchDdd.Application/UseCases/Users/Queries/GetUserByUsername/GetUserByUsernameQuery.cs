using ArchDdd.Application.Abstractions.CQRS;

namespace ArchDdd.Application.UseCases.Users.Queries.GetUserByUsername;

public sealed record GetUserByUsernameQuery(
    string Username)
    : IQuery<GetUserByUsernameResponse>      // IRequest<IResult<UserResponse>>
{
}

//public sealed record GetUserByUsernameQuery(string Username) : ICachedQuery<UserResponse>
//{
//    public string CacheKey => Username;
//    public TimeSpan? Duration => TimeSpan.FromMinutes(1);
//}