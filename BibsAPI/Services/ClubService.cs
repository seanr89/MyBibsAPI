

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
            .FindAsync(id);
    }

    public async Task<Club> AddClubAsync(Club club)
    {
        _dbContext.Clubs.Add(club);
        await _dbContext.SaveChangesAsync();
        return club;
    }

    public async Task<int> AddMemberToClub(Member member)
    {
        var club = await _dbContext.Clubs.FindAsync(member.ClubId);
        if(club.Members == null)
        {
            club.Members = new List<Member>();
        }
        if(club.Members.Any(m => m.Email == member.Email))
        {
            return 0;
        }
        member.Club = club;
        //club.Members.Add(member);
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

    public async Task<int> DeleteClubAsync(int id)
    {
        var club = await _dbContext.Clubs.FindAsync(id);
        _dbContext.Clubs.Remove(club);
        return await _dbContext.SaveChangesAsync();
    }
}