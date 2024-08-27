namespace RacingLeaderboards.Domain;

public class League
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required ICollection<Team> Teams { get; set; }

    public required ICollection<Season> Seasons { get; set; }
}