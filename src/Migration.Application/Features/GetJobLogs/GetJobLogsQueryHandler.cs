namespace Migration.Application;

public class GetJobLogsQueryHandler(IGetJobLogsService GetJobLogsService)
    : IQueryHandler<GetJobLogsQuery, Result<GetJobLogsResponse>>
{
    public Task<Result<GetJobLogsResponse>> ExecuteAsync(GetJobLogsQuery getJobLogsQuery, CancellationToken ct) =>
        GetJobLogsService.GetLogsByJobIdAsync(
            getJobLogsQuery.JobId,
            getJobLogsQuery.Page,
            getJobLogsQuery.PageSize);
}
