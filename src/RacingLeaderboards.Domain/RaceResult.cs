namespace RacingLeaderboards.Domain;

public class RaceResult
{
    public int Id { get; set; }

    public byte Position { get; set; }

    public ushort Points { get; set; }

    public required Driver Driver { get; set; }

    public required RaceEvent RaceEvent { get; set; }
}