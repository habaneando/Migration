namespace Migration.Api;

public class StartJobMapper : Mapper<StartJobRequest, StartJobResponse, StartJob>
{
    public override StartJobResponse FromEntity(StartJob startJob) =>
        new(startJob.JobId,
            startJob.Status,
            startJob.TotalItems,
            startJob.CreatedAt);

    public StartJobCommand ToCommand(StartJobRequest startJobRequest) =>
        new
        (
            startJobRequest.JobType,
            startJobRequest.Data,
            startJobRequest.Metadata
        );
}
