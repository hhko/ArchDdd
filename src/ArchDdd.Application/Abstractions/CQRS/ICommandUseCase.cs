using ArchDdd.Domain.Abstractions.Results.Contracts;
using MediatR;

namespace ArchDdd.Application.Abstractions.CQRS;

// MediatR 원본 정의
// public interface IRequestHandler<in TRequest>
//    where TRequest : IRequest
public interface ICommandUseCase<in TCommand> 
    : IRequestHandler<TCommand, IResult>
    where TCommand : ICommand
{
}

// MediatR 원본 정의
// public interface IRequestHandler<in TRequest, TResponse>
//    where TRequest : IRequest<TResponse>
//
// 변경 전
// : IRequestHandler<RegisterUserCommand, IResult<RegisterUserResponse>>
//
// 변경 후
// : ICommandHandler<RegisterUserCommand, RegisterUserResponse>
public interface ICommandUseCase<in TCommand, TResponse> 
    : IRequestHandler<TCommand, IResult<TResponse>>
    where TCommand : ICommand<TResponse>
    where TResponse : IResponse
{
}