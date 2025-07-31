namespace Migration.Domain;

public class Job
{
    public required JobId Id { get; set; }

    public List<JobItem> Data { get; set; } = [];

    public JobMetadataDto? Metadata { get; set; }
}
