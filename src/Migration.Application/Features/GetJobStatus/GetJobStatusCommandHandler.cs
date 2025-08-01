namespace Migration.Application;

public class GetJobStatusCommandHandler : ICommandHandler<GetJobStatusCommand, JobStatusDto>
{
    public Task<JobStatusDto> ExecuteAsync(GetJobStatusCommand getJobStatusCommand, CancellationToken ct)
    {
        return Task.FromResult(new JobStatusDto());
    }
}
