namespace Migration.Infrastructure;

public interface IJobLogsApi
{
    [Get("/jobs/{jobId}/logs")]
    Task<GetJobLogsResponse> GetJobLogsAsync([Query] Guid jobId);
}
