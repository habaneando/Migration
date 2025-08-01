namespace Migration.Domain;

public class StartJobDto
{
    public Guid JobId { get; set; }

    public JobStatus Status { get; set; }

    public long TotalItems { get; set; }

    public DateTime CreatedAt { get; set; }
}
