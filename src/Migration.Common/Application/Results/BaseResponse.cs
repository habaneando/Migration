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

    public static BaseResponse<T> Ok(
        T value,
        string? message = null,
        string? requestId = null) =>
        new(Result<T>.Ok(value),
            StatusCodes.Status200OK,
            message,
            requestId);

    public static BaseResponse<T> Created(
        T value,
        string? message = null,
        string? requestId = null) =>
        new(Result<T>.Ok(value),
            StatusCodes.Status201Created,
            message,
            requestId);

    public static BaseResponse<T> Accepted(
        T value,
        string? message = null,
        string? requestId = null) =>
        new(Result<T>.Ok(value),
            StatusCodes.Status202Accepted,
            message,
            requestId);

    public static BaseResponse<T> BadRequest(
        ErrorItem error,
        string? message = null,
        string? requestId = null) =>
        new(Result<T>.Fail(error),
            StatusCodes.Status400BadRequest,
            message,
            requestId);

    public static BaseResponse<T> BadRequest(
        IReadOnlyList<ErrorItem> errors,
        string? message = null,
        string? requestId = null) =>
        new(Result<T>.Fail(errors),
            StatusCodes.Status400BadRequest,
            message,
            requestId);

    public static BaseResponse<T> NotFound(
        string? message = null,
        string? requestId = null) =>
        new(Result<T>.Fail(new ErrorItem("NotFound", message ?? "Resource not found")),
            StatusCodes.Status404NotFound,
            message,
            requestId);

    public static BaseResponse<T> Unauthorized(
        string? message = null,
        string? requestId = null) =>
        new(Result<T>.Fail(new ErrorItem("Unauthorized", message ?? "Unauthorized access")),
            StatusCodes.Status401Unauthorized,
            message,
            requestId);

    public static BaseResponse<T> Forbidden(
        string? message = null,
        string? requestId = null) =>
        new(Result<T>.Fail(new ErrorItem("Forbidden", message ?? "Access forbidden")),
            StatusCodes.Status403Forbidden,
            message,
            requestId);

    public static BaseResponse<T> Conflict(
        ErrorItem error,
        string? message = null,
        string? requestId = null) =>
        new(Result<T>.Fail(error),
            StatusCodes.Status409Conflict,
            message,
            requestId);

    public static BaseResponse<T> InternalServerError(
        string? message = null,
        string? requestId = null) =>
        new(Result<T>.Fail(new ErrorItem("InternalServerError", message ?? "An internal server error occurred")),
            StatusCodes.Status500InternalServerError,
            message,
            requestId);

    public static BaseResponse<T> FromResult(
        Result<T> result,
        int successStatusCode = StatusCodes.Status200OK,
        int errorStatusCode = StatusCodes.Status400BadRequest,
        string? message = null,
        string? requestId = null) =>
        new(result,
            result.Success
                ? successStatusCode
                : errorStatusCode,
            message,
            requestId);
}

public sealed record BaseResponse : BaseResponse<object>
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

    public static BaseResponse Ok(
        string? message = null,
        string? requestId = null) =>
        new(Result<object>.Ok(new object()),
            StatusCodes.Status200OK,
            message,
            requestId);

    public static BaseResponse Created(
        string? message = null,
        string? requestId = null) =>
        new(Result<object>.Ok(new object()),
            StatusCodes.Status201Created,
            message,
            requestId);

    public static BaseResponse NoContent(
        string? requestId = null) =>
        new(Result<object>.Ok(
            new object()),
            StatusCodes.Status204NoContent,
            null,
            requestId);

    public static new BaseResponse BadRequest(
        ErrorItem error,
        string? message = null,
        string? requestId = null) =>
        new(Result<object>.Fail(error),
            StatusCodes.Status400BadRequest,
            message,
            requestId);

    public static new BaseResponse BadRequest(
        IReadOnlyList<ErrorItem> errors,
        string? message = null,
        string? requestId = null) =>
        new(Result<object>.Fail(errors),
            StatusCodes.Status400BadRequest,
            message,
            requestId);

    public static new BaseResponse NotFound(
        string? message = null,
        string? requestId = null) =>
        new(Result<object>.Fail(new ErrorItem("NotFound", message ?? "Resource not found")),
            StatusCodes.Status404NotFound,
            message,
            requestId);
}
