namespace Migration.Application;

public class GetJobLogsQueryHandler(IGetJobLogsService GetJobLogsService)
    : IQueryHandler<GetJobLogsQuery, JobLogs>
{
    public Task<JobLogs> ExecuteAsync(GetJobLogsQuery getJobLogsQuery, CancellationToken ct) =>
        GetJobLogsService.GetLogsByJobIdAsync(
            getJobLogsQuery.JobId,
            getJobLogsQuery.Page,
            getJobLogsQuery.PageSize);
}
