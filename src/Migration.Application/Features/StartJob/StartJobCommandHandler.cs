namespace Migration.Application;

public class StartJobCommandHandler(IJobProcessingService JobProcessingService)
    : ICommandHandler<StartJobCommand>
{
    public Task ExecuteAsync(StartJobCommand startJobCommand, CancellationToken ct) =>
        JobProcessingService.ProcessJobAsync(startJobCommand.JobId, ct);
}
