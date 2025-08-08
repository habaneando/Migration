namespace Migration.Domain;

public class JobStatusItem : IEntity
{
    public Guid JobId { get; private set; }

    public long TotalItems { get; private set; }

    public long ProcessedItems { get; private set; }

    public long FailedItems { get; private set; }

    public JobStatusItem(
        Guid jobId,
        long totalItems,
        long processedItems,
        long failedItems)
    {
        JobId = jobId;
        TotalItems = totalItems;
        ProcessedItems = processedItems;
        FailedItems = failedItems;
    }
}
