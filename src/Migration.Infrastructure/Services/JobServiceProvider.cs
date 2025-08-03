namespace Migration.Infrastructure;

public class JobServiceProvider : IJobServiceProvider
{
    private Dictionary<string, IJobService> Factories { get; init; }

    public JobServiceProvider()
    {
        Factories = [];
    }

    public IJobService? TryGet(string type)
    {
        if (string.IsNullOrWhiteSpace(type))
            return null;

        return Factories.TryGetValue(type.ToUpperInvariant(), out var factory)
            ? factory
            : null;
    }

    public void Add(string type, IJobService jobService)
    {
        if (string.IsNullOrWhiteSpace(type))
            return;

        Factories.TryAdd(type.ToUpperInvariant(), jobService);
    }
}
