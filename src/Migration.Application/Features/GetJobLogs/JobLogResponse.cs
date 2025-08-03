namespace Migration.Application;

public sealed record JobLogResponse(
    Guid Id,
    JobLogStatus Status,
    string Description);
