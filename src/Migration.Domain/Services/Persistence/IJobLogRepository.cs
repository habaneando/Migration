namespace Migration.Domain;

public interface IJobLogRepository : IRepository<JobLog>
{
    Task UpdateAsync(
        JobLog jobLog,
        CancellationToken cancellationToken = default);

    Task<JobLogs> GetByJobIdAsync(
        JobId jobId,
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default);
}
