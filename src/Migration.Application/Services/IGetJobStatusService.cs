namespace Migration.Application;

public interface IGetJobStatusService
{
    Task<JobStatusItem> GetStatusByIdAsync(Guid guid, CancellationToken cancellationToken = default);
}
