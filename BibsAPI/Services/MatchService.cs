
using Microsoft.EntityFrameworkCore;

public class MatchService
{
    private AppDbContext _dbContext;

    public MatchService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Match>> GetMatches()
    {
        return await _dbContext.Matches.ToListAsync();
    }

    public async Task<IEnumerable<Match>> GetMatchesForClub(int cludId)
    {
        return await _dbContext.Matches.Where(m => m.ClubId == cludId).ToListAsync();
    }
    
    public async Task<Match?> GetMatch(int id)
    {
        return await _dbContext.Matches.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Match> CreateMatch(Match match)
    {
        _dbContext.Matches.Add(match);
        await _dbContext.SaveChangesAsync();
        return match;
    }
}
