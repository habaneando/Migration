namespace Migration.Application;

public class GetJobLogsRequestValidator : Validator<GetJobLogsRequest>
{
    public GetJobLogsRequestValidator()
    {
        RuleFor(x => x.JobId)
            .NotEmpty()
            .WithMessage("Job id is required");

        RuleFor(x => x.Page)
            .GreaterThan(0)
            .WithMessage("Page must be greater than zero.")
            .When(x => x.Page.HasValue);

        RuleFor(x => x.PageSize)
            .NotNull()
            .WithMessage("PageSize is required when Page is provided.")
            .GreaterThan(0)
            .WithMessage("PageSize must be greater than zero.")
            .When(x => x.Page.HasValue);
    }
}
