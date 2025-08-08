namespace Migration.Domain;

public class Job : IEntity
{
    public JobId Id { get; private set; }

    public JobType Type { get; private set; }

    public List<JobItem>? Data { get; private set; } = [];

    public JobMetadata? Metadata { get; private set; }

    public Job(
        JobId jobId,
        JobType jobType,
        List<JobItem>? data,
        JobMetadata? metadata)
    {
        Id = jobId;
        Type = jobType;
        Data = data;
        Metadata = metadata;
    }

    public bool HasData =>
        Data is not null && Data?.Count > 0;

    public bool HasMetadata =>
        Metadata is not null;

    public int TotalItems =>
        Data?.Count ?? 0;
}
