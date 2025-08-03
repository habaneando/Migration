namespace Migration.Api;

public class AddCorrelationIdAndClientIdToRequestMiddleware(
    RequestDelegate Next,
    ILogger<AddCorrelationIdAndClientIdToRequestMiddleware> Logger,
    ILogFormatter LogFormatter,
    IExceptionFormatter ExceptionFormatter,
    IProblemDetailsFactory ProblemDetailsFactory)
{
    private const string CorrelationIdHeaderName = "X-Correlation-Id";

    private const string ClientIdHeaderName = "X-Client-Id";

    /// <summary>
    /// 5341 default port for Seq UI
    /// docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context)
    {
        string correlationId = GetCorrelationId(context);

        string clientId = GetClientId(context);

        try
        {
            using (LogContext.PushProperty("CorrelationId", correlationId))
            using (LogContext.PushProperty("ClientId", clientId))
            {
                await Next.Invoke(context);

                var logFormatted = LogFormatter.Format(context);

                Logger.LogInformation(logFormatted);
            }
        }
        catch (Exception ex)
        {
            using (LogContext.PushProperty("CorrelationId", correlationId))
            using (LogContext.PushProperty("ClientId", clientId))
            {
                var exceptionFormatted = ExceptionFormatter.Format(ex);

                Logger.LogError(ex, exceptionFormatted);
            }

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var problemDetails = ProblemDetailsFactory.Create(ex);

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

    private string GetCorrelationId(HttpContext context)
    {
        context.Request.Headers.TryGetValue(
            CorrelationIdHeaderName, out StringValues correlationId);

        return correlationId.FirstOrDefault() ?? context.TraceIdentifier ?? "Unknown";
    }

    private string GetClientId(HttpContext context) =>
        context.User?.FindFirst(ClientIdHeaderName)?.Value ?? "Unknown";
}
