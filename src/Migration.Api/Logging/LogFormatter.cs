namespace Migration.Api;

public class LogFormatter : ILogFormatter
{
    public string Format(HttpContext httpContext) =>
        $"Method: {httpContext.Request.Method} " +
        $"Path: {httpContext.Request.Path}, " +
        $"Status: {httpContext.Response.StatusCode}";
}
