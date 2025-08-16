namespace Migration.Common;

public abstract class BaseEndpoint<TRequest, TResponse>
    : Endpoint<TRequest, BaseResponse<TResponse>>
    where TRequest : notnull
{
    public BaseResponse<TData> ToResponse<TData>(
        Result<TData> result,
        string? requestId = null)
    {
        if (result.Success)
        {
            var successResponse = BaseResponse<TData>.Ok(result.Data!, requestId: requestId);

            return successResponse;
        }

        var firstError = result.Errors.FirstOrDefault();

        var response = firstError?.Code switch
        {
            ErrorCode.ValidationError => BaseResponse<TData>.BadRequest(result.Errors, requestId: requestId),
            ErrorCode.BusinessRuleViolation => BaseResponse<TData>.BadRequest(result.Errors, requestId: requestId),
            ErrorCode.ExternalServiceError => BaseResponse<TData>.BadRequest(firstError, requestId: requestId),
            ErrorCode.NotFound => BaseResponse<TData>.NotFound(firstError.Message, requestId),
            ErrorCode.Unauthorized => BaseResponse<TData>.Unauthorized(firstError.Message, requestId),
            ErrorCode.Forbidden => BaseResponse<TData>.Forbidden(firstError.Message, requestId),
            ErrorCode.Conflict => BaseResponse<TData>.Conflict(firstError, requestId: requestId),
            _ => BaseResponse<TData>.InternalServerError(firstError?.Message, requestId)
        };

        return response;
    }

    public BaseResponse<TData> ToResponse<TData>(
        Result<TData> result,
        int successStatusCode,
        string? requestId = null)
    {
        if (result.Success)
        {
            return successStatusCode switch
            {
                StatusCodes.Status201Created => BaseResponse<TData>.Created(result.Data!, requestId: requestId),
                StatusCodes.Status202Accepted => BaseResponse<TData>.Accepted(result.Data!, requestId: requestId),
                _ => BaseResponse<TData>.Ok(result.Data!, requestId: requestId)
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
