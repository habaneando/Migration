namespace Migration.Application;

public class StartJobCommandHandler(IStartJobService StartJobService)
    : ICommandHandler<StartJobCommand>
{
    public Task ExecuteAsync(StartJobCommand startJobCommand, CancellationToken ct) =>
        StartJobService.ProcessJobAsync(startJobCommand.JobId, ct);
}
