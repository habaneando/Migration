namespace Migration.Application;

public interface IDataProcessingService
{
    Task<JobLog> ProcessItemAsync(JobItem item, CancellationToken cancellationToken = default);
}
