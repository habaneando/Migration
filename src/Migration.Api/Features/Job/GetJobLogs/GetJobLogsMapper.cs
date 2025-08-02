namespace Migration.Api;

public class GetJobLogsMapper : Mapper<GetJobLogsRequest, GetJobLogsResponse, JobLogs>
{
    public override GetJobLogsResponse FromEntity(JobLogs jobLogs) =>
        new(jobLogs.JobId,
            jobLogs.Logs.Select(x =>
                new JobLogResponse(
                    x.Id,
                    x.Status,
                    x.Description,
                    x.ProcessedAt)).ToList(),
            jobLogs.TotalLogs,
            jobLogs.Page,
            jobLogs.PageSize);

    public GetJobLogsQuery ToQuery(GetJobLogsRequest getJobLogsRequest) =>
        new
        (
            getJobLogsRequest.JobId,
            getJobLogsRequest.Page,
            getJobLogsRequest.PageSize
        );
}
