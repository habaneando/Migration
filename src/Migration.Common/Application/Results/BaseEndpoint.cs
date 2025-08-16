namespace Migration.Common;

public abstract class BaseEndpoint<TRequest, TResponse>
    : Endpoint<TRequest, BaseResponse<TResponse>>
    where TRequest : notnull
{
    public BaseResponse<T> ToResponse<T>(
        Result<T> result,
        string? requestId = null)
    {
        if (result.Success)
        {
            return BaseResponse<T>.Ok(result.Value!, requestId: requestId);
        }

        var firstError = result.Errors.FirstOrDefault();

        var response = firstError?.Code switch
        {
            ErrorCode.ValidationError => BaseResponse<T>.BadRequest(result.Errors, requestId: requestId),
            ErrorCode.BusinessRuleViolation => BaseResponse<T>.BadRequest(result.Errors, requestId: requestId),
            ErrorCode.ExternalServiceError => BaseResponse<T>.BadRequest(firstError, requestId: requestId),
            ErrorCode.NotFound => BaseResponse<T>.NotFound(firstError.Message, requestId),
            ErrorCode.Unauthorized => BaseResponse<T>.Unauthorized(firstError.Message, requestId),
            ErrorCode.Forbidden => BaseResponse<T>.Forbidden(firstError.Message, requestId),
            ErrorCode.Conflict => BaseResponse<T>.Conflict(firstError, requestId: requestId),
            _ => BaseResponse<T>.InternalServerError(firstError?.Message, requestId)
        };

        return response;
    }

    public BaseResponse<T> ToResponse<T>(
        Result<T> result,
        int successStatusCode,
        string? requestId = null)
    {
        if (result.Success)
        {
            return successStatusCode switch
            {
                StatusCodes.Status201Created => BaseResponse<T>.Created(result.Value!, requestId: requestId),
                StatusCodes.Status202Accepted => BaseResponse<T>.Accepted(result.Value!, requestId: requestId),
                _ => BaseResponse<T>.Ok(result.Value!, requestId: requestId)
            };
        }

        return ToResponse(result, requestId);
    }

    public BaseResponse ToResponse(
        Result<bool> result,
        string? requestId = null)
    {
        if (result.Success)
        {
            return BaseResponse.Ok(requestId: requestId);
        }

        var firstError = result.Errors.FirstOrDefault();

        var response = firstError?.Code switch
        {
            ErrorCode.ValidationError => BaseResponse.BadRequest(result.Errors, requestId: requestId),
            ErrorCode.NotFound => BaseResponse.NotFound(firstError.Message, requestId),
            _ => BaseResponse.BadRequest(result.Errors, requestId: requestId)
        };

        return response;
    }

    public async Task SendResponseAsync<T>(
        BaseResponse<T> baseResponse,
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
