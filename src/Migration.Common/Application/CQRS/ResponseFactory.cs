namespace Migration.Common;

public class ResponseFactory
{
    public static BaseResponse<TData> Create<TData>(
       Result<TData> result,
       string? requestId = null)
    {
        if (result.Success)
        {
            //Error Code: 200 OK
            var successResponse = BaseResponse<TData>.Ok(result.Data!, requestId: requestId);

            return successResponse;
        }

        var firstError = result.Errors.FirstOrDefault();

        var response = firstError?.Code switch
        {
            //Error Code: 400 Bad Request
            ErrorCode.ValidationError => BaseResponse<TData>.BadRequest(result.Errors, requestId: requestId),
            //Error Code: 400 Bad Request
            ErrorCode.BusinessRuleViolation => BaseResponse<TData>.BadRequest(result.Errors, requestId: requestId),
            //Error Code: 400 Bad Request
            ErrorCode.ExternalServiceError => BaseResponse<TData>.BadRequest(firstError, requestId: requestId),
            //Error Code: 401 Unauthorized
            ErrorCode.Unauthorized => BaseResponse<TData>.Unauthorized(firstError.Message, requestId),
            //Error Code: 403 Forbidden
            ErrorCode.Forbidden => BaseResponse<TData>.Forbidden(firstError.Message, requestId),
            //Error Code: 404 Not Found
            ErrorCode.NotFound => BaseResponse<TData>.NotFound(firstError.Message, requestId),
            //Error Code: 409 Conflict
            ErrorCode.Conflict => BaseResponse<TData>.Conflict(firstError, requestId: requestId),
            //Error Code: 500 Internal Server Error
            _ => BaseResponse<TData>.InternalServerError(firstError?.Message, requestId)
        };

        return response;
    }

    public static BaseResponse<TData> Create<TData>(
        Result<TData> result,
        int successStatusCode,
        string? requestId = null)
    {
        if (result.Success)
        {
            return successStatusCode switch
            {
                //Error Code: 201 Created
                StatusCodes.Status201Created => BaseResponse<TData>.Created(result.Data!, requestId: requestId),
                //Error Code: 202 Accepted
                StatusCodes.Status202Accepted => BaseResponse<TData>.Accepted(result.Data!, requestId: requestId),
                //Error Code: 200 OK
                _ => BaseResponse<TData>.Ok(result.Data!, requestId: requestId)
            };
        }

        return Create(result, requestId);
    }

    public static BaseResponse Create(
        Result<bool> result,
        string? requestId = null)
    {
        if (result.Success)
        {
            //Error Code: 200 OK
            return BaseResponse.Ok(requestId: requestId);
        }

        var firstError = result.Errors.FirstOrDefault();

        var response = firstError?.Code switch
        {
            //Error Code: 400 Bad Request
            ErrorCode.ValidationError => BaseResponse.BadRequest(result.Errors, requestId: requestId),
            //Error Code: 404 Not Found
            ErrorCode.NotFound => BaseResponse.NotFound(firstError.Message, requestId),
            //Error Code: 400 Bad Request
            _ => BaseResponse.BadRequest(result.Errors, requestId: requestId)
        };

        return response;
    }
}
