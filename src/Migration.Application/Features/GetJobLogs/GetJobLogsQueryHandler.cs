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
            new JobLog(Guid.NewGuid(), JobItemStatus.Success,"description1",DateTime.UtcNow),
            new JobLog(Guid.NewGuid(), JobItemStatus.Failure,"description2",DateTime.UtcNow)
        };

        return Task.FromResult(logs);
    }
}
