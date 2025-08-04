namespace Migration.Api;

public static class HealthChecksExtensions
{
    public static IServiceCollection AddComponentHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddDbContextCheck<MigrationDbContext>();

        return services;
    }
}
