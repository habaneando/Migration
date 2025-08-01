namespace Migration.Application;

public class StartJobCommandHandler : ICommandHandler<StartJobCommand, StartJobDto>
{
    public Task<StartJobDto> ExecuteAsync(StartJobCommand startJobCommand, CancellationToken ct)
    {
        return Task.FromResult(new StartJobDto());
    }
}
