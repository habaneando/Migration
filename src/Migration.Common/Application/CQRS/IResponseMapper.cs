namespace Migration.Common;

public interface IResponseMapper<TResponse>
    where TResponse : notnull
{
    BaseResponse<TResponse> ToResponse(Result<TResponse> response);
}
