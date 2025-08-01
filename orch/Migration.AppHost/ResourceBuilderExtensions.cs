namespace Migration.AppHost;

internal static class ResourceBuilderExtensions
{
    internal static IResourceBuilder<T> WithSwaggerUI<T>(this IResourceBuilder<T> builder)
        where T : IResourceWithEndpoints =>
        builder.WithOpenApiDocs("swagger-docs", "Swagger API Doc", "swagger");

    internal static IResourceBuilder<T> WithScalar<T>(this IResourceBuilder<T> builder)
        where T : IResourceWithEndpoints =>
        builder.WithOpenApiDocs("scalar-docs", "Scalar API Doc", "scalar");

    internal static IResourceBuilder<T> WithReDoc<T>(this IResourceBuilder<T> builder)
        where T : IResourceWithEndpoints =>
        builder.WithOpenApiDocs("redoc-docs", "ReDoc API Doc", "redoc");

    private static IResourceBuilder<T> WithOpenApiDocs<T>(
        this IResourceBuilder<T> builder,
        string name,
        string displayName,
        string openApiUiPath)
        where T : IResourceWithEndpoints
    {
        var options = new CommandOptions
        {
            UpdateState = ctx =>
                ctx.ResourceSnapshot.HealthStatus == HealthStatus.Healthy
                    ? ResourceCommandState.Enabled
                    : ResourceCommandState.Disabled,
            IconName = "Document",
            IconVariant = IconVariant.Filled
        };

        return builder.WithCommand(
            name,
            displayName,
            executeCommand: async (ExecuteCommandContext ctx) =>
            {
                try
                {
                    var endpoint = builder.GetEndpoint("https");

                    var url = $"{endpoint.Url}/{openApiUiPath}";

                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

                    return new ExecuteCommandResult { Success = true };
                }
                catch (Exception ex)
                {
                    return new ExecuteCommandResult
                    {
                        Success = false,
                        ErrorMessage = ex.ToString()
                    };
                }
            },
            commandOptions: options);
    }
}
