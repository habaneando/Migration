namespace Migration.Common;

public static class ResultExtensions
{
    public static BaseResponse<T> ToBaseResponse<T>(
        this Result<T> result,
        int successStatusCode = StatusCodes.Status200OK,
        int errorStatusCode = StatusCodes.Status400BadRequest,
        string? message = null,
        string? requestId = null) =>
        BaseResponse<T>.FromResult(
            result,
            successStatusCode,
            errorStatusCode,
            message,
            requestId);
}
