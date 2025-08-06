namespace Migration.Infrastructure;

public interface IStartJobApi
{
    [Post("/jobs")]
    Task<StartJobResponse> StartJobAsync([Body] StartJobRequest startJobRequest);
}
