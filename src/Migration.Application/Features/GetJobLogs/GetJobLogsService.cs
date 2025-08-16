namespace Migration.Application;

public class GetJobLogsService(IJobLogRepository JobLogRepository, JobId.Factory JobIdFactory)
    : IGetJobLogsService
{
    public async Task<Result<JobLogs>> GetLogsByJobIdAsync(
        Guid guid,
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var joblogs = await JobLogRepository
                .GetByJobIdAsync(
                    JobIdFactory.Create(guid),
                    page,
                    pageSize)
                .ConfigureAwait(false);

            return joblogs != null
                ? Result<JobLogs>.Ok(joblogs)
                : Result<JobLogs>.Fail(ErrorItem.NotFound("Job not found"));
        }
        catch (Exception ex)
        {
            return Result<JobLogs>.Fail(
                ErrorItem.Internal("Database error occurred while retrieving job logs", ex));
        }
    }
}
