namespace Migration.Application;

public interface IStartJobService
{
    Task<Result<StartJobResponse>> ProcessJobAsync(
        Guid guid,
        CancellationToken cancellationToken = default);
}
