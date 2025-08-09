namespace Migration.Domain;

public sealed class Job : BaseEntity<JobId>
{
    public JobType Type { get; private set; }

    public List<JobItem>? Data { get; private set; } = [];

    public JobMetadata? Metadata { get; private set; }

    public Job(
        JobId jobId,
        JobType jobType,
        List<JobItem>? data,
        JobMetadata? metadata) : base(jobId)
    {
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
