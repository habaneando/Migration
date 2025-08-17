namespace Migration.Application;

public sealed record GetJobStatusQuery(Guid JobId) : IQuery<Result<GetJobStatusResponse>>
{
}
