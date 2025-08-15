namespace Migration.Application;

public interface IStartJobService
{
    Task ProcessJobAsync(Guid guid, CancellationToken cancellationToken = default);
}
