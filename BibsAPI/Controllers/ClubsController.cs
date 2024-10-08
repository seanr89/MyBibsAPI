
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyBibsAPI
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClubsController : ControllerBase
    {
        private readonly ClubService _clubService;
        private readonly ILogger<ClubsController> _logger;
        public ClubsController(ClubService clubService, ILogger<ClubsController> logger)
        {
            _clubService = clubService;
            _logger = logger;
        }

        // GET: api/Clubs
        [HttpGet]
        public ActionResult<IEnumerable<Club>> GetClubs()
        {
            return _clubService.GetClubsAsync().Result.ToList();
        }

        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public ActionResult<Club> GetClub(int id)
        {
            var club = _clubService.GetClubAsync(id).Result;
            if (club == null)
            {
                return NotFound();
            }
            return club;
        }

        // POST: api/Clubs/CreateClub
        [HttpPost("CreateClub")]
        public ActionResult<Club> CreateClub(Club club)
        {
            var created = _clubService.AddClubAsync(club).Result;
            return CreatedAtAction(nameof(GetClub), new { id = created.Id }, club);
        }

        // POST: api/Clubs/AddMemberToClub
        [HttpPost("AddMemberToClub")]
        public async Task<IActionResult> AddMemberToClub(Member member)
        {
            var created = await _clubService.AddMemberToClub(member);
            return Ok("Member added to club");
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var club = await _clubService.DeleteClubAsync(id);
            if (club <= 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}