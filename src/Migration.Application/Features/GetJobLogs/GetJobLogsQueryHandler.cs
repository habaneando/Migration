namespace Migration.Application;

public class GetJobLogsQueryHandler(IGetJobLogsService GetJobLogsService)
    : IQueryHandler<GetJobLogsQuery, Result<JobLogs>>
{
    public Task<Result<JobLogs>> ExecuteAsync(GetJobLogsQuery getJobLogsQuery, CancellationToken ct) =>
        GetJobLogsService.GetLogsByJobIdAsync(
            getJobLogsQuery.JobId,
            getJobLogsQuery.Page,
            getJobLogsQuery.PageSize);
}
