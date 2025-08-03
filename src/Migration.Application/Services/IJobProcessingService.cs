namespace Migration.Application;

public interface IJobProcessingService
{
    Task ProcessJobAsync(JobId jobId, CancellationToken cancellationToken = default);
}
