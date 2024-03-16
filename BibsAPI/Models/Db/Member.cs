
public class Member
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool Active { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ClubId { get; set; } // Required foreign key property
    public Club? Club { get; set; } = null!; // Required reference navigation to principal

    public string FullName() => $"{FirstName} {LastName}";
}