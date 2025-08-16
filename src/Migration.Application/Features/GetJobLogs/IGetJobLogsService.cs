namespace Migration.Application;

public interface IGetJobLogsService
{
    Task<Result<GetJobLogsResponse>> GetLogsByJobIdAsync(
        Guid guid,
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default);
}
