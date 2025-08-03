namespace Migration.Infrastructure;

public class MockUnitOfWork : IUnitOfWork
{
    public Task CommitAsync(CancellationToken ct) =>
        Task.CompletedTask;

    public Task RollBackAsync(CancellationToken ct) =>
        Task.CompletedTask;
}
