namespace Migration.Common;

public static class ErrorItemExtensions
{
    public static ErrorItem Validation(
        this ErrorItem error,
        string propertyName,
        string message,
        object? attemptedValue = null) =>
        ErrorItem.Create(
            "ValidationError",
            message,
            propertyName,
            attemptedValue,
            ErrorSeverity.Error);

    public static ErrorItem NotFound(
        this ErrorItem error,
        string? message = null,
        string? resourceType = null) =>
        ErrorItem.Create(
            "NotFound",
            message ?? "Resource not found",
            metadata: resourceType != null
                ? new Dictionary<string, object>
                {
                    ["ResourceType"] = resourceType
                }
                : null);

    public static ErrorItem Unauthorized(
        this ErrorItem error,
        string? message = null) =>
        ErrorItem.Create(
            "Unauthorized",
            message ?? "Unauthorized access");

    public static ErrorItem Forbidden(
        this ErrorItem error,
        string? message = null) =>
        ErrorItem.Create(
            "Forbidden",
            message ?? "Access forbidden");

    public static ErrorItem Conflict(
        this ErrorItem error,
        string message,
        string? propertyName = null) =>
        ErrorItem.Create(
            "Conflict",
            message,
            propertyName);

    public static ErrorItem BusinessRule(
        this ErrorItem error,
        string ruleName,
        string message) =>
        ErrorItem.Create(
            "BusinessRuleViolation",
            message,
            metadata: new Dictionary<string, object>
            {
                ["RuleName"] = ruleName
            });

    public static ErrorItem External(
        this ErrorItem error,
        string service,
        string message,
        string? originalErrorCode = null) =>
        ErrorItem.Create(
            "ExternalServiceError",
            message,
            metadata: new Dictionary<string, object>
            {
                ["Service"] = service,
                ["OriginalErrorCode"] = originalErrorCode ?? "Unknown"
            });

    public static ErrorItem Internal(
        this ErrorItem error,
        string message,
        Exception? exception = null) =>
        ErrorItem.Create(
            "InternalError",
            message,
            severity: ErrorSeverity.Critical,
            metadata: exception != null
                ? new Dictionary<string, object>
                {
                    ["ExceptionType"] = exception.GetType().Name
                }
                : null);

    public static ErrorItem Warning(
        this ErrorItem error,
        string code,
        string message,
        string? propertyName = null) =>
        ErrorItem.Create(
            code,
            message,
            propertyName,
            severity: ErrorSeverity.Warning);

    public static ErrorItem Info(
        this ErrorItem error,
        string code,
        string message,
        string? propertyName = null) =>
        ErrorItem.Create(
            code,
            message,
            propertyName,
            severity: ErrorSeverity.Info);

    public static IReadOnlyList<ErrorItem> GetValidationErrors(this IReadOnlyList<ErrorItem> errors) =>
        errors.Where(e => e.IsValidationError).ToList();

    public static IReadOnlyList<ErrorItem> GetBusinessRuleErrors(this IReadOnlyList<ErrorItem> errors) =>
        errors.Where(e => e.IsBusinessRule).ToList();

    public static IReadOnlyList<ErrorItem> GetErrorsBySeverity(this IReadOnlyList<ErrorItem> errors, string severity) =>
        errors.Where(e => e.Severity == severity).ToList();

    public static IReadOnlyList<ErrorItem> GetErrorsForProperty(this IReadOnlyList<ErrorItem> errors, string propertyName) =>
        errors.Where(e => e.PropertyName == propertyName).ToList();

    public static bool HasValidationErrors(this IReadOnlyList<ErrorItem> errors) =>
        errors.Any(e => e.IsValidationError);

    public static bool HasBusinessRuleErrors(this IReadOnlyList<ErrorItem> errors) =>
        errors.Any(e => e.IsBusinessRule);

    public static bool HasCriticalErrors(this IReadOnlyList<ErrorItem> errors) =>
        errors.Any(e => e.Severity == ErrorSeverity.Critical);

    public static string ToSummaryString(this IReadOnlyList<ErrorItem> errors) =>
        string.Join("; ", errors.Select(e => e.ToString()));
}
