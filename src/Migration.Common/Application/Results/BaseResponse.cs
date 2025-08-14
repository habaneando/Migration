namespace Migration.Common;

public record BaseResponse<T>
{
    /// <summary>
    /// Business logic result.
    /// </summary>
    public Result<T> Result { get; init; }

    /// <summary>
    /// Http info: status code for the response.
    /// </summary>
    public int StatusCode { get; init; }

    /// <summary>
    /// Http info: unique identifier for tracing and debuging purposes.
    /// </summary>
    public string? RequestId { get; init; }

    /// <summary>
    /// Http info: when the response was created.
    /// </summary>
    public DateTime Timestamp { get; init; }

    /// <summary>
    /// Http info: optional human-readable message
    /// </summary>
    public string? Message { get; init; }

    public T? Value =>
        Result.Value;

    public IReadOnlyList<ErrorItem> Errors =>
        Result.Errors;

    public bool Success =>
        Result.Success;

    protected BaseResponse(
        Result<T> result,
        int statusCode,
        string? message = null,
        string? requestId = null)
    {
        Result = result;
        StatusCode = statusCode;
        RequestId = requestId;
        Message = message;
        Timestamp = DateTime.UtcNow;
    }

    public static BaseResponse<T> Create(
        Result<T> value,
        int statusCode,
        string? message = null,
        string? requestId = null) =>
        new(value,
            statusCode,
            message,
            requestId);
}

public sealed record BaseResponse
    : BaseResponse<object>
{
    private BaseResponse(
        Result<object> result,
        int statusCode,
        string? message = null,
        string? requestId = null)
        : base(result,
            statusCode,
            message,
            requestId) { }

    public static new BaseResponse Create(
        Result<object> result,
        int statusCode,
        string? message = null,
        string? requestId = null) =>
        new(result,
            statusCode,
            message,
            requestId);
}
