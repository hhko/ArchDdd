using ArchDdd.Domain.Abstractions.Results.Contracts;
using MediatR;

namespace ArchDdd.Application.Abstractions.CQRS;

// 변경 전
// : IRequestHandler<GetUserByUsernameQuery, IResult<UserResponse>>
//
// 변경 후
// : IQueryHandler<GetUserByUsernameQuery, UserResponse>

public interface IQueryHandler<TQuery, TResponse> 
    : IRequestHandler<TQuery, IResult<TResponse>>
    where TQuery : IQuery<TResponse>
    where TResponse : IResponse
{
}

//public interface IRequestHandler<in TRequest, TResponse>
//    where TRequest : IRequest<TResponse>