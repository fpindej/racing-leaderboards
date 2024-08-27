using Microsoft.EntityFrameworkCore;

namespace RacingLeaderboards.Infrastructure.Persistence;

internal class RacingLeaderboardsDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Models.Driver> Drivers { get; set; } = null!;

    public DbSet<Models.League> Leagues { get; set; } = null!;

    public DbSet<Models.RaceEvent> RaceEvents { get; set; } = null!;

    public DbSet<Models.RaceResult> RaceResults { get; set; } = null!;

    public DbSet<Models.Season> Seasons { get; set; } = null!;

    public DbSet<Models.Team> Teams { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RacingLeaderboardsDbContext).Assembly);
    }
}