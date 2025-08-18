namespace Migration.Api;

public class GetJobLogsEndpoint(
    CacheSettings _cacheSettings,
    ThrottleSettings _throttleSettings,
    IQueryMapper<GetJobLogsRequest, GetJobLogsQuery> _requestMapper)
    : BaseEndpoint<
        GetJobLogsRequest,
        GetJobLogsQuery,
        GetJobLogsResponse>(_requestMapper)
{
    public override void Configure()
    {
        Get("/jobs/{jobId}/logs");

        Group<ApiVersion1Group>();

        ResponseCache(_cacheSettings.CacheDurationInSeconds);

        Options(x => x.CacheOutput(p => p.Expire(_cacheSettings.CacheDuration)));

        AllowAnonymous();
        //Policies(...);

        Throttle(_throttleSettings.HitLimit, _throttleSettings.DurationSeconds);

        EnableAntiforgery();
    }

    public override async Task HandleAsync(GetJobLogsRequest getJobLogsRequest, CancellationToken ct)
    {
        await HandleRequestAsync(getJobLogsRequest, ct)
            .ConfigureAwait(false);
    }
}
