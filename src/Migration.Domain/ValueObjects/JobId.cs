namespace Migration.Domain;

public sealed class JobId : ValueObject, IComparable<JobId>
{
    public Guid Id { get; init; }

    private JobId(Guid guid)
    {
        Id = guid;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }

    public int CompareTo(JobId? other)
    {
        if (other is null) return 1;

        return Id.CompareTo(other.Id);
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
