namespace Migration.Application;

public class GetJobLogsMapper
{
    public GetJobLogsResponse FromEntity(JobLogs jobLogs) =>
        new(jobLogs.Id,
            jobLogs.Logs.Select(x =>
                new JobLogResponse(
                    x.Id.Id,
                    x.Status,
                    x.Description))
            .ToList());
}
