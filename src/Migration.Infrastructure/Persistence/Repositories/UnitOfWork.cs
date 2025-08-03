namespace Migration.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    public Task CommitAsync(CancellationToken ct) =>
        Task.CompletedTask;

    public Task RollBackAsync(CancellationToken ct) =>
        Task.CompletedTask;
}
