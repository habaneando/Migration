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

    public static ErrorItem Validation(
        string propertyName,
        string message,
        object? attemptedValue = null) =>
        new("ValidationError",
            message,
            propertyName,
            attemptedValue,
            ErrorSeverity.Error);

    public static ErrorItem NotFound(
        string? message = null,
        string? resourceType = null) =>
        new("NotFound",
            message ?? "Resource not found",
            metadata: resourceType != null
                ? new Dictionary<string, object>
                {
                    ["ResourceType"] = resourceType
                }
                : null);

    public static ErrorItem Unauthorized(
        string? message = null) =>
        new("Unauthorized",
            message ?? "Unauthorized access");

    public static ErrorItem Forbidden(
        string? message = null) =>
        new("Forbidden",
            message ?? "Access forbidden");

    public static ErrorItem Conflict(
        string message,
        string? propertyName = null) =>
        new("Conflict",
            message,
            propertyName);

    public static ErrorItem BusinessRule(
        string ruleName,
        string message) =>
        new("BusinessRuleViolation",
            message,
            metadata: new Dictionary<string, object>
            {
                ["RuleName"] = ruleName
            });

    public static ErrorItem External(
        string service,
        string message,
        string? originalErrorCode = null) =>
        new("ExternalServiceError",
            message,
            metadata: new Dictionary<string, object>
            {
                ["Service"] = service,
                ["OriginalErrorCode"] = originalErrorCode ?? "Unknown"
            });

    public static ErrorItem Internal(
        string message,
        Exception? exception = null) =>
        new("InternalError",
            message,
            severity: ErrorSeverity.Critical,
            metadata: exception != null
                ? new Dictionary<string, object>
                {
                    ["ExceptionType"] = exception.GetType().Name
                }
                : null);

    public static ErrorItem Warning(
        string code,
        string message,
        string? propertyName = null) =>
        new(code,
            message,
            propertyName,
            severity: ErrorSeverity.Warning);

    public static ErrorItem Info(
        string code,
        string message,
        string? propertyName = null) =>
        new(code,
            message,
            propertyName,
            severity: ErrorSeverity.Info);
}
