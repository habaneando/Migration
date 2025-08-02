namespace Migration.Application;

public sealed record StartJobResponse(
    Guid JobId,
    JobStatus Status,
    long TotalItems,
    DateTime CreatedAt);
