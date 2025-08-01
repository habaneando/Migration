namespace Migration.Api;

public class StartJobEndpoint : Endpoint<StartJobRequest, StartJobResponse, StartJobMapper>
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

    public override async Task HandleAsync(StartJobRequest startJobRequest, CancellationToken ct)
    {
        var startJobCommand = new StartJobCommand(
            startJobRequest.JobType,
            startJobRequest.Data,
            startJobRequest.Metadata);

        var startJobEntity = await startJobCommand.ExecuteAsync()
            .ConfigureAwait(false);

        var startJobResponse = Map.FromEntity(startJobEntity);

        await Send.OkAsync(startJobResponse, ct)
            .ConfigureAwait(false);
    }
}
