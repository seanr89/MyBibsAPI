

/// <summary>
/// Represents a match/event scheduled for a club.
/// </summary>
public class Match
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public bool Complete { get; set; }
    public int ClubId { get; set; }
    public Club Club { get; set; }

    public Match()
    {
        
    }

    public Match(DateTime date, bool complete)
    {
        Date = date;
        Complete = complete;
    }
}