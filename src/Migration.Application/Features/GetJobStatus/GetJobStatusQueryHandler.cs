namespace Migration.Application;

public class GetJobStatusQueryHandler(IGetJobStatusService GetJobStatusService)
    : IQueryHandler<GetJobStatusQuery, JobStatusItem>
{
    public Task<JobStatusItem> ExecuteAsync(GetJobStatusQuery getJobStatusQuery, CancellationToken ct) =>
        GetJobStatusService.GetStatusByIdAsync(getJobStatusQuery.JobId);
}
