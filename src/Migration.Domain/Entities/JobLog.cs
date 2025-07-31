namespace Migration.Domain;

public class JobLog
{
    public required Guid ItemId { get; set; }

    public required JobItemStatus Status { get; set; }

    public required string Description { get; set; }

    public required DateTime ProcessedAt { get; set; }
}
