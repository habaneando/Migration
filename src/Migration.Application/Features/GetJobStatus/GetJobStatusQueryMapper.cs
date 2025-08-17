namespace Migration.Application;

public class GetJobStatusQueryMapper : IQueryMapper<GetJobStatusRequest, GetJobStatusQuery>
{
    public GetJobStatusQuery ToCommand(GetJobStatusRequest getJobStatusRequest) =>
        new(getJobStatusRequest.JobId);
}
