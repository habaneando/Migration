namespace Migration.Domain;

public class StartJob : IEntity
{
    public Guid JobId { get; private set; }

    public long TotalItems { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public StartJob(
        Guid jobId,
        long totalItems,
        DateTime createdAt)
    {
        JobId = jobId;
        TotalItems = totalItems;
        CreatedAt = createdAt;
    }
}
