
public class Club
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateCreated { get; set; }
    public ICollection<Member>? Members { get; set; } // Collection navigation containing dependents
    public ICollection<Match>? Matches { get; set; } // Collection navigation containing dependents

    public Club(string name, DateTime dateCreated)
    {
        Name = name;
        DateCreated = dateCreated;
    }

    public void AddMember(Member member)
    {
        if (Members == null)
            Members = new List<Member>();

        Members.Add(member);
    }
}