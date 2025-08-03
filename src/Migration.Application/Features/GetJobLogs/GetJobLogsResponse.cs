namespace Migration.Application;

public sealed record GetJobLogsResponse(
    Guid JobId,
    List<JobLogResponse> Logs);
