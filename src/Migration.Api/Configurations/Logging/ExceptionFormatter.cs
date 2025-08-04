namespace Migration.Api;

public class ExceptionFormatter : IExceptionFormatter
{
    public string Format(Exception exception) =>
        $"Message:{exception.Message.ToString()} " +
        $"StackTrace: {exception.StackTrace}";
}
