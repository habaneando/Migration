namespace Migration.Application;

public class GetJobStatusService(
    IJobRepository JobRepository,
    JobId.Factory JobIdFactory,
    GetJobStatusMapper Mapper)
    : IGetJobStatusService
{
    public async Task<Result<GetJobStatusResponse>> GetStatusByIdAsync(
        Guid guid,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var jobStatus = await JobRepository
                .GetStatusByIdAsync(JobIdFactory.Create(guid))
                .ConfigureAwait(false);

            return jobStatus != null
                ? Result<GetJobStatusResponse>.Ok(Mapper.FromEntity(jobStatus))
                : Result<GetJobStatusResponse>.Fail(ErrorItem.NotFound("Job not found"));
        }
        catch (Exception ex)
        {
            return Result<GetJobStatusResponse>.Fail(
                ErrorItem.Internal("Database error occurred while retrieving job status", ex));
        }
    }
}
