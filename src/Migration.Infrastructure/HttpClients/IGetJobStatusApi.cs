namespace Migration.Infrastructure;

public interface IGetJobStatusApi
{
    [Get("/jobs/{jobId}/status")]
    Task<GetJobStatusResponse> GetJobStatusAsync(Guid jobId);
}
