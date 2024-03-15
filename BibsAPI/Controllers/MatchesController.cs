using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MatchesController : ControllerBase
{

    private readonly AppDbContext _dbContext;
    public MatchesController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}