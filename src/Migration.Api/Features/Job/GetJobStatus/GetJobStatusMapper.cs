namespace Migration.Api;

public class GetJobStatusMapper : Mapper<GetJobStatusRequest, GetJobStatusResponse, JobStatusDto>
{
    public override GetJobStatusResponse FromEntity(JobStatusDto jobStatusDto) =>
        new()
        {
            JobId = jobStatusDto.JobId,
            Status = jobStatusDto.Status,
            CreatedAt = jobStatusDto.CreatedAt,
            UpdatedAt = jobStatusDto.UpdatedAt,
            ProcessedItems = jobStatusDto.ProcessedItems,
            FailedItems = jobStatusDto.FailedItems,
            TotalItems = jobStatusDto.TotalItems
        };

    public GetJobStatusCommand ToCommand(GetJobStatusRequest getJobStatusRequest) =>
        new(getJobStatusRequest.JobId);
}
