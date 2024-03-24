
public class Member
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool Active { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Rating { get; set; } = 50;
    public int ClubId { get; set; } // Required foreign key property
    public Club? Club { get; set; } = null!; // Required reference navigation to principal

    public string FullName() => $"{FirstName} {LastName}";
    
    public Member()
    {
        
    }

    public Member(string email, string firstName, string lastname, int rating)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastname;
        Rating = rating;
    }
}