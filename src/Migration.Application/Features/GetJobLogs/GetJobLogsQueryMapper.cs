namespace Migration.Application;

public class GetJobLogsQueryMapper : IQueryMapper<GetJobLogsRequest, GetJobLogsQuery>
{
    public GetJobLogsQuery ToCommand(GetJobLogsRequest request) =>
        new
        (
            request.JobId,
            request.Page,
            request.PageSize
        );
}
