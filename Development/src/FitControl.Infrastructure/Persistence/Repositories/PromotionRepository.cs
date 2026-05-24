using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;

namespace FitControl.Infrastructure.Persistence.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly FitControlDbContext _context;

        public PromotionRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Promotion promotion) => await _context.Promotions.AddAsync(promotion);
        public async Task DeleteAsync(Promotion promotion) => _context.Promotions.Remove(promotion);

        public Task<ICollection<Promotion>> GetActivePromotionsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Promotion>> GetAllAsync() => await _context.Promotions.ToListAsync();
        public async Task<Promotion?> GetByIdAsync(int id) => await _context.Promotions.FindAsync(id);
        public async Task<Promotion?> GetByNameAsync(string name) => await _context.Promotions.FirstOrDefaultAsync(p => p.Name == name);
        public async Task<ICollection<Promotion>> GetInactivePromotionsAsync() => await _context.Promotions.Where(p => p.IsActive == false).ToListAsync();
        public async Task<ICollection<Promotion>> GetPromotionsByDateRangeAsync(DateTime startDate, DateTime endDate) => await _context.Promotions.Where(p => p.StartDate >= startDate && p.EndDate <= endDate).ToListAsync();
        public async Task<ICollection<Promotion>> GetPromotionsByDiscountAmountAsync(decimal minAmount, decimal maxAmount) => await _context.Promotions.Where(p => p.DiscountAmount >= minAmount && p.DiscountAmount <= maxAmount).ToListAsync();
        public async Task<ICollection<Promotion>> GetPromotionsByDiscountPercentageAsync(decimal minPercentage, decimal maxPercentage) => await _context.Promotions.Where(p => p.DiscountPercentage >= minPercentage && p.DiscountPercentage <= maxPercentage).ToListAsync();
        public async Task<ICollection<Promotion>> GetPromotionsByDurationAsync(int duration) => await _context.Promotions.Where(p => p.DurationInDays == duration).ToListAsync();
        public async Task<ICollection<Promotion>> GetPromotionsByFixedPriceAsync(decimal minPrice, decimal maxPrice) => await _context.Promotions.Where(p => p.FixedPrice >= minPrice && p.FixedPrice <= maxPrice).ToListAsync();
        public async Task UpdateAsync(Promotion promotion) => _context.Promotions.Update(promotion);
    }
}
