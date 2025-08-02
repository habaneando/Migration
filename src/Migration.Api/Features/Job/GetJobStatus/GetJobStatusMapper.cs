namespace Migration.Api;

public class GetJobStatusMapper : Mapper<GetJobStatusRequest, GetJobStatusResponse, JobStatusItem>
{
    public override GetJobStatusResponse FromEntity(JobStatusItem jobStatusItem) =>
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
