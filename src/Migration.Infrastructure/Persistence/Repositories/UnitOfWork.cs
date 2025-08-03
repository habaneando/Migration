namespace Migration.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    public Task CommitAsync(CancellationToken ct) =>
        throw new NotImplementedException();

    public Task RollBackAsync(CancellationToken ct) =>
        throw new NotImplementedException();
}
