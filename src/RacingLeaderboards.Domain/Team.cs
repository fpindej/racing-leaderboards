namespace RacingLeaderboards.Domain;

public class Team
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required League League { get; set; }
    
    public required ICollection<Driver> Drivers { get; set; }
}