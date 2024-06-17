
public class Score
{
    public int Id { get; set; }
    public int MatchId { get; set; }
    public Match Match { get; set; }
    public string Winner { get; set; }
    public int TeamOneGoalCount { get; set; }
    public int TeamTwoGoalCount { get; set; }

    public Score()
    {
        
    }
}

