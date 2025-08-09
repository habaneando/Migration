namespace Migration.Domain;

public sealed class JobItemId : ValueObject, IComparable<JobItemId>
{
    public Guid Id { get; set; }

    private JobItemId(Guid guid)
    {
        Id = guid;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }

    public int CompareTo(JobItemId? other)
    {
        if (other is null) return 1;

        return Id.CompareTo(other.Id);
    }

    public class Factory()
    {
        public JobItemId Create() =>
            new(Guid.NewGuid());

        public JobItemId Create(Guid guid) =>
            (guid != Guid.Empty)
                ? new(guid)
                : throw new InvalidJobItemIdCreationException();
    }
}
