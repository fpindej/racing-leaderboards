namespace RacingLeaderboards.Domain;

public class Driver
{
    public int Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required Team Team { get; set; }

    public required ICollection<RaceResult> RaceResults { get; set; }
}