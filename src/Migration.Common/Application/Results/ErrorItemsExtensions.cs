namespace Migration.Common;

public static class ErrorItemsExtensions
{
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
