using ArchDdd.Domain.Abstractions.Results.Contracts;
using MediatR;

namespace ArchDdd.Application.Abstractions.CQRS;

// MediatR 원본 정의
// public interface IRequest<out TResponse> : IBaseRequest { }
//
// 변경 전
// : IRequest<IResult<RegisterUserResponse>>;
//
// 변경 후
// : IQuery<RegisterUserResponse>;
public interface IQuery<out TResponse> : IRequest<IResult<TResponse>>
    where TResponse : IResponse
{
}