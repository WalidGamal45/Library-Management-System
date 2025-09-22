using Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly IMemberService _memberService;

    public MembersController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMembers()
    {
        var members = await _memberService.GetAllAsync();
        return Ok(members);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMember(int id)
    {
        var member = await _memberService.GetByIdAsync(id);
        if (member == null) return NotFound();
        return Ok(member);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator,Librarian")]
    public async Task<IActionResult> CreateMember([FromBody] MemberDto member)
    {
        var createdMember = await _memberService.CreateAsync(member);
        return CreatedAtAction(nameof(GetMember), new { id = createdMember.Id }, createdMember);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator,Librarian")]
    public async Task<IActionResult> UpdateMember(int id, [FromBody] MemberDto member)
    {
        var updatedMember = await _memberService.UpdateAsync(id, member);
        if (updatedMember == null) return BadRequest();
        return Ok(updatedMember);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteMember(int id)
    {
        var deleted = await _memberService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
