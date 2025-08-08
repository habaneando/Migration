namespace Migration.Domain;

public class MockJobLogRepository(JobItemId.Factory JobItemIdFactory)
    : IJobLogRepository
{
    public Task UpdateAsync(
        JobLog jobLog,
        CancellationToken cancellationToken = default) =>
        Task.CompletedTask;

    public async Task<JobLogs> GetByJobIdAsync(
        JobId jobId,
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default)
    {
        var logs = new List<JobLog>
        {
            new (JobItemIdFactory.Create(), JobLogStatus.Success, "description1"),
            new (JobItemIdFactory.Create(), JobLogStatus.Failure, "description2"),
            new (JobItemIdFactory.Create(), JobLogStatus.Success, "description3")
        };

        var jobLogs = new JobLogs(jobId.Id, logs);

        return jobLogs; 
    }
}
