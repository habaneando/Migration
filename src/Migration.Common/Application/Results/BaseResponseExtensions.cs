namespace Migration.Common;

public static class BaseResponseExtensions
{
    public static BaseResponse<T> Ok<T>(
        this BaseResponse<T> response,
        T value,
        string? message = null,
        string? requestId = null) =>
        BaseResponse<T>.Create(
            Result<T>.Ok(value),
            StatusCodes.Status200OK,
            message,
            requestId);

    public static BaseResponse<T> Created<T>(
        this BaseResponse<T> response,
        T value,
        string? message = null,
        string? requestId = null) =>
        BaseResponse<T>.Create(
            Result<T>.Ok(value),
            StatusCodes.Status201Created,
            message,
            requestId);

    public static BaseResponse<T> Accepted<T>(
       this BaseResponse<T> response,
       T value,
       string? message = null,
       string? requestId = null) =>
       BaseResponse<T>.Create(
           Result<T>.Ok(value),
           StatusCodes.Status202Accepted,
           message,
           requestId);

    public static BaseResponse<T> BadRequest<T>(
        this BaseResponse<T> response,
        ErrorItem error,
        string? message = null,
        string? requestId = null) =>
        BaseResponse<T>.Create(
            Result<T>.Fail(error),
            StatusCodes.Status400BadRequest,
            message,
            requestId);

    public static BaseResponse<T> BadRequest<T>(
        this BaseResponse<T> response,
        IReadOnlyList<ErrorItem> errors,
        string? message = null,
        string? requestId = null) =>
        BaseResponse<T>.Create(
            Result<T>.Fail(errors),
            StatusCodes.Status400BadRequest,
            message,
            requestId);

    public static BaseResponse<T> NotFound<T>(
        this BaseResponse<T> response,
        string? message = null,
        string? requestId = null) =>
        BaseResponse<T>.Create(
            Result<T>.Fail(new ErrorItem("NotFound", message ?? "Resource not found")),
            StatusCodes.Status404NotFound,
            message,
            requestId);

    public static BaseResponse<T> Unauthorized<T>(
        this BaseResponse<T> response,
        string? message = null,
        string? requestId = null) =>
        BaseResponse<T>.Create(
            Result<T>.Fail(new ErrorItem("Unauthorized", message ?? "Unauthorized access")),
            StatusCodes.Status401Unauthorized,
            message,
            requestId);

    public static BaseResponse<T> Forbidden<T>(
        this BaseResponse<T> response,
        string? message = null,
        string? requestId = null) =>
        BaseResponse<T>.Create(
            Result<T>.Fail(new ErrorItem("Forbidden", message ?? "Access forbidden")),
            StatusCodes.Status403Forbidden,
            message,
            requestId);

    public static BaseResponse<T> Conflict<T>(
        this BaseResponse<T> response,
        ErrorItem error,
        string? message = null,
        string? requestId = null) =>
        BaseResponse<T>.Create(
            Result<T>.Fail(error),
            StatusCodes.Status409Conflict,
            message,
            requestId);

    public static BaseResponse<T> InternalServerError<T>(
        this BaseResponse<T> response,
        string? message = null,
        string? requestId = null) =>
        BaseResponse<T>.Create(
            Result<T>.Fail(new ErrorItem("InternalServerError", message ?? "An internal server error occurred")),
            StatusCodes.Status500InternalServerError,
            message,
            requestId);

    public static BaseResponse<T> FromResult<T>(
        this BaseResponse<T> response,
        Result<T> result,
        int successStatusCode = StatusCodes.Status200OK,
        int errorStatusCode = StatusCodes.Status400BadRequest,
        string? message = null,
        string? requestId = null) =>
        BaseResponse<T>.Create(
            result,
            result.Success
                ? successStatusCode
                : errorStatusCode,
            message,
            requestId);

    public static BaseResponse Ok(
        this BaseResponse response,
        string? message = null,
        string? requestId = null) =>
        BaseResponse.Create(
            Result<object>.Ok(new object()),
            StatusCodes.Status200OK,
            message,
            requestId);

    public static BaseResponse Created(
        this BaseResponse response,
        string? message = null,
        string? requestId = null) =>
        BaseResponse.Create(
            Result<object>.Ok(new object()),
            StatusCodes.Status201Created,
            message,
            requestId);

    public static BaseResponse NoContent(
        this BaseResponse response,
        string? requestId = null) =>
        BaseResponse.Create(
            Result<object>.Ok(
            new object()),
            StatusCodes.Status204NoContent,
            null,
            requestId);

    public static BaseResponse BadRequest(
        this BaseResponse response,
        ErrorItem error,
        string? message = null,
        string? requestId = null) =>
        BaseResponse.Create(
            Result<object>.Fail(error),
            StatusCodes.Status400BadRequest,
            message,
            requestId);

    public static BaseResponse BadRequest(
        this BaseResponse response,
        IReadOnlyList<ErrorItem> errors,
        string? message = null,
        string? requestId = null) =>
        BaseResponse.Create(
            Result<object>.Fail(errors),
            StatusCodes.Status400BadRequest,
            message,
            requestId);

    public static BaseResponse NotFound(
        this BaseResponse response,
        string? message = null,
        string? requestId = null) =>
        BaseResponse.Create(
            Result<object>.Fail(new ErrorItem("NotFound", message ?? "Resource not found")),
            StatusCodes.Status404NotFound,
            message,
            requestId);
}
