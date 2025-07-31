namespace Migration.Domain;

public class JobRepository : IJobRepository
{
    public Task Add(Job job) =>
        throw new NotImplementedException();

    public Task<JobStatusDto> GetStatusById(JobId jobId) =>
        throw new NotImplementedException();
}
