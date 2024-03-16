using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

public static class ServiceExtensions
{
    /// <summary>
    /// Setup EFCore DB and Seed any data if necessary
    /// </summary>
    /// <param name="services"></param>
    public static void RunDBMigration(IServiceCollection services)
    {
        Console.WriteLine("RunDBMigration");
        try{
            var provider = services.BuildServiceProvider();
            var context = provider.GetRequiredService<AppDbContext>();
            var opt = provider.GetRequiredService<IOptions<PostgresSettings>>().Value;


            // Console.WriteLine($"RunDBMigration - Migrate: {opt.Migrate}");
            // Console.WriteLine($"RunDBMigration - SeedData: {opt.SeedData}");
            // Console.WriteLine($"RunDBMigration - ConnectionString: {opt.ConnectionString}");

            if(opt.Migrate)
                context.Database.Migrate();

            if(opt.SeedData)
                DbSeeding.TryRunSeed(context).Wait();

        }
        catch(Exception e)
        {
            Console.WriteLine($"RunDB Migrate - Exception caught: {e.Message}");
        }
    }
}

public class PostgresSettings
{
    public required string ConnectionString { get; set; }
    public bool Migrate { get; set; } = false;
    public bool SeedData { get; set; } = false;
}