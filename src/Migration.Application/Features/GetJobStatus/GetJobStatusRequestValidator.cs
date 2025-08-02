namespace Migration.Application;

public class GetJobStatusRequestValidator : Validator<GetJobStatusRequest>
{
    public GetJobStatusRequestValidator()
    {
        RuleFor(x => x.JobId)
            .NotEmpty()
            .WithMessage("Job id is required");
    }
}
