using FitControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Infrastructure.Persistence.Context;
using FitControl.Application.Common;

namespace FitControl.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly FitControlDbContext _context;

        public UserRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Value == email);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<ICollection<User>> GetAllByLastLoginDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Users.AsNoTracking().Where(u => u.LastLoginAt >= startDate && u.LastLoginAt <= endDate).ToListAsync();
        }

        public async Task<ICollection<User>> GetAllByRegistrationDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Users.AsNoTracking().Where(u => u.CreatedAt >= startDate && u.CreatedAt <= endDate).ToListAsync();
        }

        public async Task<ICollection<User>> GetAllInactiveUsersAsync()
        {
            return await _context.Users.Where(u => u.IsActive == false).ToListAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<ICollection<User>> GetAllActiveUsersAsync()
        {
            return await _context.Users.Where(u => u.IsActive == true).ToListAsync();
        }

        public async Task<PagedResult<User>> GetPagedAsync(PaginationParams paginationParams)
        {
            var query = _context.Users.AsNoTracking();

            if (!string.IsNullOrEmpty(paginationParams.Search))
            {
                var searchTerm = paginationParams.Search.Trim();

                if (DateTime.TryParse(searchTerm, out DateTime searchDate))
                {
                    query = query.Where(u => u.CreatedAt.Date == searchDate.Date);
                }
                else
                {
                    query = query.Where(m => m.UserName.Contains(searchTerm) ||
                                             m.Email.Value.Contains(searchTerm)

                    );
                }
            }

            var sortBy = paginationParams.SortBy?.Trim() ?? string.Empty;

            query = sortBy switch
            {
                "UserName" => paginationParams.Descending ? query.OrderByDescending(u => u.UserName) : query.OrderBy(u => u.UserName),
                "Email" => paginationParams.Descending ? query.OrderByDescending(u => u.Email) : query.OrderBy(u => u.Email),
                "CreatedAt" => paginationParams.Descending ? query.OrderByDescending(u => u.CreatedAt) : query.OrderBy(u => u.CreatedAt),
                _ => paginationParams.Descending ? query.OrderByDescending(u => u.Id) : query.OrderBy(u => u.Id),
            };

            var totalCount = await query.CountAsync();

            var users = await query
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<User>
            {
                Items = users,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)paginationParams.PageSize)
            };
        }

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            return await _context.Users.AnyAsync(u => u.Id == user.Id && u.PasswordHash == password);
        }
    }
}
