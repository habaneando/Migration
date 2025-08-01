namespace Migration.Api;

public class GetJobStatusEndpoint : Endpoint<GetJobStatusRequest, GetJobStatusResponse, GetJobStatusMapper>
{
    //public override void Configure()
    //{
    //    Get("/exchange-rates/{currency}/{symbols}/{amount}");

    //    Group<ApiVersion1Group>();

    //    ResponseCache(CacheSettings.CacheDurationInSeconds);

    //    Options(x => x.CacheOutput(p => p.Expire(CacheSettings.CacheDuration)));

    //    AllowAnonymous();
    //    //Policies(CurrencyPolicy.Converter);

    //    Throttle(ThrottlingSettings.HitLimit, ThrottlingSettings.DurationSeconds);

    //    EnableAntiforgery();
    //}

    public override async Task HandleAsync(GetJobStatusRequest getJobStatusRequest, CancellationToken ct)
    {
        var getJobStatusCommand = new GetJobStatusCommand(getJobStatusRequest.JobId);

        var getJobStatusEntity = await getJobStatusCommand.ExecuteAsync()
            .ConfigureAwait(false);

        var getJobStatusResponse = Map.FromEntity(getJobStatusEntity);

        await Send.OkAsync(getJobStatusResponse, ct)
            .ConfigureAwait(false);
    }
}
