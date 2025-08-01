namespace Migration.Api;

public class GetJobLogsMapper : Mapper<GetJobLogsRequest, GetJobLogsResponse, JobLogsDto>
{
    public override GetJobLogsResponse FromEntity(JobLogsDto jobLogsDto) =>
        new()
        {
            JobId = jobLogsDto.JobId,
            Logs = jobLogsDto.Logs,
            Page = jobLogsDto.Page,
            PageSize = jobLogsDto.PageSize,
            TotalLogs = jobLogsDto.TotalLogs
        };

    public GetJobLogsQuery ToQuery(GetJobLogsRequest getJobLogsRequest) =>
        new
        (
            getJobLogsRequest.JobId,
            getJobLogsRequest.Page,
            getJobLogsRequest.PageSize
        );
}
