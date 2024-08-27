namespace RacingLeaderboards.Domain;

public class Season
{
    public int Id { get; set; }

    public ushort Year { get; set; }

    public required League League { get; set; }

    public required ICollection<RaceEvent> RaceEvents { get; set; }
}