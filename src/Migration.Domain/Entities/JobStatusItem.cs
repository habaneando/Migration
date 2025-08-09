namespace Migration.Domain;

public sealed class JobStatusItem : BaseEntity<Guid>
{
    public long TotalItems { get; private set; }

    public long ProcessedItems { get; private set; }

    public long FailedItems { get; private set; }

    public JobStatusItem(
        Guid jobId,
        long totalItems,
        long processedItems,
        long failedItems) : base(jobId)
    {
        TotalItems = totalItems;
        ProcessedItems = processedItems;
        FailedItems = failedItems;
    }
}
