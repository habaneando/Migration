namespace Migration.Api;

public class ProblemDetailsFactory : IProblemDetailsFactory
{
    public FastEndpoints.ProblemDetails Create(Exception ex) =>
        new FastEndpoints.ProblemDetails
        {
            Status = 1,
            TraceId = "",
            Detail = "",
            Instance = "",
            Errors = new List<FastEndpoints.ProblemDetails.Error>()
        };
}
