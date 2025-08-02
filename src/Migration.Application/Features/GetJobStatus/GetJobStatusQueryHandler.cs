namespace Migration.Application;

public class GetJobStatusQueryHandler : IQueryHandler<GetJobStatusQuery, JobStatusItem>
{
    public Task<JobStatusItem> ExecuteAsync(GetJobStatusQuery getJobStatusQuery, CancellationToken ct)
    {
        return Task.FromResult(new JobStatusItem());
    }
}
