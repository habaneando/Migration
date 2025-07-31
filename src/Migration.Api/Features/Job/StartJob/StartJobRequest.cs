namespace Migration.Api;

public class StartJobRequest
{
    public required string JobType { get; set; }

    public required List<JobItem> Data { get; set; }

    public JobMetadataDto? Metadata { get; set; }
}
