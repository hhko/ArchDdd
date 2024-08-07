﻿using ArchDdd.Adapters.Persistence.Repositories;
using ArchDdd.Adapters.Persistence.Repositories.BaseTypes;
using ArchDdd.Application.Abstractions.CQRS;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArchDdd.Adapters.Persistence.Abstractions.Pipelines;

public sealed class CommandTransactionPipeline<TCommandRequest, TCommandResponse>(IUnitOfWork<ArchDddDbContext> unitOfWork)
    : CommandTransactionPipelineBase<TCommandResponse>(unitOfWork),
      IPipelineBehavior<TCommandRequest, TCommandResponse>
        where TCommandRequest : class, IRequest<TCommandResponse>, ICommand
        where TCommandResponse : class, IResult
{
    public async Task<TCommandResponse> Handle(TCommandRequest command, RequestHandlerDelegate<TCommandResponse> next, CancellationToken cancellationToken)
    {
        var executionStrategy = UnitOfWork.CreateExecutionStrategy();
        return await executionStrategy.ExecuteAsync(
            cancellationToken => BeginTransactionAsync(next, cancellationToken),
            cancellationToken);
    }
}