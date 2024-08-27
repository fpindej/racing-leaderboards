using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RacingLeaderboards.Infrastructure.Persistence.Models;

public class Season : IEntityTypeConfiguration<Season>
{
    public int Id { get; set; }

    public ushort Year { get; set; }

    public int LeagueId { get; set; }

    public virtual League League { get; set; } = null!;

    public virtual ICollection<RaceEvent> RaceEvents { get; set; } = new List<RaceEvent>();

    public void Configure(EntityTypeBuilder<Season> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Year)
            .IsRequired();

        builder.HasOne(s => s.League)
            .WithMany(l => l.Seasons)
            .HasForeignKey(s => s.LeagueId)
            .OnDelete(DeleteBehavior.Restrict);

        ;

        builder.HasMany(s => s.RaceEvents)
            .WithOne(re => re.Season)
            .HasForeignKey(re => re.SeasonId);
    }
}