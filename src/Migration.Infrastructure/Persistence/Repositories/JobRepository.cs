namespace Migration.Domain;

public class JobRepository : IJobRepository
{
    public Task AddAsync(Job job, CancellationToken cancellationToken = default) =>
        throw new NotImplementedException();

    public Task<Job> GetByIdAsync(JobId jobId, CancellationToken cancellationToken = default) =>
        throw new NotImplementedException();

    public Task<JobStatusItem> GetStatusByIdAsync(JobId jobId, CancellationToken cancellationToken = default) =>
        throw new NotImplementedException();
}
