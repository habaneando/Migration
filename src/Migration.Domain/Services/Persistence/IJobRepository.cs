namespace Migration.Domain;

public interface IJobRepository : IRepository
{
    Task Add(Job job);

    Task<JobStatusItem> GetStatusById(JobId jobId);
}
