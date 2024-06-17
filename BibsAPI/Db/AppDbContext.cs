
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    public DbSet<Club> Clubs { get; set; } = null!;
    public DbSet<Member> Members { get; set; } = null!;
    public DbSet<Match> Matches { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Club>()
            .HasMany(e => e.Members)
            .WithOne(e => e.Club)
            .HasForeignKey(e => e.ClubId)
            .IsRequired();
        
        modelBuilder.Entity<Club>()
            .HasMany(e => e.Matches)
            .WithOne(e => e.Club)
            .HasForeignKey(e => e.ClubId)
            .IsRequired();

        // modelBuilder.Entity<Club>()
        //     .HasMany(e => e.Matches)
        //     .WithOne(e => e.Club)
        //     .HasForeignKey(e => e.ClubId)
        //     .IsRequired();
    }
}
