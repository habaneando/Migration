namespace Migration.Domain;

public sealed class JobItem : BaseEntity<JobItemId>
{
    public object Data { get; private set; }

    public JobItemStatus Status { get; private set; }

    public JobItem(
        JobItemId id,
        object data,
        JobItemStatus status) : base(id)
    {
        Data = data;
        Status = status;
    }
}
