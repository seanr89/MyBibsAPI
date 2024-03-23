
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class RandomizeController : ControllerBase
{
    private readonly ILogger<RandomizeController> _logger;
    private readonly ClubService _clubService;
    public RandomizeController(ILogger<RandomizeController> logger,
        ClubService clubService)
    {
        _logger = logger;
        _clubService = clubService;
    }

    /// <summary>
    /// Basic/Crappy randomizer
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns> <summary>
    [HttpPost]
    public ActionResult<Game> RandomizePlayers(Game game)
    {
        _logger.LogInformation("Randomizing players");
        var random = new Random();
        var randomizedPlayers = game.AllPlayers.OrderBy(p => random.Next()).ToList();
        game.AllPlayers = randomizedPlayers;
        game.TeamOne = randomizedPlayers.Take(randomizedPlayers.Count / 2).ToList();
        game.TeamTwo = randomizedPlayers.Skip(randomizedPlayers.Count / 2).ToList();
        return game;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBasicGame(CreateGameDTO gameDTO)
    {
        _logger.LogInformation("CreateBasicGame");
        var club = await _clubService.GetClubAsync(gameDTO.clubId);
        if(club == null)
            NotFound();

        var game = new Game(){
            ClubId = gameDTO.clubId,
            Location = gameDTO.location,
            EventDate = gameDTO.date,
            AllPlayers = new List<Player>()
        };

        foreach (var member in club?.Members?.Where(m => m.Active) ?? [])
        {
            Player player = new Player
            {
                Name = member.FullName(),
                Rating = 50
            };
            game.AllPlayers.Add(player);
        }

        return Ok(game);
    }
}