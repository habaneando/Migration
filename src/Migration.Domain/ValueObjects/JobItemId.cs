namespace Migration.Domain;

public sealed record JobItemId
{
    public Guid Id { get; set; }

    private JobItemId(Guid guid)
    {
        Id = guid;
    }

    public class Factory()
    {
        public JobItemId Create() =>
            new(Guid.NewGuid());
    }
}
