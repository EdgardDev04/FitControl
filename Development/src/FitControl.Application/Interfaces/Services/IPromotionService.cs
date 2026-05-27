using FitControl.Application.DTOs;
using FitControl.Domain.Enums;

namespace FitControl.Application.Interfaces.Services
{
    public interface IPromotionService
    {
        Task<PromotionDto> CreatePromotionAsync(CreatePromotionDto dto);
        Task UpdatePromotionAsync(int Id, UpdatePromotionDto dto);
        Task DeletePromotionAsync(int id);
        Task<PromotionDto> GetPromotionByIdAsync(int id);
        Task<ICollection<PromotionDto>> GetAllPromotionsAsync();
        Task<ICollection<PromotionDto>> GetActivePromotionsAsync();
        Task<ICollection<PromotionDto>> GetPromotionsByMembershipPlanIdAsync(int membershipPlanId);
        Task<ICollection<PromotionDto>> GetPromotionsByStatusAsync(PromotionStatus status);
        Task<ICollection<PromotionDto>> GetPromotionsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<ICollection<PromotionDto>> GetPromotionsByUserIdAsync(int userId);
    }
}
