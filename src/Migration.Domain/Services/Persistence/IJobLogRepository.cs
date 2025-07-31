namespace Migration.Domain;

public interface IJobLogRepository : IRepository
{
    Task Add(JobLog jobLog);

    Task<JobLogsDto> GetByJobId(JobId jobId, int? page, int? pageSize);
}
