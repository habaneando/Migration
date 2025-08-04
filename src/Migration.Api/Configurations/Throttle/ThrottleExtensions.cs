namespace Migration.Api;

public static class ThrottleExtensions
{
    /// <summary>
    /// Throttling: limit the number of requests a client can make within a specified time window
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddThrottling(this IServiceCollection services) =>
        services.AddRateLimiter(options =>
        {
            options.AddFixedWindowLimiter(
                "Default",
                opt =>
                {
                    opt.PermitLimit = 100;
                    opt.Window = TimeSpan.FromMinutes(1);
                    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    opt.QueueLimit = 0;
                    opt.AutoReplenishment = true;
                });
        });
}
