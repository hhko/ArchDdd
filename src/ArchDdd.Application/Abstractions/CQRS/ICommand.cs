﻿using ArchDdd.Domain.Abstractions.Results.Contracts;
using MediatR;

namespace ArchDdd.Application.Abstractions.CQRS;

// MediatR 원본 정의
// public interface IRequest : IBaseRequest { }
//
// 변경 전
// public interface IRequest : IBaseRequest { }
//
// 변경 후
// public interface IRequest<out TResponse> : IBaseRequest { }
public interface ICommand : IRequest<IResult>
{
}

// MediatR 원본 정의
// public interface IRequest<out TResponse> : IBaseRequest { }
//
// 변경 전
// : IRequest<IResult<RegisterUserResponse>>;
//
// 변경 후
// : ICommand<RegisterUserResponse>;
public interface ICommand<out TResponse> : IRequest<IResult<TResponse>>
    where TResponse : IResponse
{
}