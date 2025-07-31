namespace Migration.Domain;

public class JobLog
{
    public Guid Id { get; private set; }

    public JobItemStatus Status { get; private set; }

    public string Description { get; private set; }

    public DateTime ProcessedAt { get; private set; }

    public JobLog(
        Guid id,
        JobItemStatus status,
        string description,
        DateTime processedAt)
    {
        Id = id;
        Status = status;
        Description = description;
        ProcessedAt = processedAt;
    }
}
