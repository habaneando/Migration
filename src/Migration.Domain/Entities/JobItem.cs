namespace Migration.Domain;

public  class JobItem
{
    public required JobItemId Id { get; set; }

    public required object Data { get; set; }
}
