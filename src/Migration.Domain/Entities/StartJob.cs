namespace Migration.Domain;

public sealed class StartJob : BaseEntity<Guid>
{
    public long TotalItems { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public StartJob(
        Guid jobId,
        long totalItems,
        DateTime createdAt) : base(jobId)
    {
        TotalItems = totalItems;
        CreatedAt = createdAt;
    }
}
