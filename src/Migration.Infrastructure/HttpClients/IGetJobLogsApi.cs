namespace Migration.Infrastructure;

public interface IGetJobLogsApi
{
    [Get("/jobs/{jobId}/logs")]
    Task<GetJobLogsResponse> GetJobLogsAsync(Guid jobId, [Query] int? page, [Query] int? pageSize);
}
