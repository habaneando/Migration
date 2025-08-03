namespace Migration.Application;

public sealed record StartJobRequest(
    Guid JobId,
    string JobType,
    List<JobItemRequest> Data,
    JobMetadataRequest? Metadata);
