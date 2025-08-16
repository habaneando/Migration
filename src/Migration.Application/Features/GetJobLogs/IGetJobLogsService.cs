namespace Migration.Application;

public interface IGetJobLogsService
{
    Task<Result<JobLogs>> GetLogsByJobIdAsync(
        Guid guid,
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default);
}
