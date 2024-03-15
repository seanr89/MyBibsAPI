using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
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
}