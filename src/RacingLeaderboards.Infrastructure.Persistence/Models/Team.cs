using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RacingLeaderboards.Infrastructure.Persistence.Models;

public class Team : IEntityTypeConfiguration<Team>
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int LeagueId { get; set; }

    public virtual League League { get; set; } = null!;

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(maxLength: 128);

        builder.HasOne(t => t.League)
            .WithMany(l => l.Teams)
            .HasForeignKey(t => t.LeagueId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(t => t.Drivers)
            .WithOne(d => d.Team)
            .HasForeignKey(d => d.TeamId);
    }
}