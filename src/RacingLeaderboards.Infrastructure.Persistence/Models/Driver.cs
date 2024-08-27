using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RacingLeaderboards.Infrastructure.Persistence.Models;

public class Driver : IEntityTypeConfiguration<Driver>
{
    public int Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public int TeamId { get; set; }

    public virtual Team Team { get; set; } = null!;

    public virtual ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();

    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.FirstName)
            .IsRequired()
            .HasMaxLength(maxLength: 128);

        builder.Property(d => d.LastName)
            .IsRequired()
            .HasMaxLength(maxLength: 128);

        builder.HasOne(d => d.Team)
            .WithMany(t => t.Drivers)
            .HasForeignKey(d => d.TeamId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}