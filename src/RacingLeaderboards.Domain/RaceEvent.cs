namespace RacingLeaderboards.Domain;

public class RaceEvent
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Location { get; set; }

    public DateOnly Date { get; set; }

    public required Season Season { get; set; }

    public required ICollection<RaceResult> RaceResults { get; set; }
}