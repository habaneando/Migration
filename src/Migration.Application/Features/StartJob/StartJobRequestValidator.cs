namespace Migration.Application;

public class StartJobRequestValidator : Validator<StartJobRequest>
{
    public StartJobRequestValidator(IJobTypeValidator jobTypeValidator)
    {
        RuleFor(x => x.JobType)
            .SetValidator(jobTypeValidator as AbstractValidator<string>);

        RuleFor(x => x.Data)
            .NotEmpty()
            .WithMessage("Data is required");
    }
}
