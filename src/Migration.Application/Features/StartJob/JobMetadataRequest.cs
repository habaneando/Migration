namespace Migration.Application;

public sealed record JobMetadataRequest(
    string? Description,
    string? Source,
    string? Target,
    int Priority,
    List<string> Tags);
