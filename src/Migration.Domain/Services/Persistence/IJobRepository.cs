namespace Migration.Domain;

public interface IJobRepository : IRepository
{
    Task Add(Job job);

    Task<JobStatusDto> GetStatusById(JobId jobId);
}
