namespace Migration.Application;

public sealed record GetJobStatusQuery(string JobId) : IQuery<JobStatusDto>
{
}
