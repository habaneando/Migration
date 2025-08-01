namespace Migration.Application;

public sealed record GetJobLogsCommand(
    string JobId,
    int? Page,
    int? PageSize) : ICommand<JobLogsDto>
{
}
