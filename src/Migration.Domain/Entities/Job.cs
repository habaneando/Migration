namespace Migration.Domain;

public class Job
{
    public JobId Id { get; private set; }

    public List<JobItem> Data { get; private set; } = [];

    public JobMetadata? Metadata { get; private set; }

    public Job(
        JobId jobId,
        List<JobItem> data,
        JobMetadata? metadata)
    {
        Id = jobId;
        Data = data;
        Metadata = metadata;
    }
}
