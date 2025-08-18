namespace Migration.Api;

public class GetJobStatusEndpoint(
    CacheSettings _cacheSettings,
    ThrottleSettings _throttleSettings,
    IQueryMapper<GetJobStatusRequest, GetJobStatusQuery> _requestMapper)
    : BaseEndpoint<
        GetJobStatusRequest,
        GetJobStatusQuery,
        GetJobStatusResponse>(_requestMapper)
{
    public override void Configure()
    {
        Get("/jobs/{jobId}/status");

        Group<ApiVersion1Group>();

        ResponseCache(_cacheSettings.CacheDurationInSeconds);

        Options(x => x.CacheOutput(p => p.Expire(_cacheSettings.CacheDuration)));

        AllowAnonymous();
        //Policies(...);

        Throttle(_throttleSettings.HitLimit, _throttleSettings.DurationSeconds);

        EnableAntiforgery();
    }

    public override async Task HandleAsync(GetJobStatusRequest getJobStatusRequest, CancellationToken ct)
    {
        await HandleRequestAsync(getJobStatusRequest, ct)
            .ConfigureAwait(false);
    }
}
