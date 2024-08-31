
public record Player
{
    public int Id { get; init; }
    public string Name { get; init; }
    public double Rating { get; init; } = 50;
    public Guid MemberId { get; set; }
    public int MatchId { get; set; }   
    public Match Match { get; set; }
    public string Team { get; set; }
}