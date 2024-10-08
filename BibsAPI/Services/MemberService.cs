
using Microsoft.EntityFrameworkCore;

public class MemberService
{
    private AppDbContext _dbContext;

    public MemberService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Member>> GetMembersAsync()
    {
        return await _dbContext.Members.ToListAsync();
    }

    public async Task<IEnumerable<Member>> GetMembersForClubAsync(int clubId)
    {
        return await _dbContext.Members
            .Where(m => m.ClubId == clubId)
            .ToListAsync();
    }

    public async Task<Member?> GetMemberAsync(int id)
    {
        return await _dbContext.Members
            .FindAsync(id);
    }
}
