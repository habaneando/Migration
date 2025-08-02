namespace Migration.Api;

public interface IProblemDetailsFactory
{
    ProblemDetails Create(Exception ex);
}
