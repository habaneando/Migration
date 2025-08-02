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

        services.AddSingleton<ILogFormatter, LogFormatter>();

        services.AddSingleton<IExceptionFormatter, ExceptionFormatter>();

        services.AddSingleton<IProblemDetailsFactory, ProblemDetailsFactory>();

        return services;
    }
}
