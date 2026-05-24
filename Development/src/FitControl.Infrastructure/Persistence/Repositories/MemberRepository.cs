using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;

namespace FitControl.Infrastructure.Persistence.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly FitControlDbContext _context;

        public MemberRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Member member) => await _context.Members.AddAsync(member);
        public async Task DeleteAsync(Member member) => _context.Members.Remove(member);
        public async Task<ICollection<Member>> GetActiveMembersAsync() => await _context.Members.Where(m => m.IsActive == true).ToListAsync();
        public async Task<IEnumerable<Member>> GetAllAsync() => await _context.Members.ToListAsync();
        public async Task<Member?> GetByIdAsync(int id) => await _context.Members.FindAsync(id);
        public async Task<Member?> GetByNameAsync(string name) => await _context.Members.FirstOrDefaultAsync(m => m.FirstName == name);
        public async Task<ICollection<Member>> GetInactiveMembersAsync() => await _context.Members.Where(m => m.IsActive == false).ToListAsync();
        public async Task<ICollection<Member>> GetMembersByDateRangeAsync(DateTime startDate, DateTime endDate) => await _context.Members.Where(m => m.CreatedAt >= startDate && m.CreatedAt <= endDate).ToListAsync();
        public async Task UpdateAsync(Member member) => _context.Members.Update(member);
        
    }
}
