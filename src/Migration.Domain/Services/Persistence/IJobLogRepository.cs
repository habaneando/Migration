namespace Migration.Domain;

public interface IJobLogRepository : IRepository
{
    Task UpdateAsync(JobLog jobLog);

    Task<JobLogs> GetByJobIdAsync(JobId jobId, int? page, int? pageSize);
}
