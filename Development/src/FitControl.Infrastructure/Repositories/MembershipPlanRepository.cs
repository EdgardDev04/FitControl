using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;
using FitControl.Application.Common;

namespace FitControl.Infrastructure.Repositories
{
    internal class MembershipPlanRepository : IMembershipPlanRepository
    {
        private readonly FitControlDbContext _context;

        public MembershipPlanRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistByNameAsync(string name)
        {
            return await _context.MembershipPlans.AsNoTracking().AnyAsync(m => m.Name.ToLower() == name.ToLower());
        }

        public async Task AddAsync(MembershipPlan membershipPlan)
        {
            await _context.MembershipPlans.AddAsync(membershipPlan);
        }

        public async Task DeleteAsync(MembershipPlan membershipPlan)
        {
            _context.MembershipPlans.Remove(membershipPlan);
        }

        public async Task<ICollection<MembershipPlan>> GetAllActiveAsync()
        {
            return await _context.MembershipPlans.AsNoTracking().Where(m => m.IsActive == true).ToListAsync();
        }

        public async Task<ICollection<MembershipPlan>> GetAllAsync()
        {
            return await _context.MembershipPlans.AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<MembershipPlan>> GetAllInactiveAsync()
        {
            return await _context.MembershipPlans.AsNoTracking().Where(m => m.IsActive == false).ToListAsync();
        }

        public async Task<MembershipPlan?> GetByIdAsync(int id) 
        { 
            return await _context.MembershipPlans.FindAsync(id); 
        }

        public async Task<MembershipPlan?> GetByNameAsync(string name)
        {
            return await _context.MembershipPlans.FirstOrDefaultAsync(m => m.Name == name);
        }

        public async Task<ICollection<MembershipPlan>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        { 
            return await _context.MembershipPlans.AsNoTracking().Where(m => m.Price >= minPrice && m.Price <= maxPrice).ToListAsync();
        }

        public async Task UpdateAsync(MembershipPlan membershipPlan)
        {
            _context.MembershipPlans.Update(membershipPlan);
        }

        public async Task<PagedResult<MembershipPlan>> GetPagedAsync(PaginationParams paginationParams)
        {
            var query = _context.MembershipPlans.AsNoTracking();

            if (!string.IsNullOrEmpty(paginationParams.Search))
            {
                query = query.Where(m => m.Name.Contains(paginationParams.Search) || 
                m.Description.Contains(paginationParams.Search) ||
                m.Price.ToString().Contains(paginationParams.Search)
                );
            }

            var sort = paginationParams.SortBy?.Trim() ?? string.Empty;

            query = sort switch
            {
                "Name" => paginationParams.Descending ? query.OrderByDescending(m => m.Name) : query.OrderBy(m => m.Name),
                "Price" => paginationParams.Descending ? query.OrderByDescending(m => m.Price) : query.OrderBy(m => m.Price),
                "Duration" => paginationParams.Descending ? query.OrderByDescending(m => m.DurationInDays) : query.OrderBy(m => m.DurationInDays),
                _ => query.OrderBy(m => m.Id)
            };

            var totalCount = await query.CountAsync();

            var membershipPlans = await query
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<MembershipPlan>
            {
                Items = membershipPlans,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)paginationParams.PageSize)
            };
        }
    }
}
