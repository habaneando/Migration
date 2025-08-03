namespace Migration.Domain;

public interface IJobLogRepository : IRepository
{
    Task AddAsync(JobLog jobLog);

    Task<JobLogs> GetByJobIdAsync(JobId jobId, int? page, int? pageSize);
}
