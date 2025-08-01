namespace Migration.Common;

public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
    Task<TResult> ExecuteAsync(TQuery query, CancellationToken ct);
}
