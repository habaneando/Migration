namespace Migration.Common;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken ct);

    Task RollBackAsync(CancellationToken ct);
}
