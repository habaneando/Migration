namespace Migration.Api;

internal static class ApiDocExtensions
{
    public static void AddSwagger(this WebApplication app)
    {
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json", "Swagger Api Documentation");
            options.RoutePrefix = "swagger-docs";
        });
    }

    public static void AddScalar(this WebApplication app)
    {
        app.MapScalarApiReference("scalar-docs", options =>
        {
            options
                .WithTitle("Scalar Api Documentation")
                .WithTheme(ScalarTheme.BluePlanet)
                .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
        });
    }

    public static void AddReDoc(this WebApplication app)
    {
        app.UseReDoc(options =>
        {
            options.DocumentTitle = "ReDoc Api Documentation";
            options.RoutePrefix = "redoc-docs";
            options.SpecUrl("/openapi/v1.json");
        });
    }
}
