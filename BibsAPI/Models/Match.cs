

public class Match
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public bool Complete { get; set; }
    public Guid ClubId { get; set; }
    public Club Club { get; set; }
}