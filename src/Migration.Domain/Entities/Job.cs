namespace Migration.Domain;

public class Job
{
    public JobId Id { get; private set; }

    public List<JobItem> Data { get; private set; } = [];

    public JobMetadataDto? Metadata { get; private set; }

    public Job(
        JobId jobId,
        List<JobItem> data,
        JobMetadataDto? metadata)
    {
        Id = jobId;
        Data = data;
        Metadata = metadata;
    }
}
