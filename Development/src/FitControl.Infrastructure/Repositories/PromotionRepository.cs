using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;
using FitControl.Domain.Enums;
using FitControl.Application.Common;

namespace FitControl.Infrastructure.Repositories
{
    internal class PromotionRepository : IPromotionRepository
    {
        private readonly FitControlDbContext _context;

        public PromotionRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Promotion promotion) => await _context.Promotions.AddAsync(promotion);
        public async Task DeleteAsync(Promotion promotion) => _context.Promotions.Remove(promotion);
        public async Task<bool> ExistsByName(string Name) => await _context.Promotions.AsNoTracking().AnyAsync(p => p.Name.ToLower() == Name.ToLower());
        public async Task<ICollection<Promotion>> GetAllActiveAsync() => await _context.Promotions.AsNoTracking().Where(p => p.Status == PromotionStatus.Active).ToListAsync();
        public async Task<ICollection<Promotion>> GetAllAsync() => await _context.Promotions.AsNoTracking().ToListAsync();
        public async Task<ICollection<Promotion>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate) => await _context.Promotions.AsNoTracking().Where(p => p.StartDate >= startDate && p.EndDate <= endDate).ToListAsync();
        public async Task<ICollection<Promotion>> GetAllByDiscountAmountAsync(decimal minAmount, decimal maxAmount) => await _context.Promotions.AsNoTracking().Where(p => p.DiscountAmount >= minAmount && p.DiscountAmount <= maxAmount).ToListAsync();
        public async Task<ICollection<Promotion>> GetAllByDiscountPercentageAsync(decimal minPercentage, decimal maxPercentage) => await _context.Promotions.AsNoTracking().Where(p => p.DiscountPercentage >= minPercentage && p.DiscountPercentage <= maxPercentage).ToListAsync();
        public async Task<ICollection<Promotion>> GetAllByDurationAsync(int duration) => await _context.Promotions.AsNoTracking().Where(p => p.DurationInDays == duration).ToListAsync();
        public async Task<ICollection<Promotion>> GetAllByFixedPriceAsync(decimal minPrice, decimal maxPrice) => await _context.Promotions.AsNoTracking().Where(p => p.FixedPrice >= minPrice && p.FixedPrice <= maxPrice).ToListAsync();
        public async Task<ICollection<Promotion>> GetAllByStatusAsync(PromotionStatus status) => await _context.Promotions.AsNoTracking().Where(p => p.Status == status).ToListAsync();
        public async Task<ICollection<Promotion>> GetAllInactiveAsync() => await _context.Promotions.AsNoTracking().Where(p => p.Status == PromotionStatus.Inactive).ToListAsync();
        public async Task<Promotion?> GetByIdAsync(int id) => await _context.Promotions.FindAsync(id);
        public async Task<Promotion?> GetByNameAsync(string name) => await _context.Promotions.FirstOrDefaultAsync(p => p.Name == name);

        public Task<PagedResult<Promotion>> GetPagedAsync(PaginationParams paginationParams)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Promotion promotion) => _context.Promotions.Update(promotion);
    }
}
