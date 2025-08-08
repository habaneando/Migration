namespace Migration.Domain;

public class JobLogs : IEntity
{
    public Guid JobId { get; private set; }

    public List<JobLog> Logs { get; private set; }

    public JobLogs(Guid jobId, List<JobLog> logs)
    {
        JobId = jobId;
        Logs = logs;
    }
}
