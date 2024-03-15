using Microsoft.EntityFrameworkCore;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        //Console.WriteLine($"DB Settings: {configuration.GetValue<string>("PostgresSettings:ConnectionString")}");
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetValue<string>("PostgresSettings:ConnectionString")));

        services.AddTransient<ClubService>();
        services.AddTransient<MatchService>();
        return services;
    }
}