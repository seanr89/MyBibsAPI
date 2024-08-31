
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class RandomizeController : ControllerBase
{
    private readonly ILogger<RandomizeController> _logger;
    private readonly ClubService _clubService;
    private readonly RandomService _randomService;
    public RandomizeController(ILogger<RandomizeController> logger,
        ClubService clubService, RandomService randomService)
    {
        _logger = logger;
        _clubService = clubService;
        _randomService = randomService;
    }

    /// <summary>
    /// Basic/Crappy Randomizer
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns> <summary>
    [HttpPost]
    public ActionResult<Game> RandomizePlayers(Game game)
    {
        _logger.LogInformation("Randomizing players");
        var random = new Random();
        var randomizedPlayers = game.AllPlayers?.OrderBy(p => random.Next()).ToList();
        if(randomizedPlayers == null)
            return BadRequest("No players to randomize");
        
        // Add all players to the game
        game.AllPlayers = randomizedPlayers;
        game.TeamOne = _randomService.SetTeamForPlayers(randomizedPlayers.Take(randomizedPlayers.Count / 2).ToList(), "Team One");
        game.TeamTwo = _randomService.SetTeamForPlayers(randomizedPlayers.Skip(randomizedPlayers.Count / 2).ToList(), "Team Two");
        return game;
    }


    /// <summary>
    /// Creates a basic game using the provided game DTO.
    /// </summary>
    /// <param name="gameDTO">The game DTO containing the necessary information for creating the game.</param>
    /// <returns>An asynchronous task that represents the operation and holds the result of the action.</returns>
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
                Rating = member.Rating,
                MemberId = member.Id
            };
            game.AllPlayers.Add(player);
        }

        //TODO do we need to save the game?

        return Ok(game);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRatingsGame(CreateGameDTO gameDTO)
    {
        throw new NotImplementedException();
    }
}