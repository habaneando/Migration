namespace Migration.Api;

public class GetJobLogsEndpoint : Endpoint<GetJobLogsRequest, GetJobLogsResponse, GetJobLogsMapper>
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

    public override async Task HandleAsync(GetJobLogsRequest getJobLogsRequest, CancellationToken ct)
    {
        var getJobLogsCommand = new GetJobLogsCommand(
            getJobLogsRequest.JobId,
            getJobLogsRequest.Page,
            getJobLogsRequest.PageSize);

        var getJobLogsEntity = await getJobLogsCommand.ExecuteAsync()
            .ConfigureAwait(false);

        var getJobLogsResponse = Map.FromEntity(getJobLogsEntity);

        await Send.OkAsync(getJobLogsResponse, ct)
            .ConfigureAwait(false);
    }
}
