namespace Migration.Domain;

public sealed class JobLogs : BaseEntity<Guid>
{
    public List<JobLog> Logs { get; private set; }

    public JobLogs(Guid jobId, List<JobLog> logs) : base(jobId)
    {
        Logs = logs;
    }
}
