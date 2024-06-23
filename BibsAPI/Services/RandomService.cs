

public class RandomService
{
    public RandomService()
    {
        
    }

    public List<Player> SetTeamForPlayers(List<Player> players, string teamName)
    {
        foreach (var player in players)
        {
            player.Team = teamName;
        }
        return players;
    }
}