namespace Migration.Application;

public class StartJobCommandHandler : ICommandHandler<StartJobCommand, StartJob>
{
    public Task<StartJob> ExecuteAsync(StartJobCommand startJobCommand, CancellationToken ct)
    {
        return Task.FromResult(new StartJob());
    }
}
