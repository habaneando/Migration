namespace Migration.Application;

public class GetJobStatusMapper
{
    public GetJobStatusResponse FromEntity(JobStatusItem jobStatusItem) =>
        new(jobStatusItem.Id,
            jobStatusItem.TotalItems,
            jobStatusItem.ProcessedItems,
            jobStatusItem.FailedItems);
}
