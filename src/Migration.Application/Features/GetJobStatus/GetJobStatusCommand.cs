namespace Migration.Application;

public sealed record GetJobStatusCommand(string JobId) : ICommand<JobStatusDto>
{
}
