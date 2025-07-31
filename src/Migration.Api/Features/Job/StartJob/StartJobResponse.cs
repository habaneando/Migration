namespace Migration.Api;

public class StartJobResponse
{
    public Guid JobId { get; set; }

    public JobStatus Status { get; set; }

    public long TotalItems { get; set; }

    public DateTime CreatedAt { get; set; }
}
