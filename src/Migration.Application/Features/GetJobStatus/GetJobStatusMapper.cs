namespace Migration.Application;

public class GetJobStatusMapper
{
    public GetJobStatusResponse FromEntity(JobStatusItem jobStatusItem) =>
        new(jobStatusItem.JobId,
            jobStatusItem.TotalItems,
            jobStatusItem.ProcessedItems,
            jobStatusItem.FailedItems);

    public GetJobStatusQuery ToQuery(GetJobStatusRequest getJobStatusRequest) =>
        new(getJobStatusRequest.JobId);
}
