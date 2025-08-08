namespace Migration.Domain;

public class JobItem : IEntity
{
    public JobItemId Id { get; private set; }

    public object Data { get; private set; }

    public JobItemStatus Status { get; private set; }

    public JobItem(
        JobItemId id,
        object data,
        JobItemStatus status)
    {
        Id = id;
        Data = data;
        Status = status;
    }
}
