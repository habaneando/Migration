namespace Migration.Domain;

public class JobLogRepository : IJobLogRepository
{
    public Task Add(JobLog jobLog) =>
        throw new NotImplementedException();

    public Task<JobLogs> GetByJobId(JobId jobId, int? page, int? pageSize) =>
        throw new NotImplementedException();
}
