using FitControl.Domain.Entities;
using FitControl.Domain.Interfaces;
using FitControl.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FitControl.Infrastructure.Repositories
{
    internal class MemberRepository : IMemberRepository
    {
        private readonly FitControlDbContext _context;

        public MemberRepository() { }

        public MemberRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Member entity) => await _context.Members.AddAsync(entity);

        public async Task DeleteAsync(Member entity) => _context.Members.Remove(entity);

        public async Task<IEnumerable<Member>> GetAllAsync() => await _context.Members.AsNoTracking().ToListAsync();

        public async Task GetByDocumentAsync(string document) => await _context.Members.AsNoTracking().FirstOrDefaultAsync(m => m.DocumentNumber == document);

        public async Task<Member?> GetByIdAsync(int id) => await _context.Members.FindAsync(id);

        public async Task GetByStatusAsync(bool status) => await _context.Members.AsNoTracking().FirstOrDefaultAsync(m => m.IsActive == status);

        public async Task<IEnumerable<Member>> GetAllActiveAsync() => await _context.Members.AsNoTracking().Where(m => m.IsActive == true).ToListAsync();

        public async Task<IEnumerable<Member>> GetAllInactiveAsync() => await _context.Members.AsNoTracking().Where(m => m.IsActive == false).ToListAsync();

        public async Task UpdateAsync(Member entity) => _context.Members.Update(entity);
    }
}
