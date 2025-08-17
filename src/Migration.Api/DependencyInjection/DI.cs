namespace Migration.Api;

public static class DI
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddSingleton<CacheSettings>();

        services.AddSingleton<ThrottleSettings>();

        services.AddSingleton<GetJobLogsMapper>();

        services.AddSingleton<IQueryMapper<GetJobLogsRequest, GetJobLogsQuery>, GetJobLogsQueryMapper>();

        services.AddSingleton<StartJobMapper>();

        services.AddSingleton<ICommandMapper<StartJobRequest, StartJobCommand>, StartJobCommandMapper>();

        services.AddSingleton<GetJobStatusMapper>();

        services.AddSingleton<IQueryMapper<GetJobStatusRequest, GetJobStatusQuery>, GetJobStatusQueryMapper>();

        services.AddSingleton<ILogFormatter, LogFormatter>();

        services.AddSingleton<IExceptionFormatter, ExceptionFormatter>();

        services.AddSingleton<IProblemDetailsFactory, ProblemDetailsFactory>();

        return services;
    }
}
