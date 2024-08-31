

public class RandomService
{
    public RandomService()
    {
        
    }

    /// <summary>
    /// Creates a basic game team using the provided game DTO.
    /// </summary>
    /// <param name="players">players to be stitched with the team name</param>
    /// <param name="teamName"></param>
    /// <returns></returns>
    public List<Player> SetTeamForPlayers(List<Player> players, string teamName)
    {
        foreach (var player in players)
        {
            player.Team = teamName;
        }
        return players;
    }
}