using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RacingLeaderboards.Infrastructure.Persistence.Models;

public class RaceEvent : IEntityTypeConfiguration<RaceEvent>
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Location { get; set; }

    public DateOnly Date { get; set; }

    public int SeasonId { get; set; }

    public virtual Season Season { get; set; } = null!;

    public virtual ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();

    public void Configure(EntityTypeBuilder<RaceEvent> builder)
    {
        builder.HasKey(re => re.Id);

        builder.Property(re => re.Name)
            .IsRequired()
            .HasMaxLength(maxLength: 200);

        builder.Property(re => re.Location)
            .IsRequired()
            .HasMaxLength(maxLength: 128);

        builder.Property(re => re.Date)
            .IsRequired();

        builder.HasOne(re => re.Season)
            .WithMany(s => s.RaceEvents)
            .HasForeignKey(re => re.SeasonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(re => re.RaceResults)
            .WithOne(rr => rr.RaceEvent)
            .HasForeignKey(rr => rr.RaceEventId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}