namespace Migration.Common;

public abstract class BaseEndpoint<TRequest, TCommand, TResponse>(
    IRequestMapper<TRequest, TCommand> _requestMapper)
    : Endpoint<TRequest, BaseResponse<TResponse>>
    where TRequest : notnull
    where TCommand : ICommand<Result<TResponse>>
    where TResponse : notnull
{
    public async Task HandleRequestAsync(TRequest request, CancellationToken ct)
    {
        var command = _requestMapper.ToCommand(request);

        var result = await command.ExecuteAsync()
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
