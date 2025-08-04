namespace Migration.Api;

public interface ILogFormatter
{
    string Format(HttpContext httpContext);
}
