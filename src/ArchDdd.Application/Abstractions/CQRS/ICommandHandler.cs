using ArchDdd.Domain.Abstractions.Results.Contracts;
using MediatR;

namespace ArchDdd.Application.Abstractions.CQRS;


public interface ICommandHandler<in TCommand> 
    : IRequestHandler<TCommand, IResult>
    where TCommand : ICommand
{
}

// 변경 전
// : IRequestHandler<RegisterUserCommand, IResult<RegisterUserResponse>>
//
// 변경 후
// : ICommandHandler<RegisterUserCommand, RegisterUserResponse>
public interface ICommandHandler<in TCommand, TResponse> 
    : IRequestHandler<TCommand, IResult<TResponse>>
    where TCommand : ICommand<TResponse>
    where TResponse : IResponse
{
}