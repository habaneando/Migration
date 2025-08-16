namespace Migration.Application;

public class GetJobLogsMapper
{
    public GetJobLogsResponse FromEntity( Result<JobLogs> jobLogs) =>
        new(jobLogs.Value.Id,
            jobLogs.Value.Logs.Select(x =>
                new JobLogResponse(
                    x.Id.Id,
                    x.Status,
                    x.Description))
            .ToList());

    public GetJobLogsQuery ToQuery(GetJobLogsRequest getJobLogsRequest) =>
        new
        (
            getJobLogsRequest.JobId,
            getJobLogsRequest.Page,
            getJobLogsRequest.PageSize
        );
}
