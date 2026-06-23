using FitControl.Application.Common;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitControl.WebAPI.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetMembers([FromQuery] PaginationParams paginationParams)
        {
            var result = await _memberService.GetPagedMembersAsync(paginationParams);

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _memberService.GetAllMembersAsync();

            return Ok(members);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMember([FromRoute] int id)
        {
            var member = await _memberService.GetMemberAsync(id);

            return Ok(member);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetMemberByEmail([FromRoute] string email)
        {
            var member = await _memberService.GetMemberByEmailAsync(email);

            return Ok(member);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetMemberByName([FromRoute] string name)
        {
            var member = await _memberService.GetMemberByNameAsync(name);

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

        [HttpPost]
        public async Task<IActionResult> CreateMember([FromBody] CreateMemberDto createMemberDto)
        {
            var member = await _memberService.CreateMemberAsync(createMemberDto);

            return CreatedAtAction(nameof(GetAllMembers), new { id = member.Id }, member);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMember([FromRoute] int id, [FromBody] UpdateMemberDto updateMemberDto)
        {
            await _memberService.UpdateMemberAsync(id, updateMemberDto);

            return NoContent();
        }

        [HttpPatch("change-status/{id:int}/{status:bool}")]
        public async Task<IActionResult> ChangeMemberStatus([FromRoute] int id, [FromRoute] bool status)
        {
            await _memberService.ChangeMemberStatusAsync(id, status);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMember([FromRoute] int id)
        {
            await _memberService.DeleteMemberAsync(id);

            return NoContent();
        }
    }
}