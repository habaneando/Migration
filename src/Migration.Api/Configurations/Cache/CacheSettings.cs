namespace Migration.Api;

public class CacheSettings(IConfiguration configuration)
{
    public int CacheDurationInSeconds =>
        configuration.GetSection("CacheSettings:DurationSeconds").Get<int>();

    public TimeSpan CacheDuration =>
        TimeSpan.FromSeconds(CacheDurationInSeconds);
}

