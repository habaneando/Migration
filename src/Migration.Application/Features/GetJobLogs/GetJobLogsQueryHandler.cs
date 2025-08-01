namespace Migration.Application;

public class GetJobLogsQueryHandler : IQueryHandler<GetJobLogsQuery, JobLogsDto>
{
    public Task<JobLogsDto> ExecuteAsync(GetJobLogsQuery getJobLogsQuery, CancellationToken ct)
    {
        return Task.FromResult(new JobLogsDto());
    }
}
