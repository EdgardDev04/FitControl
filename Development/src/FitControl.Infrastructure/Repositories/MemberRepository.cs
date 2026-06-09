using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;
using FitControl.Application.Common;

namespace FitControl.Infrastructure.Repositories
{
    internal class MemberRepository : IMemberRepository
    {
        private readonly FitControlDbContext _context;

        public MemberRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Member member) => await _context.Members.AddAsync(member);
        public async Task DeleteAsync(Member member) => _context.Members.Remove(member);
        public async Task<bool> ExistDocumentNumber(string documentNumber) => await _context.Members.AsNoTracking().AnyAsync(m => m.DocumentNumber == documentNumber);
        public async Task<bool> ExistEmail(string email) => await _context.Members.AsNoTracking().AnyAsync(m => m.Email.Value == email);
        public async Task<ICollection<Member>> GetAllActiveAsync() => await _context.Members.AsNoTracking().Where(m => m.IsActive == true).ToListAsync();
        public async Task<ICollection<Member>> GetAllAsync() => await _context.Members.AsNoTracking().ToListAsync();
        public async Task<ICollection<Member>> GetAllByDateRangeAsync(DateTime startDate, DateTime endDate) => await _context.Members.AsNoTracking().Where(m => m.CreatedAt >= startDate && m.CreatedAt <= endDate).ToListAsync();
        public async Task<ICollection<Member>> GetAllInactiveAsync() => await _context.Members.AsNoTracking().Where(m => m.IsActive == false).ToListAsync();
        public async Task<Member?> GetByEmailAsync(string email) => await _context.Members.FirstOrDefaultAsync(m => m.Email.Value == email);
        public async Task<Member?> GetByIdAsync(int id) => await _context.Members.FindAsync(id);
        public async Task<Member?> GetByNameAsync(string name) => await _context.Members.FirstOrDefaultAsync(m => m.FirstName.Contains(name) || m.LastName.Contains(name));
        public async Task<Member?> GetByPhoneNumberAsync(string phoneNumber) => await _context.Members.FirstOrDefaultAsync(m => m.PhoneNumber == phoneNumber);
       
        public async Task<PagedResult<Member>> GetPagedAsync(PaginationParams paginationParams)
        {
            var query = _context.Members.AsNoTracking();
          
            var totalCount = await query.CountAsync();

            var members = await query
                .OrderBy(m => m.Id) 
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<Member>
            {
                Items = members,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)paginationParams.PageSize)
            };
        }

        public async Task UpdateAsync(Member member) => _context.Members.Update(member);
        
    }
}
