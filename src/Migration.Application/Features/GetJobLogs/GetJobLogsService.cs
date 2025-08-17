namespace Migration.Application;

public class GetJobLogsService(
    IJobLogRepository _jobLogRepository,
    JobId.Factory _jobIdFactory,
    GetJobLogsEntityMapper _entityMapper,
    ILogger<GetJobLogsService> _logger)
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
            var joblogs = await _jobLogRepository
                .GetByJobIdAsync(
                    _jobIdFactory.Create(guid),
                    page,
                    pageSize)
                .ConfigureAwait(false);

            return joblogs != null
                ? Result<GetJobLogsResponse>.Ok(_entityMapper.ToResponse(joblogs))
                : Result<GetJobLogsResponse>.Fail(ErrorItem.NotFound("Job not found"));
        }
        catch (Exception ex)
        {
            return Result<GetJobLogsResponse>.Fail(
                ErrorItem.Internal("Database error occurred while retrieving job logs", ex));
        }
    }
}
