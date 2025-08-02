namespace Migration.Domain;

public sealed record JobLogs
{
    public Guid JobId { get; set; }

    public List<JobLog> Logs { get; set; } = [];

    public long TotalLogs { get; set; }

    public int? Page { get; set; }

    public int? PageSize { get; set; }
}
