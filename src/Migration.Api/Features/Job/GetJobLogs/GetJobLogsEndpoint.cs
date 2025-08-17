namespace Migration.Api;

public class GetJobLogsEndpoint
    : BaseEndpoint<GetJobLogsRequest, GetJobLogsQuery,  GetJobLogsResponse>
{
    public CacheSettings CacheSettings { get; init; }

    public ThrottleSettings ThrottlingSettings { get; init; }

    public GetJobLogsEndpoint(
        CacheSettings cacheSettings,
        ThrottleSettings throttlingSettings,
        IQueryMapper<GetJobLogsRequest, GetJobLogsQuery> QueryMapper)
        : base(QueryMapper) 
    {
        CacheSettings = cacheSettings;
        ThrottlingSettings = throttlingSettings;
    }

    public override void Configure()
    {
        Get("/jobs/{jobId}/logs");

        Group<ApiVersion1Group>();

        ResponseCache(CacheSettings.CacheDurationInSeconds);

        Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));

        AllowAnonymous();
        //Policies(...);

        Throttle(ThrottlingSettings.HitLimit, ThrottlingSettings.DurationSeconds);

        EnableAntiforgery();
    }

    public override async Task HandleAsync(GetJobLogsRequest getJobLogsRequest, CancellationToken ct)
    {
        await HandleRequestAsync(getJobLogsRequest, ct)
            .ConfigureAwait(false);
    }
}
