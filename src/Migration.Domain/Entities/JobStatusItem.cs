namespace Migration.Domain;

public sealed record JobStatusItem(
    Guid JobId,
    long TotalItems,
    long ProcessedItems,
    long FailedItems);
