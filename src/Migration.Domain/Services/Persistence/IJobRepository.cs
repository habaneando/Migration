namespace Migration.Domain;

public interface IJobRepository : IRepository
{
    Task AddAsync(Job job, CancellationToken cancellationToken = default);

    Task<Job> GetByIdAsync(JobId jobId, CancellationToken cancellationToken = default);

    Task<JobStatusItem> GetStatusByIdAsync(JobId jobId, CancellationToken cancellationToken = default);
}
