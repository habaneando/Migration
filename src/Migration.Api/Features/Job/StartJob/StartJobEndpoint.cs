namespace Migration.Api;

public class StartJobEndpoint(
    CacheSettings _cacheSettings,
    ThrottleSettings _throttleSettings,
    ICommandMapper<StartJobRequest, StartJobCommand> _requestMapper)
    : BaseEndpoint<
        StartJobRequest,
        StartJobCommand,
        StartJobResponse>(_requestMapper)
{
    public override void Configure()
    {
        Post("/jobs");

        Group<ApiVersion1Group>();

        ResponseCache(_cacheSettings.CacheDurationInSeconds);

        Options(x => x.CacheOutput(p => p.Expire(_cacheSettings.CacheDuration)));

        AllowAnonymous();
        //Policies(...);

        Throttle(_throttleSettings.HitLimit, _throttleSettings.DurationSeconds);

        EnableAntiforgery();
    }

    public override async Task HandleAsync(StartJobRequest startJobRequest, CancellationToken ct)
    {
        await HandleRequestAsync(startJobRequest, ct)
           .ConfigureAwait(false);
    }
}
