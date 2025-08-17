namespace Migration.Application;

public class StartJobEntityMapper
{
    public StartJobResponse ToResponse(StartJob startJob) =>
        new(startJob.Id,
            startJob.TotalItems,
            startJob.CreatedAt);

}
