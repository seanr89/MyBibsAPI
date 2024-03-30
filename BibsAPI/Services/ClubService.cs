

using Microsoft.EntityFrameworkCore;

public class ClubService
{
    private AppDbContext _dbContext;

    public ClubService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Club>> GetClubsAsync()
    {
        return await _dbContext.Clubs
            .Include(c => c.Members)
            .ToListAsync();
    }

    public async Task<Club?> GetClubAsync(int id)
    {
        return await _dbContext.Clubs
            .Include(c => c.Members)
            .FirstAsync(c => c.Id == id);
    }

    /// <summary>
    /// Adds a new club to the database asynchronously.
    /// </summary>
    /// <param name="club">The club to be added.</param>
    /// <returns>The added club.</returns>
    public async Task<Club> AddClubAsync(Club club)
    {
        _dbContext.Clubs.Add(club);
        await _dbContext.SaveChangesAsync();
        return club;
    }

    /// <summary>
    /// Adds a member to a club.
    /// </summary>
    /// <param name="member">The member to add.</param>
    /// <returns>The number of entities written to the database.</returns>
    public async Task<int> AddMemberToClub(Member member)
    {
        var club = await _dbContext.Clubs.FindAsync(member.ClubId);
        if(club == null)
            return 0;
            
        if(club?.Members == null)
            club.Members = new List<Member>();

        if(club.Members.Any(m => m.Email == member.Email))
            return 0;

        member.Club = club;
        try{
            _dbContext.Members.Add(member);
            return await _dbContext.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return 0;
        }
    }

    /// <summary>
    /// Deletes a club from the database asynchronously.
    /// </summary>
    /// <param name="id">The ID of the club to delete.</param>
    /// <returns>The number of state entries written to the database.</returns>
    public async Task<int> DeleteClubAsync(int id)
    {
        var club = await _dbContext.Clubs.FindAsync(id);
        if(club == null)
            return 0;
            
        _dbContext.Clubs.Remove(club);
        return await _dbContext.SaveChangesAsync();
    }
}