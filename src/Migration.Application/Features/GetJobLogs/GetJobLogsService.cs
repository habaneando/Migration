namespace Migration.Application;

public class GetJobLogsService(
    IJobLogRepository JobLogRepository,
    JobId.Factory JobIdFactory,
    GetJobLogsMapper Mapper)
    : IGetJobLogsService
{
    public async Task<Result<GetJobLogsResponse>> GetLogsByJobIdAsync(
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
                ? Result<GetJobLogsResponse>.Ok(Mapper.FromEntity(joblogs))
                : Result<GetJobLogsResponse>.Fail(ErrorItem.NotFound("Job not found"));
        }
        catch (Exception ex)
        {
            return Result<GetJobLogsResponse>.Fail(
                ErrorItem.Internal("Database error occurred while retrieving job logs", ex));
        }
    }
}
