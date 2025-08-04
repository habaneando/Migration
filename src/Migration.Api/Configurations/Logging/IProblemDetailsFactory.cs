namespace Migration.Api;

public interface IProblemDetailsFactory
{
    FastEndpoints.ProblemDetails Create(Exception ex);
}
