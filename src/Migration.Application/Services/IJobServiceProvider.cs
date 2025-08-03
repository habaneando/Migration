namespace Migration.Application;

public interface IJobServiceProvider
{
    IJobService? TryGet(string type);

    void Add(string type, IJobService jobService);
}
