namespace Migration.Application;

public class GetJobStatusService(IJobRepository JobRepository, JobId.Factory JobIdFactory)
    : IGetJobStatusService
{
    public Task<JobStatusItem> GetStatusByIdAsync(Guid guid, CancellationToken cancellationToken = default) =>
        JobRepository.GetStatusByIdAsync(JobIdFactory.Create(guid));
}
