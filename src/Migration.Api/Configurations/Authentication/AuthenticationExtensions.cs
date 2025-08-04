namespace Migration.Api;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer("Bearer", options =>
        {
            var signingKey = Encoding.UTF8.GetBytes("super-secret-signing-key-1234");

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "valid-issuer",
                ValidateAudience = true,
                ValidAudience = "valid-audience",
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                ValidateLifetime = true
            };
        });

        return services;
    }

    public static IServiceCollection AddCors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("DefaultCorsPolicy", policy =>
            {
                var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();

                if (allowedOrigins.Any())
                {
                    policy.WithOrigins(allowedOrigins);
                }
                else
                {
                    policy.AllowAnyOrigin();
                }

                policy.AllowAnyMethod()
                      .AllowAnyHeader();

                if (allowedOrigins.Any() && !allowedOrigins.Contains("*"))
                {
                    policy.AllowCredentials();
                }
            });
        });

        return services;
    }
}
