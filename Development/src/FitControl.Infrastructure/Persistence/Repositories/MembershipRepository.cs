using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;
using FitControl.Domain.Enums;

namespace FitControl.Infrastructure.Persistence.Repositories
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly FitControlDbContext _context;

        public MembershipRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Membership membership) => await _context.Memberships.AddAsync(membership);
        public async Task DeleteAsync(Membership membership) => _context.Memberships.Remove(membership);
        public async Task<IEnumerable<Membership>> GetAllAsync() => await _context.Memberships.ToListAsync();
        public async Task<Membership?> GetByIdAsync(int id) => await _context.Memberships.FindAsync(id);
        public async Task<ICollection<Membership>> GetMembershipByDateAsync(DateTime startdate, DateTime enddate) => await _context.Memberships.Where(m => m.StartDate >= startdate && m.EndDate <= enddate).ToListAsync();
        public async Task<ICollection<Membership>> GetMembershipsByMemberIdAsync(int memberId) => await _context.Memberships.Where(m => m.MemberId == memberId).ToListAsync();
        public async Task<ICollection<Membership>> GetMembershipsByMembershipPlanIdAsync(int membershipPlanId) => await _context.Memberships.Where(m => m.MembershipPlanId == membershipPlanId).ToListAsync();
        public async Task<ICollection<Membership>> GetMembershipsByStatusAsync(MembershipStatus status) => await _context.Memberships.Where(m => m.Status == status).ToListAsync();
        public async Task UpdateAsync(Membership membership) => _context.Memberships.Update(membership);
    }
}
