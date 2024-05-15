using ArchDdd.Application.Abstractions.CQRS;

namespace ArchDdd.Application.UseCases.Users.Queries.GetUserByUsername;

public sealed record GetUserByUsernameQuery(
    string Username)
: IQuery<UserResponse>      // IRequest<IResult<UserResponse>>
{
}

//public sealed record GetUserByUsernameQuery(string Username) : ICachedQuery<UserResponse>
//{
//    public string CacheKey => Username;

//    public TimeSpan? Duration => TimeSpan.FromMinutes(1);
//}

//public interface ICachedQuery
//{
//    string CacheKey { get; }
//    TimeSpan? Duration { get; }
//}

//public interface ICachedQuery<out TResponse> : IQuery<TResponse>, ICachedQuery
//    where TResponse : IResponse;