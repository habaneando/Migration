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
            .ConfigureHttpClient(c => c.BaseAddress = uri)
            .AddResilienceStrategies();

        return services;
    }

    private static IHttpStandardResiliencePipelineBuilder AddResilienceStrategies(this IHttpClientBuilder builder) =>
        builder.AddStandardResilienceHandler(options =>
        {
            options.Retry = GetHttpRetryStrategyOptions();

            options.CircuitBreaker = GetHttpCircuitBreakerStrategyOptions();

            options.TotalRequestTimeout = GetHttpTimeoutStrategyOptions();
        });

    /// <summary>
    /// Retry policy for transient failures
    /// </summary>
    /// <returns></returns>
    private static HttpRetryStrategyOptions GetHttpRetryStrategyOptions() =>
        new HttpRetryStrategyOptions
        {
            //Limits retries to avoid excessive delays.
            MaxRetryAttempts = 3,

            //Base delay between retries.
            Delay = TimeSpan.FromSeconds(2),

            //Increases delay exponentially (2s, 4s, 8s).
            BackoffType = DelayBackoffType.Exponential,

            //Adds randomness to delays to prevent synchronized retries.
            UseJitter = true
        };

    /// <summary>
    /// Circuit breaker to protect against repeated failures
    /// </summary>
    /// <returns></returns>
    private static HttpCircuitBreakerStrategyOptions GetHttpCircuitBreakerStrategyOptions() =>
        new HttpCircuitBreakerStrategyOptions
        {
            // Breaks if 50% of requests fail.
            FailureRatio = 0.5,

            // Requires 10 requests to evaluate the failure rate.
            MinimumThroughput = 10,

            // Circuit stays open for 30 seconds before allowing a test request.
            BreakDuration = TimeSpan.FromSeconds(30),

            //Evaluates failures over a 60-second window.
            SamplingDuration = TimeSpan.FromSeconds(60)
        };

    /// <summary>
    /// Caps the entire operation, including retries
    /// </summary>
    /// <returns></returns>
    private static HttpTimeoutStrategyOptions GetHttpTimeoutStrategyOptions() =>
        new HttpTimeoutStrategyOptions
        {
            // Caps the entire operation, including retries.
            Timeout = TimeSpan.FromSeconds(30)
        };
}
