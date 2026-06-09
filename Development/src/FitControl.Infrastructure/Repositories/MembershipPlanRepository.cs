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

        public async Task<bool> ExistByNameAsync(string name) => await _context.MembershipPlans.AsNoTracking().AnyAsync(m => m.Name.ToLower() == name.ToLower());
        public async Task AddAsync(MembershipPlan membershipPlan) => await _context.MembershipPlans.AddAsync(membershipPlan);
        public async Task DeleteAsync(MembershipPlan membershipPlan) => _context.MembershipPlans.Remove(membershipPlan);
        public async Task<ICollection<MembershipPlan>> GetAllActiveAsync() => await _context.MembershipPlans.AsNoTracking().Where(m => m.IsActive == true).ToListAsync();
        public async Task<ICollection<MembershipPlan>> GetAllAsync() => await _context.MembershipPlans.AsNoTracking().ToListAsync();
        public async Task<ICollection<MembershipPlan>> GetAllInactiveAsync() => await _context.MembershipPlans.AsNoTracking().Where(m => m.IsActive == false).ToListAsync();
        public async Task<MembershipPlan?> GetByIdAsync(int id) => await _context.MembershipPlans.FindAsync(id);
        public async Task<MembershipPlan?> GetByNameAsync(string name) => await _context.MembershipPlans.FirstOrDefaultAsync(m => m.Name == name);
        public async Task<ICollection<MembershipPlan>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice) => await _context.MembershipPlans.AsNoTracking().Where(m => m.Price >= minPrice && m.Price <= maxPrice).ToListAsync();
        public async Task UpdateAsync(MembershipPlan membershipPlan) => _context.MembershipPlans.Update(membershipPlan);

        public Task<PagedResult<MembershipPlan>> GetPagedAsync(PaginationParams paginationParams)
        {
            throw new NotImplementedException();
        }
    }
}
