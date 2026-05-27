using FitControl.Application.DTOs;
using FitControl.Application.Interfaces.Services;
using FitControl.Domain.Entities;
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
        public async Task<IActionResult> GetAllMembershipPlan()
        {
            var membershipPlans = await _membershipPlanService.GetAllMembershipPlanAsync();

            return Ok(membershipPlans);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMembershipPlan(CreateMembershipPlanDto dto)
        {
            var membershipPlan = await _membershipPlanService.CreateMembershipPlanAsync(dto);

            return CreatedAtAction(nameof(GetAllMembershipPlan), new { id = membershipPlan.Id }, membershipPlan);
        }
    }
}
