using FitControl.Application.DTOs;
using FitControl.Application.Interfaces.Services;
using FitControl.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FitControl.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembershipsController : ControllerBase
    {
        private readonly IMembershipService _membershipService;

        public MembershipsController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMemberships([FromRoute] int id)
        {
            await _membershipService.DeleteMembershipAsync(id);

            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMembership([FromRoute] int id)
        {
            var membership = await _membershipService.GetMembershipAsync(id);

            return Ok(membership);
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllMemberships()
        {
            var memberships = await _membershipService.GetAllMembershipAsync();

            return Ok(memberships);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetAllMembershipsByStatus(MembershipStatus status)
        {
            var memberships = await _membershipService.GetMembershipByStatusAsync(status);

            return Ok(memberships);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMemberships([FromRoute] int id, [FromBody] UpdateMembershipDto dto)
        {
            await _membershipService.UpdateMembershipAsync(id, dto);

            return NoContent();
        }
    }
}