namespace Migration.Api;

public class ProblemDetailsFactory : IProblemDetailsFactory
{
    public ProblemDetails Create(Exception ex) =>
        new ProblemDetails
        {
            Status = 1,
            TraceId = "",
            Detail = "",
            Instance = "",
            Errors = new List<ProblemDetails.Error>()
        };
}
