using FitControl.Application.DTOs;
using FitControl.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitControl.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _memberService.GetAllMembersAsync();

            return Ok(members);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember([FromBody] CreateMemberDto createMemberDto)
        {
            var member = await _memberService.CreateMemberAsync(createMemberDto);

            return CreatedAtAction(nameof(GetAllMembers), new { id = member.Id }, member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, [FromBody] UpdateMemberDto updateMemberDto)
        {
            await _memberService.UpdateMemberAsync(id, updateMemberDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            await _memberService.DeleteMemberAsync(id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember(int id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetMemberByEmail(string email)
        {
            var member = await _memberService.GetMemberByEmailAsync(email);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetMemberByName(string name)
        {
            var member = await _memberService.GetMemberByNameAsync(name);

            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveMembers()
        {
            var members = await _memberService.GetActiveMembersAsync();

            return Ok(members);
        }

        [HttpGet("inactive")]
        public async Task<IActionResult> GetInactiveMembers()
        {
            var members = await _memberService.GetInactiveMembersAsync();

            return Ok(members);
        }
    }
}