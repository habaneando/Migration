namespace Migration.Api;

public class StartJobEndpoint(CacheSettings CacheSettings, ThrottleSettings ThrottlingSettings)
    : Endpoint<StartJobRequest, StartJobResponse, StartJobMapper>
{
    public override void Configure()
    {
        Get("/jobs");

        Group<ApiVersion1Group>();

        ResponseCache(CacheSettings.CacheDurationInSeconds);

        Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));

        AllowAnonymous();
        //Policies(...);

        Throttle(ThrottlingSettings.HitLimit, ThrottlingSettings.DurationSeconds);

        EnableAntiforgery();
    }

    public override async Task HandleAsync(StartJobRequest startJobRequest, CancellationToken ct)
    {
        var startJobCommand = Map.ToCommand(startJobRequest);

        var startJobEntity = await startJobCommand.ExecuteAsync()
            .ConfigureAwait(false);

        var startJobResponse = Map.FromEntity(startJobEntity);

        await Send.OkAsync(startJobResponse, ct)
            .ConfigureAwait(false);
    }
}
