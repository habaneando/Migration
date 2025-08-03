namespace Migration.Application;

public class StartJobCommandHandler(
    IJobProcessingService JobProcessingService,
    JobId.Factory JobIdFactory)
    : ICommandHandler<StartJobCommand>
{
    public async Task ExecuteAsync(StartJobCommand startJobCommand, CancellationToken ct)
    {
        await JobProcessingService.ProcessJobAsync(JobIdFactory.Create(startJobCommand.JobId), ct)
            .ConfigureAwait(false);
    }
}
