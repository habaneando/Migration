namespace Migration.Domain;

public sealed record JobStatusItem
{
    public Guid JobId { get; set; }

    public long TotalItems { get; set; }

    public long ProcessedItems { get; set; }

    public long FailedItems { get; set; }
}
