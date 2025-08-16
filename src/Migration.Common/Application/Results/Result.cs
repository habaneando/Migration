namespace Migration.Common;

public sealed record Result<TData>
{
    public TData? Data { get; init; }

    public IReadOnlyList<ErrorItem> Errors { get; init; }

    [JsonIgnore]
    public bool Success =>
        Data is not null &&
        Errors.Count == 0;

    private Result(TData? data, IReadOnlyList<ErrorItem> errors)
    {
        Data = data;
        Errors = errors ?? Enumerable.Empty<ErrorItem>().ToList();
    }

    public static Result<TData> Ok(TData data) =>
        new(data,
            Enumerable.Empty<ErrorItem>().ToList());

    public static Result<TData> Fail(ErrorItem error) =>
        new(default,
            error is not null
                ? [error]
                : Enumerable.Empty<ErrorItem>().ToList());

    public static Result<TData> Fail(IReadOnlyList<ErrorItem> errors) =>
        new(default,
            errors?.ToList() ?? Enumerable.Empty<ErrorItem>().ToList());

    public BaseResponse<TData> ToBaseResponse(
       int successStatusCode = StatusCodes.Status200OK,
       int errorStatusCode = StatusCodes.Status400BadRequest,
       string? message = null,
       string? requestId = null) =>
       BaseResponse<TData>.FromResult(
           this,
           successStatusCode,
           errorStatusCode,
           message,
           requestId);
}
