

public record Game
{
    public int ClubId { get; init; }
    public string Location { get; init; }
    public DateTime EventDate { get; init; }
    public List<Player>? TeamOne { get; set; }
    public List<Player>? TeamTwo { get; set; }
    public List<Player>? AllPlayers { get; set; }
}
