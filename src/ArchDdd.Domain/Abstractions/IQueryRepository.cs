namespace ArchDdd.Domain.Abstractions.Contracts;

public interface IQueryRepository
{
    // N개 조회
    Task<IReadOnlyCollection<T>> SqlQueryAsync<T>(
        FormattableString sql,
        CancellationToken cancellationToken) where T : class;

    // 1개 조회
    Task<T?> SqlQuerySingleAsync<T>(
        FormattableString sql,
        CancellationToken cancellationToken) where T : class;
}
