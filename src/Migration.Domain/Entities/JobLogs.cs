namespace Migration.Domain;

public sealed record JobLogs(Guid JobId, List<JobLog> Logs)
{
}
