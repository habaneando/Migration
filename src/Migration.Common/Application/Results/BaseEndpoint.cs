namespace Migration.Common;

public abstract class BaseEndpoint<TRequest, TQuery, TResponse>(
    IQueryMapper<TRequest, TQuery> QueryMapper)
    : Endpoint<TRequest, BaseResponse<TResponse>>
    where TRequest : notnull
    where TQuery : IQuery<Result<TResponse>>
    where TResponse : notnull
{
    public async Task HandleRequestAsync(TRequest request, CancellationToken ct)
    {
        var query = QueryMapper.ToQuery(request);

        var result = await query.ExecuteAsync()
            .ConfigureAwait(false);

        var response = ResponseFactory.Create(result);

        await SendResponseAsync(response, ct)
            .ConfigureAwait(false);
    }

    public async Task SendResponseAsync<TData>(
        BaseResponse<TData> baseResponse,
        CancellationToken ct = default)
    {
        HttpContext.Response.StatusCode = baseResponse.StatusCode;

        await HttpContext.Response.WriteAsJsonAsync(baseResponse, ct)
            .ConfigureAwait(false);
    }

    public async Task SendResponseAsync(
        BaseResponse baseResponse,
        CancellationToken ct = default)
    {
        HttpContext.Response.StatusCode = baseResponse.StatusCode;

        await HttpContext.Response.WriteAsJsonAsync(baseResponse, ct)
            .ConfigureAwait(false);
    }
}
