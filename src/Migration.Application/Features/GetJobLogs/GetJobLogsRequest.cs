namespace Migration.Application;

public sealed record GetJobLogsRequest(
    Guid JobId,
    int? Page,
    int? PageSize);
