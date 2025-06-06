
public record Player
{
    public int Id { get; init; }
    /// <summary>
    /// Name of player!
    /// </summary>
    /// <value></value>
    public string Name { get; init; }
    /// <summary>
    /// Rating with a default value of 50 for now!
    /// </summary>
    /// <value></value>
    public double Rating { get; init; } = 50;
    public Guid MemberId { get; set; }
    public int MatchId { get; set; }   
    public Match Match { get; set; }
    public string Team { get; set; }
}