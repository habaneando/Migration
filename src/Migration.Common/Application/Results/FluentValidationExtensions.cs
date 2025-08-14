namespace Migration.Common;

public static class FluentValidationExtensions
{
    public static IReadOnlyList<ErrorItem> ToErrorItems(this IEnumerable<ValidationFailure> failures) =>
        failures.Select(f =>
            ErrorItem.Validation(
                f.PropertyName,
                f.ErrorMessage,
                f.AttemptedValue))
                .ToList();
}
