namespace Migration.Common;

public sealed record ErrorItem
{
    public string Code { get; init; }

    public string Message { get; init; }

    public string? PropertyName { get; init; }

    public object? AttemptedValue { get; init; }

    public string? Severity { get; init; }

    public Dictionary<string, object>? Metadata { get; init; }

    private ErrorItem(
        string code,
        string message,
        string? propertyName = null,
        object? attemptedValue = null,
        string? severity = null,
        Dictionary<string, object>? metadata = null)
    {
        Code = code ?? throw new ArgumentNullException(nameof(code));
        Message = message ?? throw new ArgumentNullException(nameof(message));
        PropertyName = propertyName;
        AttemptedValue = attemptedValue;
        Severity = severity ?? ErrorSeverity.Error;
        Metadata = metadata;
    }

    public static ErrorItem Create(
        string code,
        string message,
        string? propertyName = null,
        object? attemptedValue = null,
        string? severity = null,
        Dictionary<string, object>? metadata = null) =>
        new(code,
            message,
            propertyName,
            attemptedValue,
            severity,
            metadata);

    public bool IsValidationError =>
        Code == "ValidationError";

    public bool IsNotFound =>
        Code == "NotFound";

    public bool IsUnauthorized =>
        Code == "Unauthorized";

    public bool IsForbidden =>
        Code == "Forbidden";

    public bool IsConflict =>
        Code == "Conflict";

    public bool IsBusinessRule =>
        Code == "BusinessRuleViolation";

    public bool IsExternal =>
        Code == "ExternalServiceError";

    public bool IsInternal =>
        Code == "InternalError";

    public bool IsError =>
        Severity == ErrorSeverity.Error ||
        Severity == ErrorSeverity.Critical;

    public bool IsWarning =>
        Severity == ErrorSeverity.Warning;

    public bool IsInfo =>
        Severity == ErrorSeverity.Info;

    public override string ToString() =>
        PropertyName != null
            ? $"[{Code}] {PropertyName}: {Message}"
            : $"[{Code}] {Message}";
}
