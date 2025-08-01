namespace Migration.Application;

public sealed record GetJobLogsQuery(
    string JobId,
    int? Page,
    int? PageSize) : IQuery<JobLogsDto>
{
}
