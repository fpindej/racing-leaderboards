using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RacingLeaderboards.Infrastructure.Persistence.Models;

public class RaceResult : IEntityTypeConfiguration<RaceResult>
{
    public int Id { get; set; }

    public byte Position { get; set; }

    public ushort Points { get; set; }

    public int DriverId { get; set; }

    public int RaceEventId { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual RaceEvent RaceEvent { get; set; } = null!;

    public void Configure(EntityTypeBuilder<RaceResult> builder)
    {
        builder.HasKey(rr => rr.Id);

        builder.Property(rr => rr.Position)
            .IsRequired();

        builder.Property(rr => rr.Points)
            .IsRequired();

        builder.HasOne(rr => rr.Driver)
            .WithMany(d => d.RaceResults)
            .HasForeignKey(rr => rr.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(rr => rr.RaceEvent)
            .WithMany(re => re.RaceResults)
            .HasForeignKey(rr => rr.RaceEventId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}