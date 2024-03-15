
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RandomizeController : ControllerBase
{
    private readonly ILogger<RandomizeController> _logger;
    public RandomizeController(ILogger<RandomizeController> logger)
    {
        _logger = logger;
    }

    // GET: api/Randomizer
    [HttpPost]
    public ActionResult<Game> RandomizePlayers(Game game)
    {
        //var allPlayers = game.TeamOne.Concat(game.TeamTwo).ToList();
        var random = new Random();
        var randomizedPlayers = game.AllPlayers.OrderBy(p => random.Next()).ToList();
        game.AllPlayers = randomizedPlayers;
        game.TeamOne = randomizedPlayers.Take(randomizedPlayers.Count / 2).ToList();
        game.TeamTwo = randomizedPlayers.Skip(randomizedPlayers.Count / 2).ToList();
        return game;
    }
}