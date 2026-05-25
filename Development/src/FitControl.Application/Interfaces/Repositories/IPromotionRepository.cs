using FitControl.Application.Common;
using FitControl.Domain.Entities;

namespace FitControl.Application.Interfaces.Repositories
{
    public interface IPromotionRepository : IRepositoryBase<Promotion>
    {
        Task<Promotion> GetByNameAsync(string name);
        Task<ICollection<Promotion>> GetAllByDiscountPercentageAsync(decimal minPercentage, decimal maxPercentage);
        Task<ICollection<Promotion>> GetAllByDiscountAmountAsync(decimal minAmount, decimal maxAmount);
        Task<ICollection<Promotion>> GetAllByFixedPriceAsync(decimal minPrice, decimal maxPrice);
        Task<ICollection<Promotion>> GetAllByDurationAsync(int duration);
        Task<ICollection<Promotion>> GetAllActiveAsync();
        Task<ICollection<Promotion>> GetAllInactiveAsync();
        Task<ICollection<Promotion>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate);

    }
}
