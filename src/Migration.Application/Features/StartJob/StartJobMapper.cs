namespace Migration.Application;

public class StartJobMapper
{
    public StartJobResponse FromEntity(StartJob startJob) =>
        new(startJob.JobId,
            startJob.TotalItems,
            startJob.CreatedAt);

    public StartJobCommand ToCommand(StartJobRequest startJobRequest) =>
        new(startJobRequest.JobId,
            startJobRequest.JobType,
            startJobRequest.Data,
            startJobRequest.Metadata);
}
