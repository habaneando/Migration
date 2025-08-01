namespace Migration.Api;

public class GetJobLogsEndpoint(CacheSettings CacheSettings, ThrottleSettings ThrottlingSettings)
    : Endpoint<GetJobLogsRequest, GetJobLogsResponse, GetJobLogsMapper>
{
    public override void Configure()
    {
        Get("/jobs/{jobId}/logs?page={page}&pageSize={pageSize}");

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
        var getJobLogsQuery = Map.ToQuery(getJobLogsRequest);

        var getJobLogsEntity = await getJobLogsQuery.ExecuteAsync()
            .ConfigureAwait(false);

        var getJobLogsResponse = Map.FromEntity(getJobLogsEntity);

        await Send.OkAsync(getJobLogsResponse, ct)
            .ConfigureAwait(false);
    }
}
