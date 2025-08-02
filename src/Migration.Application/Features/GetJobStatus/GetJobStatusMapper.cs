namespace Migration.Application;

public class GetJobStatusMapper
{
    public GetJobStatusResponse FromEntity(JobStatusItem jobStatusItem) =>
        new(jobStatusItem.JobId,
            jobStatusItem.Status,
            jobStatusItem.TotalItems,
            jobStatusItem.ProcessedItems,
            jobStatusItem.FailedItems,
            jobStatusItem.CreatedAt,
            jobStatusItem.UpdatedAt);

    public GetJobStatusQuery ToQuery(GetJobStatusRequest getJobStatusRequest) =>
        new(getJobStatusRequest.JobId);
}
