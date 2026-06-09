using FitControl.Application.DTOs;
using FitControl.Application.Interfaces.Services;
using FitControl.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace FitControl.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromotionsController : ControllerBase
    {
        private readonly IPromotionService _promotionService;

        public PromotionsController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPromotions()
        {
            var promotions = await _promotionService.GetAllPromotionsAsync();

            return Ok(promotions);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPromotion([FromRoute] int id)
        {
            var promotion = await _promotionService.GetPromotionAsync(id);

            return Ok(promotion);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActivePromotions()
        {
            var activePromotions = await _promotionService.GetActivePromotionsAsync();

            return Ok(activePromotions);
        }

        [HttpGet("membership-plan/{membershipPlanId:int}")]
        public async Task<IActionResult> GetPromotionsByMembershipPlanId([FromRoute] int membershipPlanId)
        {
            var promotions = await _promotionService.GetPromotionsByMembershipPlanIdAsync(membershipPlanId);

            return Ok(promotions);
        }

        [HttpGet("range")]
        public async Task<IActionResult> GetAllPromotionsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var promotions = await _promotionService.GetPromotionsByDateRangeAsync(startDate, endDate);

            return Ok(promotions);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetAllPromotionsByStatus([FromRoute] PromotionStatus status)
        {
            var promotions = await _promotionService.GetPromotionsByStatusAsync(status);

            return Ok(promotions);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion([FromBody] CreatePromotionDto dto)
        {
            await _promotionService.CreatePromotionAsync(dto);

            return Created();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePromotion([FromRoute] int id, [FromBody] UpdatePromotionDto dto)
        {
            await _promotionService.UpdatePromotionAsync(id, dto);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePromotion([FromRoute] int id)
        {
            await _promotionService.DeletePromotionAsync(id);

            return NoContent();
        }
    }
}
