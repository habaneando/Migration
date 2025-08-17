namespace Migration.Api;

public class StartJobEndpoint
    : BaseEndpoint<StartJobRequest, StartJobCommand, StartJobResponse>
{
    public CacheSettings CacheSettings { get; init; }

    public ThrottleSettings ThrottlingSettings { get; init; }

    public StartJobEndpoint(
        CacheSettings cacheSettings,
        ThrottleSettings throttlingSettings,
        ICommandMapper<StartJobRequest, StartJobCommand> RequestMapper)
        : base(RequestMapper)
    {
        CacheSettings = cacheSettings;
        ThrottlingSettings = throttlingSettings;
    }

    public override void Configure()
    {
        Post("/jobs");

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
        await HandleRequestAsync(startJobRequest, ct)
           .ConfigureAwait(false);
    }
}
