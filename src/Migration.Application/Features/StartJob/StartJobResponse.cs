namespace Migration.Application;

public sealed record StartJobResponse(
    Guid JobId,
    long TotalItems,
    DateTime CreatedAt);
