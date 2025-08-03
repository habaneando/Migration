namespace Migration.Application;

public interface IJobProcessingService
{
    Task ProcessJobAsync(Guid guid, CancellationToken cancellationToken = default);
}
