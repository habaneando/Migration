namespace Migration.Application;

public interface IGetJobLogsService
{
    Task<JobLogs> GetLogsByJobIdAsync(
        Guid guid,
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default);
}
