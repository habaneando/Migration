namespace Migration.Application;

public class GetJobStatusQueryHandler : IQueryHandler<GetJobStatusQuery, JobStatusDto>
{
    public Task<JobStatusDto> ExecuteAsync(GetJobStatusQuery getJobStatusQuery, CancellationToken ct)
    {
        return Task.FromResult(new JobStatusDto());
    }
}
