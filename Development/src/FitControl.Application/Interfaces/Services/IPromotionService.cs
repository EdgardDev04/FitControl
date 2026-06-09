using FitControl.Application.DTOs;
using FitControl.Domain.Enums;

namespace FitControl.Application.Interfaces.Services
{
    public interface IPromotionService
    {
        Task<PromotionDto> CreatePromotionAsync(CreatePromotionDto dto);
        Task UpdatePromotionAsync(int Id, UpdatePromotionDto dto);
        Task DeletePromotionAsync(int id);
        Task<PromotionDto> GetPromotionAsync(int id);
        Task<ICollection<PromotionDto>> GetAllPromotionsAsync();
        Task<ICollection<PromotionDto>> GetActivePromotionsAsync();
        Task<ICollection<PromotionDto>> GetPromotionsByMembershipPlanIdAsync(int membershipPlanId);
        Task<ICollection<PromotionDto>> GetPromotionsByStatusAsync(PromotionStatus status);
        Task<ICollection<PromotionDto>> GetPromotionsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<PromotionValidationResultDto> ValidatePromotionCodeAsync(string code, int memberId, int? planId = null);
        Task<decimal> CalculateDiscountedPriceAsync(decimal basePrice, string promoCode);
    }
}
