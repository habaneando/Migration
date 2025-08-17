namespace Migration.Application;

public class GetJobLogsQueryMapper : IQueryMapper<GetJobLogsRequest, GetJobLogsQuery>
{
    public GetJobLogsQuery ToCommand(GetJobLogsRequest getJobLogsRequest) =>
        new(getJobLogsRequest.JobId,
            getJobLogsRequest.Page,
            getJobLogsRequest.PageSize);
}
