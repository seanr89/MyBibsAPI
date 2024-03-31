using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]/[action]")]
public class MembersController : ControllerBase{

    private readonly AppDbContext _dbContext;
    public MembersController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    // GET: api/Members
    [HttpGet]
    public ActionResult<IEnumerable<Member>> GetMembers()
    {
        return _dbContext.Members.Include(m => m.Club).ToList();
    }

    // GET: api/Members/5
    [HttpGet("{ClubId}")]
    public ActionResult<IEnumerable<Member>> GetMembersForClub(int ClubId)
    {
        return _dbContext.Members.Include(m => m.Club).ToList();
    }
}