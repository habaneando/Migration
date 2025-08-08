namespace Migration.Domain;

public class MockJobRepository(
    JobId.Factory JobIdFactory,
    JobItemId.Factory JobItemIdFactory)
    : IJobRepository
{
    public Task AddAsync(Job job, CancellationToken cancellationToken = default) =>
        throw new NotImplementedException();

    public Task<Job> GetByIdAsync(JobId jobId, CancellationToken cancellationToken = default)
    {
        var id = JobIdFactory.Create(jobId.Id);

        var jobType = JobType.Bulk;

        var items = new List<JobItem>
        {
            new JobItem(JobItemIdFactory.Create(), "item1", JobItemStatus.Pending),
            new JobItem(JobItemIdFactory.Create(), "item2", JobItemStatus.Pending),
            new JobItem(JobItemIdFactory.Create(), "item3", JobItemStatus.Pending)
        };

        return Task.FromResult(new Job(id, jobType, items, null));
    }

    public Task<JobStatusItem> GetStatusByIdAsync(JobId jobId, CancellationToken cancellationToken = default) =>
        Task.FromResult(new JobStatusItem(jobId.Id, 10, 5, 3));
}
