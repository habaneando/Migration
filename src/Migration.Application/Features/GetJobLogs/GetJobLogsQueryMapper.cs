namespace Migration.Application;

public class GetJobLogsQueryMapper : IQueryMapper<GetJobLogsRequest, GetJobLogsQuery>
{
    public GetJobLogsQuery ToQuery(GetJobLogsRequest request) =>
        new
        (
            request.JobId,
            request.Page,
            request.PageSize
        );
}
