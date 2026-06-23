using FitControl.Application.Common;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces.Services;
using FitControl.Application.Services;
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

        [HttpGet]
        public async Task<IActionResult> GetMemberships([FromQuery] PaginationParams paginationParams)
        {
            var result = await _membershipService.GetPagedMembershipsAsync(paginationParams);

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllMemberships()
        {
            var memberships = await _membershipService.GetAllMembershipAsync();

            return Ok(memberships);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMembership([FromRoute] int id)
        {
            var membership = await _membershipService.GetMembershipAsync(id);

            return Ok(membership);
        }

        [HttpGet("membership-plan/{membershipPlanId:int}")]
        public async Task<IActionResult> GetAllMembershipsByMembershipPlan([FromRoute] int membershipPlanId)
        {
            var memberships = await _membershipService.GetMembershipsByMembershipPlanIdAsync(membershipPlanId);

            return Ok(memberships);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetAllMembershipsByStatus([FromRoute] MembershipStatus status)
        {
            var memberships = await _membershipService.GetMembershipByStatusAsync(status);

            return Ok(memberships);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMemberships([FromBody] CreateMembershipDto dto)
        {
            var createdMembership = await _membershipService.CreateMembershipAsync(dto);

            return CreatedAtAction(nameof(GetMembership), new { id = createdMembership.Id }, createdMembership);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMemberships([FromRoute] int id, [FromBody] UpdateMembershipDto dto)
        {
            await _membershipService.UpdateMembershipAsync(id, dto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMemberships([FromRoute] int id)
        {
            await _membershipService.DeleteMembershipAsync(id);

            return NoContent();
        }
    }
}