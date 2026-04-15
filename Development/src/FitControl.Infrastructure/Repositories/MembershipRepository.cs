using FitControl.Domain.Entities;
using FitControl.Domain.Enums;
using FitControl.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using FitControl.Infrastructure.Persistence.Context;

namespace FitControl.Infrastructure.Repositories
{
    internal class MembershipRepository : IMembershipRepository
    {
        private readonly FitControlDbContext _context;

        public MembershipRepository() { }

        public MembershipRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Membership entity) => await _context.Memberships.AddAsync(entity);

        public async Task DeleteAsync(Membership entity) => _context.Memberships.Remove(entity);

        public async Task<IEnumerable<Membership>> GetAllAsync() => await _context.Memberships.AsNoTracking().ToListAsync();

        public async Task<Membership?> GetByIdAsync(int id) => await _context.Memberships.FindAsync(id);

        public async Task<List<Membership>> GetAllByMemberIdAsync(int memberId) => await _context.Memberships.AsNoTracking().Where(m => m.MemberId == memberId).ToListAsync();

        public async Task<Membership?> GetByMemberIdAsync(int memberId) => await _context.Memberships.AsNoTracking().FirstOrDefaultAsync(m => m.MemberId == memberId);

        public async Task<List<Membership>> GetByMembershipPlanIdAsync(int membershipPlanId) => await _context.Memberships.AsNoTracking().Where(m => m.MembershipPlanId == membershipPlanId).ToListAsync();

        public async Task<List<Membership>> GetByRangeDateAsync(DateTime startDate, DateTime endDate) => await _context.Memberships.AsNoTracking().Where(m => m.StartDate >= startDate && m.EndDate <= endDate).ToListAsync();

        public async Task<List<Membership>> GetByStatusAsync(MembershipStatus status) => await _context.Memberships.AsNoTracking().Where(m => m.Status == status).ToListAsync();

        public async Task UpdateAsync(Membership entity) => _context.Memberships.Update(entity);
    }
}
