namespace Migration.Application;

public class GetJobStatusEntityMapper
{
    public GetJobStatusResponse ToResponse(JobStatusItem jobStatusItem) =>
        new(jobStatusItem.Id,
            jobStatusItem.TotalItems,
            jobStatusItem.ProcessedItems,
            jobStatusItem.FailedItems);
}
