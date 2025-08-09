namespace Migration.Infrastructure;

public class MockUnitOfWork : BaseDisposable, IUnitOfWork
{
    public TRepository GetRepository<TRepository, TEntity>()
        where TRepository : IRepository<TEntity>
        where TEntity : class, IEntity =>
        throw new NotImplementedException();

    public Task BeginTransactionAsync(CancellationToken ct) =>
        Task.CompletedTask;

    public Task CommitAsync(CancellationToken ct) =>
        Task.CompletedTask;

    public Task CommitTransactionAsync(CancellationToken ct) =>
        Task.CompletedTask;

    public Task RollBackAsync(CancellationToken ct) =>
        Task.CompletedTask;
}
