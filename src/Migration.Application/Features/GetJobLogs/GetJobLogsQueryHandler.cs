namespace Migration.Application;

public class GetJobLogsQueryHandler(
    IJobLogRepository JobLogRepository,
    JobId.Factory JobIdFactory)
    : IQueryHandler<GetJobLogsQuery, JobLogs>
{
    public async Task<JobLogs> ExecuteAsync(GetJobLogsQuery getJobLogsQuery, CancellationToken ct)
    {
        var joblogs = await JobLogRepository
            .GetByJobIdAsync(
                JobIdFactory.Create(getJobLogsQuery.JobId),
                getJobLogsQuery.Page,
                getJobLogsQuery.PageSize)
            .ConfigureAwait(false);

        return joblogs;
    }
}
