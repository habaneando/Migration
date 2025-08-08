namespace Migration.Infrastructure;

public class MockUnitOfWork : BaseDisposable, IUnitOfWork
{
    public IRepository GetRepository<TRepository>()
        where TRepository : IRepository =>
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
