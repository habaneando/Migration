namespace Migration.Application;

public class JobTypeValidator : AbstractValidator<string>, IJobTypeValidator
{
    public JobTypeValidator(IJobServiceProvider jobServiceProvider)
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("Job type cannot be empty.")
            .Custom((value, context) =>
            {
                if (jobServiceProvider.TryGet(value) is null)
                {
                    context.AddFailure("Job type must be a valid type.");
                }
            });
    }
}
