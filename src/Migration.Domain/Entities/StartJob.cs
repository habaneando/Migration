namespace Migration.Domain;

public class StartJob
{
    public Guid JobId { get; set; }

    public JobStatus Status { get; set; }

    public long TotalItems { get; set; }

    public DateTime CreatedAt { get; set; }
}
