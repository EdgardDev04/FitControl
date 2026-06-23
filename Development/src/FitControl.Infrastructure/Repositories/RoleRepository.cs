using Microsoft.EntityFrameworkCore;
using FitControl.Application.Interfaces.Repositories;
using FitControl.Domain.Entities;
using FitControl.Infrastructure.Persistence.Context;
using FitControl.Application.Common;

namespace FitControl.Infrastructure.Repositories
{
    internal class RoleRepository : IRoleRepository
    {
        private readonly FitControlDbContext _context;

        public RoleRepository(FitControlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
        }

        public async Task DeleteAsync(Role role)
        {
            _context.Roles.Remove(role);
        }

        public async Task<bool> ExistsNameAsync(string name)
        {
            return await _context.Roles.AnyAsync(r => r.Name.ToLower() == name.ToLower());
        }

        public async Task<ICollection<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<Role?> GetByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        }

        public async Task<ICollection<Role>> GetByUserId(int userId)
        {
            return await _context.Roles.Where(r => r.UserRoles.Any(ur => ur.UserId == userId)).ToListAsync();
        }

        public async Task<PagedResult<Role>> GetPagedAsync(PaginationParams paginationParams)
        {
            var query = _context.Roles.AsNoTracking();

            if (!string.IsNullOrEmpty(paginationParams.Search))
            {
                var searchTerm = paginationParams.Search.Trim();
                query = query.Where(r => r.Name.Contains(searchTerm));
            }

            var sortBy = paginationParams.SortBy?.Trim() ?? string.Empty;

            query = sortBy switch
            {
                "name" => paginationParams.Descending ? query.OrderByDescending(r => r.Name) : query.OrderBy(r => r.Name),
                _ => query.OrderBy(r => r.Id)
            };

            var totalCount = await query.CountAsync();

            var roles = await query
                .OrderBy(r => r.Id)
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<Role>
            {
                Items = roles,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)paginationParams.PageSize)
            };
        }

        public async Task UpdateAsync(Role role)
        {
            _context.Roles.Update(role);
        }
    }
}
