namespace Migration.Application;

public class GetJobStatusQueryValidator : Validator<GetJobStatusQuery>
{
    public GetJobStatusQueryValidator()
    {
        RuleFor(x => x.JobId)
            .NotEmpty()
            .WithMessage("Job id is required");
    }
}
