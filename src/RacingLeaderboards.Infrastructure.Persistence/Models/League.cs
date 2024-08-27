using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RacingLeaderboards.Infrastructure.Persistence.Models;

public class League : IEntityTypeConfiguration<League>
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public virtual ICollection<Season> Seasons { get; set; } = new List<Season>();

    public void Configure(EntityTypeBuilder<League> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Name)
            .IsRequired()
            .HasMaxLength(maxLength: 100);

        builder.HasMany(l => l.Teams)
            .WithOne(t => t.League)
            .HasForeignKey(t => t.LeagueId);

        builder.HasMany(l => l.Seasons)
            .WithOne(s => s.League)
            .HasForeignKey(s => s.LeagueId);
    }
}