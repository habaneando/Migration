namespace Migration.Common;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync(CancellationToken ct);

    Task RollBackAsync(CancellationToken ct);

    Task BeginTransactionAsync(CancellationToken ct);

    Task CommitTransactionAsync(CancellationToken ct);

    TRepository GetRepository<TRepository, TEntity>()
        where TRepository : IRepository<TEntity>
        where TEntity : IEntity;
}
