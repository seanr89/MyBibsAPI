using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class MatchesController : ControllerBase
{
    private readonly MatchService _matchService;
    public MatchesController(MatchService matchService)
    {
        _matchService = matchService;
    }

    // GET: api/Matches
    [HttpGet]
    public async Task<IActionResult> GetMatches()
    {
        var result = await _matchService.GetMatches();
        return Ok(result);
    }

    // GET: api/Matches/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMatch(int id)
    {
        var match = await _matchService.GetMatch(id);
        if (match == null)
        {
            return NotFound();
        }
        return Ok(match);
    }
}