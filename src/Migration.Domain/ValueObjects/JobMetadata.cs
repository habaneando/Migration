namespace Migration.Domain;

public sealed class JobMetadata : ValueObject
{
    public string? Description { get; init; }

    public string? Source { get; init; }

    public string? Target { get; init; }

    public int Priority { get; init; }

    public List<string> Tags { get; init; }

    public JobMetadata(
        string? description,
        string? source,
        string? target,
        int priority,
        List<string> tags)
    {
        Description = description?.Trim();
        Source = source?.Trim();
        Target = target?.Trim();
        Priority = priority;
        Tags = tags ?? [];
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Description;
        yield return Source;
        yield return Target;
        yield return Priority;
        yield return Tags;
    }
}
