

public record Game
{
    public int Id { get; init; }
    public string Location { get; init; }
    public DateTime EventDate { get; init; }
    public List<Player> TeamOne { get; set; }
    public List<Player> TeamTwo { get; set; }

    public List<Player> AllPlayers { get; set; }

}

public record Player
{
    public int Id { get; init; }
    public string Name { get; init; }
    public double Rating { get; init; }
}