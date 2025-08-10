namespace Migration.Common;

public record ErrorItem(
    string Code,
    string Message,
    ResultType Type,
    List<string>? Arguments);
