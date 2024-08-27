using Microsoft.EntityFrameworkCore;

namespace RacingLeaderboards.Infrastructure.Persistence;

internal class RacingLeaderboardsDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RacingLeaderboardsDbContext).Assembly);
    }
}
