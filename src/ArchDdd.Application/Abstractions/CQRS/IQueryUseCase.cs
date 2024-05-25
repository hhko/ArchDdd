using ArchDdd.Domain.Abstractions.Results.Contracts;
using MediatR;

namespace ArchDdd.Application.Abstractions.CQRS;

// 참고 소스
// https://github.com/m-jovanovic/event-reminder/blob/main/EventReminder.Application/Core/Abstractions/Messaging/IQueryHandler.cs
//
// MediatR 원본 정의
// public interface IRequestHandler<in TRequest, TResponse>
//    where TRequest : IRequest<TResponse>
//
// 변경 전
// : IRequestHandler<GetUserByUsernameQuery, IResult<UserResponse>>
//
// 변경 후
// : IQueryHandler<GetUserByUsernameQuery, UserResponse>
public interface IQueryUseCase<in TQuery, TResponse> 
    : IRequestHandler<TQuery, IResult<TResponse>>
    where TQuery : IQuery<TResponse>
    where TResponse : IResponse
{
}