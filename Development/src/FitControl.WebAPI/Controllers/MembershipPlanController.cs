using FitControl.Application.Common;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces.Services;
using FitControl.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitControl.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembershipPlanController : ControllerBase
    {
        private readonly IMembershipPlanService _membershipPlanService;

        public MembershipPlanController(IMembershipPlanService membershipPlanService)
        {
            _membershipPlanService = membershipPlanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMembershipPlans([FromQuery] PaginationParams paginationParams)
        {
            var result = await _membershipPlanService.GetPagedMembershipPlansAsync(paginationParams);

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllMembershipPlan()
        {
            var membershipPlans = await _membershipPlanService.GetAllMembershipPlanAsync();

            return Ok(membershipPlans);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMembershipPlan([FromRoute] int id)
        {
            var membershipPlan = await _membershipPlanService.GetMembershipPlanAsync(id);

            return Ok(membershipPlan);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveMembershipPlans()
        {
            var activeMembershipPlans = await _membershipPlanService.GetActivePlansAsync();

            return Ok(activeMembershipPlans);
        }

        [HttpGet("inactive")]
        public async Task<IActionResult> GetInactiveMembershipPlans()
        {
            var inactiveMembershipPlans = await _membershipPlanService.GetInactivePlansAsync();

            return Ok(inactiveMembershipPlans);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMembershipPlan([FromBody] CreateMembershipPlanDto dto)
        {
            var membershipPlan = await _membershipPlanService.CreateMembershipPlanAsync(dto);

            return CreatedAtAction(nameof(GetAllMembershipPlan), new { id = membershipPlan.Id }, membershipPlan);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMembershipPlan([FromRoute] int id, [FromBody] UpdateMembershipPlanDto dto)
        {
            await _membershipPlanService.UpdateMembershipPlanAsync(id, dto);

            return NoContent();
        }

        [HttpPatch("update-price/{id:int}/{price:decimal}")]
        public async Task<IActionResult> UpdateMembershipPlanPrice([FromRoute] int id, [FromRoute] decimal price)
        {
            await _membershipPlanService.UpdatePlanPriceAsync(id, price);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMembershipPlan([FromRoute] int id)
        {
            await _membershipPlanService.DeleteMembershipPlanAsync(id);

            return NoContent();
        }
    }
}
