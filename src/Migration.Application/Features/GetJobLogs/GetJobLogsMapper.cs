namespace Migration.Application;

public class GetJobLogsMapper
{
    public GetJobLogsResponse FromEntity(JobLogs jobLogs) =>
        new(jobLogs.JobId,
            jobLogs.Logs.Select(x =>
                new JobLogResponse(
                    x.Id.Id,
                    x.Status,
                    x.Description)).ToList(),
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
