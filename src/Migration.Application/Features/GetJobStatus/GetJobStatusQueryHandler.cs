namespace Migration.Application;

public class GetJobStatusQueryHandler(IGetJobStatusService GetJobStatusService)
    : IQueryHandler<GetJobStatusQuery, Result<GetJobStatusResponse>>
{
    public Task<Result<GetJobStatusResponse>> ExecuteAsync(GetJobStatusQuery getJobStatusQuery, CancellationToken ct) =>
        GetJobStatusService.GetStatusByIdAsync(getJobStatusQuery.JobId);
}
