namespace Migration.Application;

public class GetJobLogsQueryHandler : IQueryHandler<GetJobLogsQuery, JobLogs>
{
    public Task<JobLogs> ExecuteAsync(GetJobLogsQuery getJobLogsQuery, CancellationToken ct)
    {
        var logs = new JobLogs();
        logs.JobId = getJobLogsQuery.JobId;
        logs.Page = 1;
        logs.PageSize = 10;
        logs.TotalLogs = 5;
        logs.Logs = new List<JobLog>
        {
        };

        return Task.FromResult(logs);
    }
}
