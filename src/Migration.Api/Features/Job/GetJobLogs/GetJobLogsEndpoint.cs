namespace Migration.Api;

public class GetJobLogsEndpoint(
    CacheSettings CacheSettings,
    ThrottleSettings ThrottlingSettings,
    GetJobLogsMapper Mapper)
    : Endpoint<GetJobLogsRequest, GetJobLogsResponse>
{
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
        var getJobLogsQuery = Mapper.ToQuery(getJobLogsRequest);

        var getJobLogsResult = await getJobLogsQuery.ExecuteAsync()
            .ConfigureAwait(false);

        var getJobLogsResponse = Mapper.FromEntity(getJobLogsResult);

        await Send.OkAsync(getJobLogsResponse, ct)
            .ConfigureAwait(false);
    }
}
