namespace Migration.Application;

public sealed record StartJobCommand(
    string JobType,
    List<JobItem> Data,
    JobMetadataDto? Metadata)
    : ICommand<StartJobDto>
{
}
