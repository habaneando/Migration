namespace Migration.Domain;

public  class JobItem
{
    public JobItemId Id { get; private set; }

    public object Data { get; private set; }

    public JobItem(JobItemId id, object data)
    {
        Id = id;
        Data = data;
    }
}
