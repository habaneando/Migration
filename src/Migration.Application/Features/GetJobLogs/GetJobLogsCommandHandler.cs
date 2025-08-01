namespace Migration.Application;

public class GetJobLogsCommandHandler : ICommandHandler<GetJobLogsCommand, JobLogsDto>
{
    public Task<JobLogsDto> ExecuteAsync(GetJobLogsCommand getJobLogsCommand, CancellationToken ct)
    {
        return Task.FromResult(new JobLogsDto());
    }
}
