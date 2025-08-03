namespace Migration.Domain;

public class JobLog
{
    public JobItemId Id { get; private set; }

    public JobLogStatus Status { get; private set; }

    public string Description { get; private set; }

    public JobLog(
        JobItemId id,
        JobLogStatus status,
        string description)
    {
        Id = id;
        Status = status;
        Description = description;
    }
}
