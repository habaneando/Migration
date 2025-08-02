namespace Migration.Application;

public sealed record JobLogResponse(
    Guid Id,
    JobItemStatus Status,
    string Description,
    DateTime ProcessedAt);
