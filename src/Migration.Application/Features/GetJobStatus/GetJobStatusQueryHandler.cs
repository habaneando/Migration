namespace Migration.Application;

public class GetJobStatusQueryHandler(
    IJobRepository JobRepository,
    JobId.Factory JobIdFactory)
    : IQueryHandler<GetJobStatusQuery, JobStatusItem>
{
    public async Task<JobStatusItem> ExecuteAsync(GetJobStatusQuery getJobStatusQuery, CancellationToken ct)
    {
        var jobStatusItem = await JobRepository.GetStatusByIdAsync(JobIdFactory.Create(getJobStatusQuery.JobId));

        return jobStatusItem;
    }
}
