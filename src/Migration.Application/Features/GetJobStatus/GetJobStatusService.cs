namespace Migration.Application;

public class GetJobStatusService(
    IJobRepository _jobRepository,
    JobId.Factory _jobIdFactory,
    GetJobStatusEntityMapper _entityMapper,
    ILogger<GetJobStatusService> _logger)
    : IGetJobStatusService
{
    public async Task<Result<GetJobStatusResponse>> GetStatusByIdAsync(
        Guid guid,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var jobStatus = await _jobRepository
                .GetStatusByIdAsync(_jobIdFactory.Create(guid))
                .ConfigureAwait(false);

            return jobStatus != null
                ? Result<GetJobStatusResponse>.Ok(_entityMapper.ToResponse(jobStatus))
                : Result<GetJobStatusResponse>.Fail(ErrorItem.NotFound("Job not found"));
        }
        catch (Exception ex)
        {
            return Result<GetJobStatusResponse>.Fail(
                ErrorItem.Internal("Database error occurred while retrieving job status", ex));
        }
    }
}
