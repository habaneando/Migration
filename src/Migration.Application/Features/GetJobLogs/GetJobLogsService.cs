namespace Migration.Application;

public class GetJobLogsService(IJobLogRepository JobLogRepository, JobId.Factory JobIdFactory)
    : IGetJobLogsService
{
    public Task<JobLogs> GetLogsByJobIdAsync(Guid guid, int? page, int? pageSize, CancellationToken cancellationToken = default) =>
        JobLogRepository
            .GetByJobIdAsync(
                JobIdFactory.Create(guid),
                page,
                pageSize);
}
