namespace Migration.Application;

public sealed record StartJobRequest(
    string JobType,
    List<JobItemRequest> Data,
    JobMetadataRequest? Metadata);
