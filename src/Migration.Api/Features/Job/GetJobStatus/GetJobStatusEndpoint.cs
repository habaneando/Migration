namespace Migration.Api;

public class GetJobStatusEndpoint
    : BaseEndpoint<GetJobStatusRequest, GetJobStatusQuery, GetJobStatusResponse>
{
    public CacheSettings CacheSettings { get; init; }

    public ThrottleSettings ThrottlingSettings { get; init; }

    public GetJobStatusEndpoint(
        CacheSettings cacheSettings,
        ThrottleSettings throttlingSettings,
        IQueryMapper<GetJobStatusRequest, GetJobStatusQuery> RequestMapper)
        : base(RequestMapper)
    {
        CacheSettings = cacheSettings;
        ThrottlingSettings = throttlingSettings;
    }

    public override void Configure()
    {
        Get("/jobs/{jobId}/status");

        Group<ApiVersion1Group>();

        ResponseCache(CacheSettings.CacheDurationInSeconds);

        Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));

        AllowAnonymous();
        //Policies(...);

        Throttle(ThrottlingSettings.HitLimit, ThrottlingSettings.DurationSeconds);

        EnableAntiforgery();
    }

    public override async Task HandleAsync(GetJobStatusRequest getJobStatusRequest, CancellationToken ct)
    {
        await HandleRequestAsync(getJobStatusRequest, ct)
            .ConfigureAwait(false);
    }
}
