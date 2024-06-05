using ArchDdd.Adapters.Persistence.Repositories;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using MediatR;

namespace ArchDdd.Adapters.Persistence.Abstractions.Pipelines;

public class CommandTransactionPipelineBase<TCommandResponse>(
    IUnitOfWork<ArchDddDbContext> unitOfWork)
    where TCommandResponse : IResult
{
    protected readonly IUnitOfWork<ArchDddDbContext> UnitOfWork = unitOfWork;

    protected async Task<TCommandResponse> BeginTransactionAsync(RequestHandlerDelegate<TCommandResponse> next, CancellationToken cancellationToken)
    {
        using var transaction = await UnitOfWork.BeginTransactionAsync(cancellationToken);

        var result = await next();

        if (result.IsSuccess)
        {
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        else
        {
            await transaction.RollbackAsync(cancellationToken);
        }

        return result;
    }
}