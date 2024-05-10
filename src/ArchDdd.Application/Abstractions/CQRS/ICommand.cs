using ArchDdd.Domain.Abstractions.Results.Contracts;
using MediatR;

namespace ArchDdd.Application.Abstractions.CQRS;

// public interface IRequest : IBaseRequest { }
// public interface IRequest<out TResponse> : IBaseRequest { }
public interface ICommand : IRequest<IResult>
{
}

public interface ICommand<out TResponse> : IRequest<IResult<TResponse>>
    where TResponse : IResponse
{
}