namespace Migration.Api;

public static class DI
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddSingleton<CacheSettings>();

        services.AddSingleton<ThrottleSettings>();

        services.AddSingleton<GetJobLogsMapper>();

        services.AddSingleton<GetJobStatusMapper>();

        services.AddSingleton<StartJobMapper>();

        return services;
    }
}
