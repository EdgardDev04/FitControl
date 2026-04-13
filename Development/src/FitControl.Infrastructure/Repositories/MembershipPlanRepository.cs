using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using FitControl.Infrastructure.Persistence.Context;

namespace FitControl.Infrastructure.Repositories
{
    internal class MembershipPlanRepository : IMembershipPlanRepository
    {
        private readonly FitControlDbContext _context;

        public MembershipPlanRepository() { }

        public MembershipPlanRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MembershipPlan entity) => await _context.MembershipPlans.AddAsync(entity);

        public async Task DeleteAsync(MembershipPlan entity) => _context.MembershipPlans.Remove(entity);

        public async Task GetActivePlanAsync() => await _context.MembershipPlans.Where(mp => mp.IsActive == true).ToListAsync();

        public async Task<IEnumerable<MembershipPlan>> GetAllAsync() => await _context.MembershipPlans.ToListAsync();

        public async Task<MembershipPlan?> GetByIdAsync(int id) => await _context.MembershipPlans.FindAsync(id);

        public async Task GetByNameAsync(string name) => await _context.MembershipPlans.FirstOrDefaultAsync(mp => mp.Name == name);

        public async Task GetByPriceRangeAsync(decimal minPrice, decimal maxPrice) => await _context.MembershipPlans.Where(mp => mp.Price >= maxPrice && mp.Price <= minPrice).ToListAsync();

        public async Task UpdateAsync(MembershipPlan entity) => _context.MembershipPlans.Update(entity);
    }
}
