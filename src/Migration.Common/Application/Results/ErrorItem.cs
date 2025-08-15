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
        Code == ErrorCode.ValidationError;

    public bool IsNotFound =>
        Code == ErrorCode.NotFound;

    public bool IsUnauthorized =>
        Code == ErrorCode.Unauthorized;

    public bool IsForbidden =>
        Code == ErrorCode.Forbidden;

    public bool IsConflict =>
        Code == ErrorCode.Conflict;

    public bool IsBusinessRule =>
        Code == ErrorCode.BusinessRuleViolation;

    public bool IsExternal =>
        Code == ErrorCode.ExternalServiceError;

    public bool IsInternal =>
        Code == ErrorCode.InternalError;

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
        new(ErrorCode.ValidationError,
            message,
            propertyName,
            attemptedValue,
            ErrorSeverity.Error);

    public static ErrorItem NotFound(
        string? message = null,
        string? resourceType = null) =>
        new(ErrorCode.NotFound,
            message ?? "Resource not found",
            metadata: resourceType != null
                ? new Dictionary<string, object>
                {
                    ["ResourceType"] = resourceType
                }
                : null);

    public static ErrorItem Unauthorized(
        string? message = null) =>
        new(ErrorCode.Unauthorized,
            message ?? "Unauthorized access");

    public static ErrorItem Forbidden(
        string? message = null) =>
        new(ErrorCode.Forbidden,
            message ?? "Access forbidden");

    public static ErrorItem Conflict(
        string message,
        string? propertyName = null) =>
        new(ErrorCode.Conflict,
            message,
            propertyName);

    public static ErrorItem BusinessRule(
        string ruleName,
        string message) =>
        new(ErrorCode.BusinessRuleViolation,
            message,
            metadata: new Dictionary<string, object>
            {
                ["RuleName"] = ruleName
            });

    public static ErrorItem External(
        string service,
        string message,
        string? originalErrorCode = null) =>
        new(ErrorCode.ExternalServiceError,
            message,
            metadata: new Dictionary<string, object>
            {
                ["Service"] = service,
                ["OriginalErrorCode"] = originalErrorCode ?? "Unknown"
            });

    public static ErrorItem Internal(
        string message,
        Exception? exception = null) =>
        new(ErrorCode.InternalError,
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
