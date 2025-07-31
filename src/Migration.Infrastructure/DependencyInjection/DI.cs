namespace Migration.Infrastructure;

public static class DI
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IJobRepository, JobRepository>();

        services.AddScoped<IJobLogRepository, JobLogRepository>();

        services.AddScoped<IDataJobService, DataJobService>();

        return services;
    }
}
