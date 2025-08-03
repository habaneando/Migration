namespace Migration.Domain;

public class MockJobRepository : IJobRepository
{
    public Task AddAsync(Job job, CancellationToken cancellationToken = default) =>
        throw new NotImplementedException();

    public Task<Job> GetByIdAsync(JobId jobId, CancellationToken cancellationToken = default) =>
        throw new NotImplementedException();

    public Task<JobStatusItem> GetStatusByIdAsync(JobId jobId, CancellationToken cancellationToken = default) =>
        Task.FromResult(new JobStatusItem(jobId.Id, 10, 5, 3));
}
