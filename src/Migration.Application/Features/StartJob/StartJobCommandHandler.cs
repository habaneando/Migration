namespace Migration.Application;

public class StartJobCommandHandler(IStartJobService StartJobService)
    : ICommandHandler<StartJobCommand, Result<StartJobResponse>>
{
    public Task<Result<StartJobResponse>> ExecuteAsync(StartJobCommand startJobCommand, CancellationToken ct) =>
        StartJobService.ProcessJobAsync(startJobCommand.JobId, ct);
}
