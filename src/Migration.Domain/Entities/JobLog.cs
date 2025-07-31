namespace Migration.Domain;

public  class JobLog
{
    public Guid ItemId { get; set; }

    public JobItemStatus Status { get; set; }

    public string Description { get; set; }

    public DateTime ProcessedAt { get; set; }
}
