namespace Migration.Domain;

public sealed class JobMetadata : ValueObject
{
    public string? Description { get; set; }

    public string? Source { get; set; }

    public string? Target { get; set; }

    public int Priority { get; set; }

    public List<string> Tags { get; set; } = [];

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Source;
        yield return Target;
        yield return Priority;
        yield return Tags;
    }
}
