namespace Migration.Api;

public class StartJobMapper : Mapper<StartJobRequest, StartJobResponse, StartJobDto>
{
    public override StartJobResponse FromEntity(StartJobDto startJobDto) =>
        new()
        {
            JobId = startJobDto.JobId,
            Status = startJobDto.Status,
            CreatedAt = startJobDto.CreatedAt,
            TotalItems = startJobDto.TotalItems
        };
}
