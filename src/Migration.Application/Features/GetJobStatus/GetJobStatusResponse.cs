namespace Migration.Application;

public sealed record GetJobStatusResponse(
    Guid JobId,
    long TotalItems,
    long ProcessedItems,
    long FailedItems);    
