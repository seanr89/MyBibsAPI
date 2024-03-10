
public class Club
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateCreated { get; set; }
    public List<Member>? Members { get; set; }
}