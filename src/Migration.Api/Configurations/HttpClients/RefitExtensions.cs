namespace Migration.Api;

public static class RefitExtensions
{
    public static IServiceCollection AddRefitClientService<TRefitService>(this IServiceCollection services, Uri uri)
        where TRefitService : class
    {
        var refitSettings = new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                })
        };

        services.AddRefitClient<TRefitService>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = uri);

        return services;
    }
}
