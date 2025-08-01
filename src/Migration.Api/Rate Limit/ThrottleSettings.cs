namespace Migration.Api;

public class ThrottleSettings(IConfiguration configuration)
{
    public int HitLimit =>
        configuration.GetSection("ThrottleSettings:HitLimit").Get<int>();

    public int DurationSeconds =>
        configuration.GetSection("ThrottleSettings:DurationSeconds").Get<int>();
}
