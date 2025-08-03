namespace Migration.Domain;

public sealed record JobId
{
    public Guid Id { get; set; }

    private JobId(Guid guid)
    {
        Id = guid;
    }

    public class Factory()
    {
        public JobId Create() =>
            new(Guid.NewGuid());

        public JobId Create(Guid guid) =>
            (guid != Guid.Empty)
                ? new(guid)
                : throw new InvalidJobIdCreationException();
    }
}
