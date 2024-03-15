

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class MatchesController : ControllerBase{

    private readonly AppDbContext _dbContext;
    public MatchesController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}