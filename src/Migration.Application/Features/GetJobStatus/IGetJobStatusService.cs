namespace Migration.Application;

public interface IGetJobStatusService
{
    Task<Result<GetJobStatusResponse>> GetStatusByIdAsync(Guid guid, CancellationToken cancellationToken = default);
}
