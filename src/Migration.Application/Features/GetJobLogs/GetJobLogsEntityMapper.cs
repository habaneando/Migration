namespace Migration.Application;

public class GetJobLogsEntityMapper
{
    public GetJobLogsResponse ToResponse(JobLogs jobLogs) =>
        new(jobLogs.Id,
            jobLogs.Logs.Select(x =>
                new JobLogResponse(
                    x.Id.Id,
                    x.Status,
                    x.Description))
            .ToList());
}
