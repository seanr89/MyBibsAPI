
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class RandomizeController : ControllerBase
{
    private readonly ILogger<RandomizeController> _logger;
    public RandomizeController(ILogger<RandomizeController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Basic/Crappy randomizer
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<Game> RandomizePlayers(Game game)
    {
        var random = new Random();
        var randomizedPlayers = game.AllPlayers.OrderBy(p => random.Next()).ToList();
        game.AllPlayers = randomizedPlayers;
        game.TeamOne = randomizedPlayers.Take(randomizedPlayers.Count / 2).ToList();
        game.TeamTwo = randomizedPlayers.Skip(randomizedPlayers.Count / 2).ToList();
        return game;
    }

    [HttpPost]
    public ActionResult<Game> CreateGame(string location, DateTime date)
    {
        throw new NotImplementedException();
    }
}