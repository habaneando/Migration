namespace Migration.Application;

public class StartJobCommandMapper : ICommandMapper<StartJobRequest, StartJobCommand>
{
    public StartJobCommand ToCommand(StartJobRequest startJobRequest) =>
        new(startJobRequest.JobId,
            startJobRequest.JobType,
            startJobRequest.Data,
            startJobRequest.Metadata);
}
