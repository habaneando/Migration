namespace Migration.Domain;

public sealed class JobLog : BaseEntity<JobItemId>
{
    public JobLogStatus Status { get; private set; }

    public string Description { get; private set; }

    public JobLog(
        JobItemId id,
        JobLogStatus status,
        string description) : base(id)
    {
        Status = status;
        Description = description;
    }
}
