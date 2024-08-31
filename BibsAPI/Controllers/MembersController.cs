using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]/[action]")]
public class MembersController : ControllerBase{

    private readonly MemberService _memberService;
    public MembersController(MemberService memberService)
    {
        _memberService = memberService;
    }


    // GET: api/Members
    [HttpGet]
    public async Task<IActionResult> GetMembers()
    {
        var result = await _memberService.GetMembersAsync();
        return Ok(result);
    }

    // GET: api/Members/5
    [HttpGet("{ClubId}")]
    public async Task<IActionResult> GetMembersForClub(int ClubId)
    {
        var result = await _memberService.GetMembersForClubAsync(ClubId);
        return Ok(result);
    }
}