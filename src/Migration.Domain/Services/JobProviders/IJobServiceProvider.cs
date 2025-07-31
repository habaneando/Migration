namespace Migration.Domain;

public interface IJobServiceProvider
{
    IJobService? Get(string type);

    void Add(string type, IJobService jobService);
}
