namespace Migration.Infrastructure;

public class JobServiceProvider : IJobServiceProvider
{
    private Dictionary<string, IJobService> Factories { get; init; }

    public JobServiceProvider()
    {
        Factories = [];
    }

    public IJobService? Get(string type) =>
        Factories.TryGetValue(type, out var factory)
            ? factory
            : null;

    public void Add(string type, IJobService jobService)
    {
        Factories.TryAdd(type.ToUpper(), jobService);
    }
}
