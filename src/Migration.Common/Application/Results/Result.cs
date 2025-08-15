namespace Migration.Common;

public sealed record Result<T>
{
    public T? Value { get; init; }

    public IReadOnlyList<ErrorItem> Errors { get; init; }

    public bool Success =>
        Value is not null &&
        Errors.Count == 0;

    private Result(T? value, IReadOnlyList<ErrorItem> errors)
    {
        Value = value;
        Errors = errors ?? Enumerable.Empty<ErrorItem>().ToList();
    }

    public static Result<T> Ok(T value) =>
        new(value, Enumerable.Empty<ErrorItem>().ToList());

    public static Result<T> Fail(ErrorItem error) =>
        new(default,
            error is not null
                ? [error]
                : Enumerable.Empty<ErrorItem>().ToList());

    public static Result<T> Fail(IReadOnlyList<ErrorItem> errors) =>
        new(default,
            errors?.ToList() ?? Enumerable.Empty<ErrorItem>().ToList());

    public BaseResponse<T> ToBaseResponse(
       int successStatusCode = StatusCodes.Status200OK,
       int errorStatusCode = StatusCodes.Status400BadRequest,
       string? message = null,
       string? requestId = null) =>
       BaseResponse<T>.FromResult(
           this,
           successStatusCode,
           errorStatusCode,
           message,
           requestId);
}
