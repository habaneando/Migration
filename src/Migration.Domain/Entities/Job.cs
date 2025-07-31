namespace Migration.Domain;

public  class Job
{
    public JobId Id { get; set; }

    public List<JobItem> Data { get; set; }

    public JobMetadata? Metadata { get; set; }
}
