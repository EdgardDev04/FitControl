using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;
using FitControl.Domain.Enums;
using FitControl.Application.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace FitControl.Infrastructure.Repositories
{
    internal class PromotionRepository : IPromotionRepository
    {
        private readonly FitControlDbContext _context;

        public PromotionRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Promotion promotion)
        {
            await _context.Promotions.AddAsync(promotion);
        }

        public async Task DeleteAsync(Promotion promotion)
        {
            _context.Promotions.Remove(promotion);
        }

        public async Task<bool> ExistsByName(string Name)
        {
            return await _context.Promotions.AsNoTracking().AnyAsync(p => p.Name.ToLower() == Name.ToLower());
        }

        public async Task<ICollection<Promotion>> GetAllActiveAsync()
        {
            return await _context.Promotions.AsNoTracking().Where(p => p.Status == PromotionStatus.Active).ToListAsync();
        }

        public async Task<ICollection<Promotion>> GetAllAsync()
        {
            return await _context.Promotions.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Promotion>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Promotions.AsNoTracking().Where(p => p.StartDate >= startDate && p.EndDate <= endDate).ToListAsync();
        }

        public async Task<ICollection<Promotion>> GetAllByDiscountAmountAsync(decimal minAmount, decimal maxAmount)
        {
            return await _context.Promotions.AsNoTracking().Where(p => p.DiscountAmount >= minAmount && p.DiscountAmount <= maxAmount).ToListAsync();
        }

        public async Task<ICollection<Promotion>> GetAllByDiscountPercentageAsync(decimal minPercentage, decimal maxPercentage)
        {
            return await _context.Promotions.AsNoTracking().Where(p => p.DiscountPercentage >= minPercentage && p.DiscountPercentage <= maxPercentage).ToListAsync();
        }

        public async Task<ICollection<Promotion>> GetAllByDurationAsync(int duration)
        {
            return await _context.Promotions.AsNoTracking().Where(p => p.DurationInDays == duration).ToListAsync();
        }

        public async Task<ICollection<Promotion>> GetAllByFixedPriceAsync(decimal minPrice, decimal maxPrice)
        {
            return await _context.Promotions.AsNoTracking().Where(p => p.FixedPrice >= minPrice && p.FixedPrice <= maxPrice).ToListAsync();
        }

        public async Task<ICollection<Promotion>> GetAllByStatusAsync(PromotionStatus status)
        {
            return await _context.Promotions.AsNoTracking().Where(p => p.Status == status).ToListAsync();
        }

        public async Task<ICollection<Promotion>> GetAllInactiveAsync()
        {
            return await _context.Promotions.AsNoTracking().Where(p => p.Status == PromotionStatus.Inactive).ToListAsync();
        }

        public async Task<Promotion?> GetByIdAsync(int id)
        {
            return await _context.Promotions.FindAsync(id);
        }

        public async Task<Promotion?> GetByNameAsync(string name)
        {
            return await _context.Promotions.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<PagedResult<Promotion>> GetPagedAsync(PaginationParams paginationParams)
        {
            var query = _context.Promotions.AsNoTracking();

            if(!string.IsNullOrEmpty(paginationParams.Search))
            {
                query = query.Where(p => p.Name.Contains(paginationParams.Search) || 
                                         p.Description.Contains(paginationParams.Search) ||
                                         p.DurationInDays.ToString().Contains(paginationParams.Search) ||
                                         p.Status.ToString().Contains(paginationParams.Search)
                 ); 
            }

            var sortBy = paginationParams.SortBy?.Trim() ?? string.Empty;

            query = sortBy switch
            {
                "Name" => paginationParams.Descending ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name),
                "Description" => paginationParams.Descending ? query.OrderByDescending(p => p.Description) : query.OrderBy(p => p.Description),
                "Duration" => paginationParams.Descending ? query.OrderByDescending(p => p.DurationInDays) : query.OrderBy(p => p.DurationInDays),
                "Status" => paginationParams.Descending ? query.OrderByDescending(p => p.Status) : query.OrderBy(p => p.Status),
                _ => paginationParams.Descending ? query.OrderByDescending(p => p.Id) : query.OrderBy(p => p.Id),
            };

            var totalCount = await query.CountAsync();

            var promotions = await query
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<Promotion>
            {
                Items = promotions,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)paginationParams.PageSize)
            };
        }

        public async Task UpdateAsync(Promotion promotion)
        {
            _context.Promotions.Update(promotion);
        }
    }
}
