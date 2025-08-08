namespace Migration.Common;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync(CancellationToken ct);

    Task RollBackAsync(CancellationToken ct);

    Task BeginTransactionAsync(CancellationToken ct);

    Task CommitTransactionAsync(CancellationToken ct);

    IRepository GetRepository<TRepository>()
        where TRepository : IRepository;
}
