namespace Migration.Application;

public class GetJobStatusCommandValidator : Validator<GetJobStatusCommand>
{
    public GetJobStatusCommandValidator()
    {
        RuleFor(x => x.JobId)
            .NotEmpty()
            .WithMessage("Job id is required");
    }
}
