namespace Migration.Application;

public class StartJobCommandValidator : Validator<StartJobCommand>
{
    public StartJobCommandValidator(IJobTypeValidator jobTypeValidator)
    {
        RuleFor(x => x.JobType)
            .SetValidator(jobTypeValidator as AbstractValidator<string>);

        RuleFor(x => x.Data)
            .NotEmpty()
            .WithMessage("Data is required");
    }
}
