using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces.Services
{
    public interface IPromotionService
    {
        Task CreatePromotionAsync(CreatePromotionDto dto);
        Task UpdatePromotionAsync(UpdatePromotionDto dto);
        Task DeletePromotionAsync(int id);
        Task<PromotionDto> GetPromotionByIdAsync(int id);
        Task<ICollection<PromotionDto>> GetAllPromotionsAsync();
        Task<ICollection<PromotionDto>> GetActivePromotionsAsync();
        Task<ICollection<PromotionDto>> GetPromotionsByMembershipPlanIdAsync(int membershipPlanId);
        Task<ICollection<PromotionDto>> GetPromotionsByStatusAsync(string status);
        Task<ICollection<PromotionDto>> GetPromotionsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<ICollection<PromotionDto>> GetPromotionsByUserIdAsync(int userId);
    }
}
