namespace Migration.Application;

public sealed record StartJobCommand(
    string JobType,
    List<JobItemRequest> Data,
    JobMetadataRequest? Metadata)
    : ICommand<StartJob>
{
}
