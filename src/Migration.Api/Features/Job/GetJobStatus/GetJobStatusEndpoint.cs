namespace Migration.Api;

public class GetJobStatusEndpoint(CacheSettings CacheSettings, ThrottleSettings ThrottlingSettings)
    : Endpoint<GetJobStatusRequest, GetJobStatusResponse, GetJobStatusMapper>
{
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
        var getJobStatusCommand = Map.ToCommand(getJobStatusRequest);

        var getJobStatusEntity = await getJobStatusCommand.ExecuteAsync()
            .ConfigureAwait(false);

        var getJobStatusResponse = Map.FromEntity(getJobStatusEntity);

        await Send.OkAsync(getJobStatusResponse, ct)
            .ConfigureAwait(false);
    }
}
