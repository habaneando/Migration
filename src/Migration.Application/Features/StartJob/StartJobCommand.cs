namespace Migration.Application;

public sealed record StartJobCommand(
    Guid JobId,
    string JobType,
    List<JobItemRequest> Data,
    JobMetadataRequest? Metadata) : ICommand<Result<StartJobResponse>>
{
}
