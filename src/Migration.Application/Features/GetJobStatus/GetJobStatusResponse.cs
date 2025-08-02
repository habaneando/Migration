namespace Migration.Application;

public sealed record GetJobStatusResponse(
    Guid JobId,
    JobStatus Status,
    long TotalItems,
    long ProcessedItems,
    long FailedItems,
    DateTime CreatedAt,
    DateTime UpdatedAt);    
