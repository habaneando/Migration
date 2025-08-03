namespace Migration.Application;

public class DataProcessingService : IDataProcessingService
{
    public Task<JobLog> ProcessItemAsync(JobItem item, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}
