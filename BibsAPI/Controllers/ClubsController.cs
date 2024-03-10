
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyBibsAPI
{
    [ApiController]
    [Route("api/[controller]")]
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

        // POST: api/Clubs
        [HttpPost("CreateClub")]
        public ActionResult<Club> CreateClub(Club club)
        {
            var created = _clubService.AddClubAsync(club).Result;
            return CreatedAtAction(nameof(GetClub), new { id = created.Id }, club);
        }

        // POST: api/Clubs/5
        [HttpPost("AddMemberToClub")]
        public ActionResult<Club> AddMemberToClub(Member member)
        {
            var created = _clubService.AddMemberToClub(member).Result;
            return Ok("Member added to club");
        }

        // PUT: api/Clubs/5
        // [HttpPut("{id}")]
        // public IActionResult PutClub(int id, Club club)
        // {
        //     if (id != club.Id)
        //     {
        //         return BadRequest();
        //     }
        //     var existingClub = clubs.Find(c => c.Id == id);
        //     if (existingClub == null)
        //     {
        //         return NotFound();
        //     }
        //     existingClub.Name = club.Name; // Update other properties as needed
        //     return NoContent();
        // }

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