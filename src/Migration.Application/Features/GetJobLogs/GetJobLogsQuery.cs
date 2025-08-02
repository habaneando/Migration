namespace Migration.Application;

public sealed record GetJobLogsQuery(
    Guid JobId,
    int? Page,
    int? PageSize) : IQuery<JobLogs>
{
}
