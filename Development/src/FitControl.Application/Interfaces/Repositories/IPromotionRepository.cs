using FitControl.Application.Common;
using FitControl.Domain.Entities;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IPromotionRepository : IRepositoryBase<Promotion>
    {
        Task<Promotion> GetByNameAsync(string name);
        Task<ICollection<Promotion>> GetPromotionsByDiscountPercentageAsync(decimal minPercentage, decimal maxPercentage);
        Task<ICollection<Promotion>> GetPromotionsByDiscountAmountAsync(decimal minAmount, decimal maxAmount);
        Task<ICollection<Promotion>> GetPromotionsByFixedPriceAsync(decimal minPrice, decimal maxPrice);
        Task<ICollection<Promotion>> GetPromotionsByDurationAsync(int duration);
        Task<ICollection<Promotion>> GetActivePromotionsAsync();
        Task<ICollection<Promotion>> GetInactivePromotionsAsync();
        Task<ICollection<Promotion>> GetPromotionsByDateRangeAsync(DateTime startDate, DateTime endDate);

    }
}
