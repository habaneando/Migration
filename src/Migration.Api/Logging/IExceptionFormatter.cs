namespace Migration.Api;

public interface IExceptionFormatter
{
    string Format(Exception exception);
}
